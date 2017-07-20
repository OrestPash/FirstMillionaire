using System.Collections.Generic;

namespace FirstMillionaire.Models
{
    public class Game
    {
        public int Lives { get; set; }

        public int Progress { get; private set; }

        public List<PayoutItem> Payout { get; set; }
    }
}
