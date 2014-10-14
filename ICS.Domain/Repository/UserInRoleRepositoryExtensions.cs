using System.Linq;
using ICS.Domain.Repository;
using ICS.Domain.Model;

namespace ICS.Domain.Repository
{
    public static class UserInRoleRepositoryExtensions
    {
        public static bool IsUserInRole(
            this IEntityRepository<UserInRole> userInRoleRepository,
            int userId,
            int roleId)
        {
            return userInRoleRepository.GetAll()
                .Any(x => x.UserId == userId && x.RoleId == roleId);
        }
    }
}
