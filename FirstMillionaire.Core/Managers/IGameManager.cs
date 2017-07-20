using FirstMillionaire.Domain.Entities;

namespace FirstMillionaire.Core.Managers
{
    public interface IGameManager
    {
        Game Start(int userId);
    }
}
