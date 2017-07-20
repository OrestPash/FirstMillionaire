using System.Collections.Generic;
using System.Linq;
using FirstMillionaire.Domain;
using FirstMillionaire.Domain.Entities;
using FirstMillionaire.Domain.Enums;
using FirstMillionaire.Domain.ValueObjects;
using FirstMillionaire.Repositories;

namespace FirstMillionaire.Core.Managers
{
    public class GameManager : IGameManager
    {
        private const int DefaultPayoutProgress = 0;
        private const int DefaultLivesCount = 1;        
        
        private readonly IUserRepository _users;
        private readonly IQuestionRepository _questions;
        private readonly IGameRepository _games;
        private readonly List<PayoutItem> _payout;

        public GameManager(IUserRepository userRepository, 
            IQuestionRepository questionRepository,            
            IGameRepository gamesRepository)
        {
            _users = userRepository;
            _questions = questionRepository;
            _games = gamesRepository;            
            _payout = new List<PayoutItem>()
            {
                new PayoutItem() {Prize = 100, IsSafeHaven = false, QuestionComplexity = Complexity.Easy},
                new PayoutItem() {Prize = 200, IsSafeHaven = false, QuestionComplexity = Complexity.Easy},
                new PayoutItem() {Prize = 300, IsSafeHaven = false, QuestionComplexity = Complexity.Easy},
                new PayoutItem() {Prize = 500, IsSafeHaven = false, QuestionComplexity = Complexity.Easy},
                new PayoutItem() {Prize = 1000, IsSafeHaven = true, QuestionComplexity = Complexity.Easy},

                new PayoutItem() {Prize = 2000, IsSafeHaven = false, QuestionComplexity = Complexity.Medium},
                new PayoutItem() {Prize = 4000, IsSafeHaven = false, QuestionComplexity = Complexity.Medium},
                new PayoutItem() {Prize = 8000, IsSafeHaven = false, QuestionComplexity = Complexity.Medium},
                new PayoutItem() {Prize = 16000, IsSafeHaven = false, QuestionComplexity = Complexity.Medium},
                new PayoutItem() {Prize = 32000, IsSafeHaven = true, QuestionComplexity = Complexity.Medium},

                new PayoutItem() {Prize = 64000, IsSafeHaven = false, QuestionComplexity = Complexity.Hard},
                new PayoutItem() {Prize = 125000, IsSafeHaven = false, QuestionComplexity = Complexity.Hard},
                new PayoutItem() {Prize = 250000, IsSafeHaven = false, QuestionComplexity = Complexity.Hard},
                new PayoutItem() {Prize = 500000, IsSafeHaven = false, QuestionComplexity = Complexity.Hard},
                new PayoutItem() {Prize = 1000000, IsSafeHaven = true, QuestionComplexity = Complexity.ExtraHard}
            };
        }

        public Game Start(int userId)
        {
            var game = new Game()
            {                
                Lives = DefaultLivesCount,
                Progress = DefaultPayoutProgress,
                Payout = _payout,
                User = _users.GetById(userId),
                CurrentQuestion =  _questions.GetQuestionByComplexity(Complexity.Easy)
            };

            var createdGame = _games.Add(game);

            return createdGame;
        }

        public Game Next(int gameId, Answer userAnswer)
        {
            var game = _games.GetById(gameId);

            var isQuestionValid = CheckAnswer(game, userAnswer);
            if (!isQuestionValid)
            {
                game.Lives--;
            }
            else
            {
                var payout = game.Payout.ElementAt(++game.Progress);
                game.CurrentQuestion = _questions.GetQuestionByComplexity(payout.QuestionComplexity);

                _games.Update(game);
            }            

            return game;
        }

        private bool CheckAnswer(Game game, Answer userAnswer)
        {
            var currentQuestionAnswer = game.CurrentQuestion.Answer;
            var isValid = currentQuestionAnswer.OptionId == userAnswer.OptionId;

            return isValid;
        }
    }
}
