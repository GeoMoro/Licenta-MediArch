using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRep
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly DatabaseContext _databaseService;

        public UserAccountRepository(DatabaseContext databaseService)
        {
            _databaseService = databaseService;
        }

        public IReadOnlyList<UserAccount> GetAllUsers()
        {
            return _databaseService.UserAccounts.OrderBy(x => x.BirthDate).ToList();
        }
        
        public UserAccount GetUserById(Guid id)
        {
            return _databaseService.UserAccounts.SingleOrDefault(user => user.Id == id);
        }

        public string GetUsersNameById(Guid id)
        {
            return _databaseService.UserAccounts.SingleOrDefault(user => user.Id == id).Email.ToString();
        }

        public void CreateUser(UserAccount user)
        {
            _databaseService.UserAccounts.Add(user);

            _databaseService.SaveChanges();
        }

        public void EditUser(UserAccount user)
        {
            _databaseService.UserAccounts.Update(user);

            _databaseService.SaveChanges();
        }

        public void DeleteUser(UserAccount user)
        {
            _databaseService.UserAccounts.Remove(user);

            _databaseService.SaveChanges();
        }
    }
}
