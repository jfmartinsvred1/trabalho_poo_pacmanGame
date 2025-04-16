using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using PacManGame.Enums;

namespace PacManGame.Models
{
    public class Game
    {
        private GameBoard board;
        private Player player;
        private Ghost ghost;
        private bool isRunning;

        public Game()
        {
            string[] layout = new string[]
            {
            "#############################",
            "#..............#...........#",
            "#.#####.#####.#.#####.#####.#",
            "#.#   #.#   #.#.#   #.#   #.#",
            "#.#####.#####.###.#####.###.#",
            "#...........................#",
            "###.###.###.#######.###.###.#",
            "  #.# #.# #.......#.# #.# #  ",
            "###.#.#.#.#### ####.#.#.#.###",
            "#...........................#",
            "#############################"
            };

            board = new GameBoard(layout);
            player = new Player(1, 1);
            ghost = new Ghost(25, 9);
        }

       

        public Player Run()
        {
            Console.Clear();
            Console.Write("Digite o nome do player: ");
            string name= Console.ReadLine();
            player.SetName(name);
            isRunning = true;
            while (isRunning)
            {
                board.Draw(player.Position, ghost.Position);
                Console.WriteLine($"Score: {player.Score}");

                var key = Console.ReadKey(true).Key;
                var oldPos = new Position(player.Position.X, player.Position.Y);
                player.Move(key);

                if (board.IsWall(player.Position))
                {
                    player.Position = oldPos;
                    continue;
                }

                if (board.IsDot(player.Position))
                {
                    board.ClearDot(player.Position);
                    player.Eat();
                }

                ghost.Move(board, player.Position);

                if (player.Position.Equals(ghost.Position))
                {
                    board.Draw(player.Position, ghost.Position);
                    Console.WriteLine("💀 Você foi pego pelo fantasma! Fim de jogo.");
                    isRunning = false;
                }

                if (player.Score == board.TotalDots())
                {
                    board.Draw(player.Position, ghost.Position);
                    Console.WriteLine("🎉 You win!");
                    isRunning = false;
                }

            }
            return player;
        }
    }
}
