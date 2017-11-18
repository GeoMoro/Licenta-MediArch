using System.Collections.Generic;
using MediArch.Models.Entity;

namespace MediArch.Repository
{
    public interface IUserRepository
    {
        IReadOnlyList<User> GetAll();

        User GetByCNP(long cnp);

        void Add(User user);

        void Edit(User user);

        void Delete(long cnp);
    }
}
