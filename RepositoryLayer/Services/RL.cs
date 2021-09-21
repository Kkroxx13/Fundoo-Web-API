using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class RL : IRL<User>
    {
        readonly UserContext _userContext;
        public RL(UserContext context)
        {
            _userContext = context;
        }
        public void Add(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
        }

        public User Get(long id)
        {
            return _userContext.Users.FirstOrDefault(e => e.UserId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public void Update(User user, User user1)
        {
            user.FirstName = user1.FirstName;
            user.LastName = user1.LastName;
            user.Email = user1.Email;
            user.Password = user1.Password;
            user.CreatedAt = user1.CreatedAt;
            user.ModifiedAt = user1.ModifiedAt;
            _userContext.SaveChanges();
        }
    }
}
