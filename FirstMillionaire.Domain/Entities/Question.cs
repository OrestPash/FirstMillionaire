using System.Collections.Generic;
using FirstMillionaire.Domain.Enums;

namespace FirstMillionaire.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public Complexity Complexity { get; set; }

        public Answer Answer { get; set; }

        public List<Option> Options { get; set; }
    }
}
