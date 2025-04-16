using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGame.Models
{
    public class Score
    {
        public Score(ScoringHistory scoringHistory)
        {
            ScoringHistory = scoringHistory;
        }

        public ScoringHistory ScoringHistory { get; set; }

        public void GenerateViewScore()
        {
            int sair = 0;
            while (sair != 1)
            {
                Console.Clear();
                ScoringHistory.ListScores();
                Console.WriteLine("Para voltar para o menu digite 1");
                int numeroDigitado = int.Parse(Console.ReadLine());
                if (numeroDigitado == 1)
                {
                    sair = numeroDigitado;
                }
            }
        }
    }
}
