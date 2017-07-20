using System.Collections.Generic;
using System.Linq;
using FirstMillionaire.Domain.Entities;

namespace FirstMillionaire.Repositories.Static
{
    public class StaticUserRepository : IUserRepository
    {
        private const int MinUserId = 1;
        private const int IdentityIncrement = 1;

        private static readonly List<User> Users = new List<User>();

        public User GetById(int userId)
        {
            var user = Users.FirstOrDefault(x => x.Id == userId);

            return user;
        }
               
        public User GetByEmail(string email)
        {
            var user = Users.FirstOrDefault(x => x.Email == email);

            return user;
        }

        public User Add(User user)
        {
            var lastUser = Users.LastOrDefault();            

            user.Id = lastUser != null ? lastUser.Id + IdentityIncrement : MinUserId;
            Users.Add(user);

            return user;
        }
    }
}
