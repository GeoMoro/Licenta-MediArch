using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfaces
{
    public interface IUserAccountRepository
    {
        IReadOnlyList<UserAccount> GetAllUsers();
        UserAccount GetUserByCNP(long cnp);
        UserAccount GetUserById(Guid id);
        string GetUsersNameById(Guid id);
        void CreateUser(UserAccount user);
        void EditUser(UserAccount user);
        void DeleteUser(UserAccount user);
    }
}
