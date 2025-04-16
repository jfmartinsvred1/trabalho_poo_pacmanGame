using PacManGame.Enums;

namespace PacManGame.Models
{
    public static class Menu
    {
        public static void GenerateMenu()
        {
            Menu.CleanMenu();
            Console.WriteLine("------------------------------");
            Console.WriteLine("           PacManGame         ");
            Console.WriteLine("                              ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("             Opções           ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("                              ");
            Console.WriteLine("1 - Jogar                     ");
            Console.WriteLine("2 - Pontuações                ");
            Console.WriteLine("3 - Sair                      ");
            Console.WriteLine("------------------------------");
        }


        public static void IncorrectOption()
        {
            CleanMenu();
            Console.WriteLine("Digitou uma opção inválida, tente novamente.");
            Thread.Sleep(2000);
            CleanMenu();

        }
        public static EOption ChooseOption()
        {
            Console.Write("Digite o número da opção: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: return EOption.Jogar;
                case 2: return EOption.Pontuacao;
                case 3: return EOption.Sair;
                default: return EOption.Incorreto;
            }
        }

        public static void CleanMenu()
        {
            Console.Clear();
        }

        public static void CloseGame()
        {
            CleanMenu();
            Console.WriteLine("Você saiu do jogo até breve!!!");
            Thread.Sleep(2000);
            return;
        }

        public static void RunMenu()
        {
            bool loopMenu = true;
            var scoresHistory = new ScoringHistory();
            while (loopMenu)
            {
                Menu.GenerateMenu();
                EOption option = Menu.ChooseOption();
                switch (option)
                {
                    case EOption.Jogar:
                        {
                            var game = new Game();
                            var player = game.Run();
                            scoresHistory.AddPlayer(player);
                            break;
                        }
                    case EOption.Sair:
                        {
                            Menu.CloseGame();
                            loopMenu = false;
                            break;
                        }
                    case EOption.Pontuacao:
                        {
                            var score = new Score(scoresHistory);
                            score.GenerateViewScore();
                            break;
                        }
                    default:
                        {
                            Menu.IncorrectOption();
                            break;
                        }
                }
            }
        }
    }
}