using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGame.Models
{
    public class ScoringHistory
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public ScoringHistory() { }

        public void ListScores()
        {

            var listOrder = Players.OrderByDescending(x => x.Score).ToList();
            for (int i = 0; i < listOrder.Count; i++)
            {
                Console.WriteLine($"{i+1} - {listOrder[i].Name}, Pontos: "+listOrder[i].Score);
            }
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
