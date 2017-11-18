using System.Collections.Generic;
using System.Linq;
using MediArch.Data;
using MediArch.Models.Entity;

namespace MediArch.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataService _databaseService;


        public UserRepository(IDataService databaseService)
        {
            _databaseService = databaseService;
        }

        public IReadOnlyList<User> GetAll()
        {
            return _databaseService.Users.ToList();
        }

        public User GetByCNP(long cnp)
        {
            return _databaseService.Users.FirstOrDefault(s => s.CNP == cnp);
        }

        public void Add(User user)
        {
            _databaseService.Users.Add(user);
            _databaseService.SaveChanges();
        }

        public void Edit(User user)
        {
            _databaseService.Users.Update(user);
            _databaseService.SaveChanges();
        }

        public void Delete(long cnp)
        {
            var user = GetByCNP(cnp);
            _databaseService.Users.Remove(user);
            _databaseService.SaveChanges();
        }
        
    }
}
