

using CommonLayer;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IRL<User>
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        void Add(User user);
        void Update(User user, User user1);
        void Delete(User user);
    }
}
