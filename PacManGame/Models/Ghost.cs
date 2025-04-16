using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGame.Models
{
    public class Ghost
    {
        public Position Position { get; private set; }
        private Random rnd = new();

        public Ghost(int x, int y)
        {
            Position = new Position(x, y);
        }

        public void Move(GameBoard board, Position playerPos)
        {
            var directions = new[]
            {
            new Position(0, -1),
            new Position(0, 1),
            new Position(-1, 0),
            new Position(1, 0)
        };

            var possibleMoves = directions
                .Select(d => new Position(Position.X + d.X, Position.Y + d.Y))
                .Where(p => !board.IsWall(p))
                .ToList();

            if (possibleMoves.Any())
                Position = possibleMoves[rnd.Next(possibleMoves.Count)];
        }
    }
}
