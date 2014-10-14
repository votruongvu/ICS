using System.Linq;
using ICS.Domain.Repository;
using ICS.Domain.Model;

namespace ICS.Domain.Repository
{
    public static class RoleRepositoryExtensions
    {
        public static Role GetSingleByRoleName(
            this IEntityRepository<Role> roleRepository, string roleName)
        {
            return roleRepository.GetAll().FirstOrDefault(x => x.Name == roleName);
        }
    }
}
