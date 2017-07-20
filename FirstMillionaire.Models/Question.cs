using System.Collections.Generic;

namespace FirstMillionaire.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int Text { get; set; }

        public Complexity Complexity { get; set; }

        public List<Option> Options { get; set; }
    }
}
