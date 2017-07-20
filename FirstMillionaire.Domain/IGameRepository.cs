using FirstMillionaire.Domain.Entities;

namespace FirstMillionaire.Repositories
{
    public interface IGameRepository
    {
        Game Add(Game game);

        Game Update(Game game);

        Game GetById(int gameId);
    }    
}
