using FirstMillionaire.Domain.Entities;

namespace FirstMillionaire.Repositories
{
    public interface IUserRepository
    {
        User GetById(int userId);

        User GetByEmail(string email);

        User Add(User user);
    }
}
