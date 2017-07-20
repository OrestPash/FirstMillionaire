using System;
using FirstMillionaire.Domain.Enums;
using FirstMillionaire.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using FirstMillionaire.Domain;

namespace FirstMillionaire.Repositories.Static
{
    public class StaticQuestionRepository : IQuestionRepository
    {
        private readonly List<Question> Questions = new List<Question>()
        {
            new Question()
            {
                Id = 1,
                Text = "Что растёт в огороде?",
                Complexity = Complexity.Easy,
                Answer = new Answer()
                {
                    QuestionId = 1,
                    OptionId = 1
                },
                Options = new List<Option>()
                {
                    new Option()
                    {
                        Id = 1,
                        QuestionId = 1,
                        Text = "Лук"
                    },
                    new Option()
                    {
                        Id = 2,
                        QuestionId = 1,
                        Text = "Пистолет"
                    },
                    new Option()
                    {
                        Id = 3,
                        QuestionId = 1,
                        Text = "Пулемет"
                    },
                    new Option()
                    {
                        Id = 4,
                        QuestionId = 1,
                        Text = "Ракета СС-20"
                    }
                }
            }
        };


        public Question GetQuestionByComplexity(Complexity complexity)
        {
            var questions = Questions.Where(x => x.Complexity == complexity).ToList();         
            var randomizer = new Random();
            var position = randomizer.Next(0, questions.Count);

            return questions.ElementAt(position);
        }
    }
}
