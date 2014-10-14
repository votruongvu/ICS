using System.Linq;
using ICS.Domain.Repository;
using ICS.Domain.Model;

namespace ICS.Domain.Repository
{
    public static class UserRepositoryExtensions
    {
        public static User GetSingleByUsername(
            this IEntityRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Name == username);
        }
    }
}