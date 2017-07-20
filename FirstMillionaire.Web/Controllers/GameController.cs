using System.Collections.Generic;
using System.Web.Mvc;
using FirstMillionaire.Core.Managers;
using FirstMillionaire.Web.Infrastructure.Constants;
using FirstMillionaire.Web.Infrastructure.Stores;

namespace FirstMillionaire.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameManager _gameManager;
        private readonly ISessionStore _sessionStore;

        public GameController(IGameManager gameManager, ISessionStore sessionStore)
        {
            _gameManager = gameManager;
            _sessionStore = sessionStore;            
        }

        public ActionResult Start(int userId)
        {
            var game = _gameManager.Start(userId);

            _sessionStore.Set(SessionKeys.UserSessionKey, userId);
            _sessionStore.Set(SessionKeys.GameSessionKey, game.Id);

            return View(game);
        }

        ////[HttpPost]
        ////public ActionResult Next( int userId)
        ////{
            
        ////}
    }
}