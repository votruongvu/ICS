using ICS.Domain.Model;
using ICS.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Domain.Service
{
    public class MembershipService : IMembershipService
    {
        private readonly IEntityRepository<User> _userRepository;
        private readonly IEntityRepository<Role> _roleRepository;
        private readonly IEntityRepository<UserInRole> _userInRoleRepository;
        private readonly ICryptoService _cryptoService;

        public OperationResult<UserInRole> CreateUser(
            string username, string email, string password)
        {

            return CreateUser(username, password, email, roles: null);
        }

        public OperationResult<UserInRole> CreateUser(
            string username, string email, string password, string role)
        {

            return CreateUser(username, password, email, roles: new[] { role });
        }

        public OperationResult<UserInRole> CreateUser(
            string username, string email, string password, string[] roles)
        {

            var existingUser = _userRepository.GetAll().Any(
                x => x.Name == username);

            if (existingUser)
            {

                return new OperationResult<UserInRole>(false);
            }

            var passwordSalt = _cryptoService.GenerateSalt();

            var user = new User()
            {
                Name = username,
                Salt = passwordSalt,
                Email = email,
                IsLocked = false,
                HashedPassword =
                    _cryptoService.EncryptPassword(password, passwordSalt),
                CreatedOn = DateTime.Now
            };

            _userRepository.Add(user);
            _userRepository.Save();

            if (roles != null || roles.Length > 0)
            {

                foreach (var roleName in roles)
                {

                    addUserToRole(user, roleName);
                }
            }

            return new OperationResult<UserInRole>(true)
            {
                Entity = GetUserWithRoles(user)
            };
        }

        private IEnumerable<Role> GetUserRoles(Guid key)
        {
            UserInRole[] userInRoles = _userInRoleRepository.FindBy(x => x.Key == key).ToArray();
            if (userInRoles.Any())
            {
                Guid[] userRoleKeys = userInRoles.Select(x => x.Key).ToArray();
                Role[] userRoles = _roleRepository.FindBy(x => userRoleKeys.Contains(x.Key)).ToArray();

                return userRoles;
            }

            return Enumerable.Empty<Role>();
        }

        private UserInRole GetUserWithRoles(User user)
        {
            if (user != null)
            {
                IEnumerable<Role> userRoles = GetUserRoles(user.Key);
                return new UserInRole()
                {
                    User = user,
                    Role = userRoles
                };
            }

            return null;
        }

        private void addUserToRole(User user, string roleName)
        {

            var role = _roleRepository.GetSingleByRoleName(roleName);
            if (role == null)
            {

                var tempRole = new Role()
                {
                    Name = roleName
                };

                _roleRepository.Add(tempRole);
                _roleRepository.Save();
                role = tempRole;
            }

            var userInRole = new UserInRole()
            {
                RoleKey = role.Key,
                UserKey = user.Key
            };

            _userInRoleRepository.Add(userInRole);
            _userInRoleRepository.Save();
        }
    }
}
