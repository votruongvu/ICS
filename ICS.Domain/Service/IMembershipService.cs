using ICS.Core.Data;
using ICS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Domain.Service
{
    public interface IMembershipService
    {
        ValidUserContext ValidateUser(string username, string password);

        OperationResult<UserInRole> CreateUser(
            string username, string email, string password);

        OperationResult<UserInRole> CreateUser(
            string username, string email,
            string password, string role);

        OperationResult<UserInRole> CreateUser(
            string username, string email,
            string password, string[] roles);

        UserInRole UpdateUser(
            User user, string username, string email);

        bool ChangePassword(
            string username, string oldPassword, string newPassword);

        bool AddToRole(Guid userKey, string role);
        bool AddToRole(string username, string role);
        bool RemoveFromRole(string username, string role);

        IEnumerable<Role> GetRoles();
        Role GetRole(Guid key);
        Role GetRole(string name);

        PaginatedList<UserInRole> GetUsers(int pageIndex, int pageSize);
        UserInRole GetUser(Guid key);
        UserInRole GetUser(string name);
    }
}
