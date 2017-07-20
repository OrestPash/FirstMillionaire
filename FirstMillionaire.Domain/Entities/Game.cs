using System.Collections.Generic;
using FirstMillionaire.Domain.ValueObjects;

namespace FirstMillionaire.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }

        public int Lives { get; set; }

        public int Progress { get; set; }

        public User User { get; set; }

        public Question CurrentQuestion { get; set; }

        public List<PayoutItem> Payout { get; set; }
    }
}
