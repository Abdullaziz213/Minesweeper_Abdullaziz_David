using System.Xml.Schema;

namespace Minesweeper
{
    public class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen bei Minesweeper");
            Console.WriteLine("Choose the difficulty level:");
            Console.WriteLine("1. Anfaenger");
            Console.WriteLine("2. Profis");
            Console.WriteLine("3. Superprofis");

            int choice = int.Parse(Console.ReadLine());
            
            Ilevel strategy = null;

            switch (choice)
            {
                case 1:
                    strategy = new level_A();
                    break;
                case 2:
                    strategy = new level_B();
                    break;
                case 3:
                    strategy = new level_C();
                    break;
                default:
                    Console.WriteLine("Dieses Level existiert nicht");
                    return;
            }

            Board game = new Board();
            strategy.LevelWahl(game);
            BoardCreater controller = new BoardCreater(game);
            while (true)
            {
                controller.BoardErstellen();
                Console.Clear();
                Console.WriteLine("Wähle den Schwierigkeitsgrad:");
                Console.WriteLine("1. Einfach");
                Console.WriteLine("2. Mittel");
                Console.WriteLine("3. Schwer");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        strategy = new level_A();
                        break;
                    case 2:
                        strategy = new level_B();
                        break;
                    case 3:
                        strategy = new level_C();
                        break;
                    default:
                        Console.WriteLine("Dieses Level existiert nicht");
                        return;
                }
                strategy.LevelWahl(game);
            }
        }
    }
}
