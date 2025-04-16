using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGame.Models
{
    public class Player
    {
        public Position Position { get; set; }
        public string Name { get; set; }
        public int Score { get; private set; }

        public Player(int x, int y)
        {
            Position = new Position(x, y);
            Score = 0;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W: Position.Y--; break;
                case ConsoleKey.S: Position.Y++; break;
                case ConsoleKey.A: Position.X--; break;
                case ConsoleKey.D: Position.X++; break;
            }
        }

        public void Eat()
        {
            Score++;
        }
    }
}
