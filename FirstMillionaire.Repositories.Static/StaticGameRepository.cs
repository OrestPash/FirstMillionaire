using System.Collections.Generic;
using System.Linq;
using FirstMillionaire.Domain.Entities;

namespace FirstMillionaire.Repositories.Static
{
    public class StaticGameRepository : IGameRepository
    {
        private const int MinUserId = 1;
        private const int IdentityIncrement = 1;

        private static readonly List<Game> Games = new List<Game>();

        public Game Add(Game game)
        {
            var lastGame = Games.LastOrDefault();

            game.Id = lastGame != null ? lastGame.Id + IdentityIncrement : MinUserId;
            Games.Add(game);

            return game;
        }

        public Game Update(Game game)
        {
            throw new System.NotImplementedException();
        }

        public Game GetById(int gameId)
        {
            var game = Games.FirstOrDefault(x => x.Id == gameId);

            return game;
        }
    }
}
