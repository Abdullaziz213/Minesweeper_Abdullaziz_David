using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Minesweeper
{
    /// <summary>
    /// Diese Klasse erstellt das Spielfeld und verwaltet die Interaktionen des Spielers damit.
    /// </summary>
    public class BoardCreater : Board
    {
    
        public char[,] grid;

        public char[,] mineField;

        private Board game;

        private Feld spiel;

        Program program = new Program();

        /// <summary>
        /// Konstruktor für die BoardCreater Klasse mit einem Spielbrett-Parameter.
        /// </summary>
        public BoardCreater(Board game)
        {
            this.game = game;
        }

        /// <summary>
        /// Konstruktor für die BoardCreater-Klasse mit einem Feld-Parameter.
        /// </summary>
        public BoardCreater(Feld spiel)
        {
            this.spiel = spiel;
        }

        /// <summary>
        /// Erstellt das Spielfeld und gibt es auf der Konsole aus.
        /// </summary>
        public void BoardErstellen(bool revealMines = false)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            if (program.choice = 1)
            {
                Console.WriteLine("  01234567");
            }else if (program.choice = 2)
            {
                Console.WriteLine("  0123456789101112131415");
            }else if (program.choice = 3)
            {
                Console.WriteLine("  01234567891011121314151617181920212223242526272829");
            }
            
            for (int i = 0; i < rows; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < cols; j++)
                {
                    if (revealMines && mineField[i, j] == '*')
                        Console.Write('*');
                    else
                        Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Startet das Spiel und ermöglicht es dem Spieler, Aktionen auf dem Spielfeld auszuführen.
        /// </summary>
        public void SpielStarten()
        {
            while (!game.IsGameOver())
            {
                BoardErstellen();
                Console.WriteLine("Gebe bitte eine gueltige Koordinate");
                string input = Console.ReadLine();

                if (input.ToUpper() == "L")
                {
                    Console.WriteLine("Zurueck zum Level");
                    return;
                }

                bool mark = input.StartsWith("!");
                if (mark)
                {
                    input = input.Substring(1); 
                    string[] parts = input.Split(',');
                    if (parts.Length != 2 || !int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                    {
                        Console.WriteLine("Falsche Eingabe. Bitte gebe eine gueltige Koordinate");
                        continue;
                    }
                    spiel.Feldmarkieren(x, y); 
                }
                else
                {
                    string[] parts = input.Split(',');
                    if (parts.Length != 2 || !int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                    {
                        Console.WriteLine("Falsche Eingabe. Bitte gebe eine gueltige Koordinate");
                        continue;
                    }
                    spiel.UncoverCell(x, y); 
                }
            }

            Console.WriteLine("Druecken sie bitte die Enter Taste um fortzufahren");
            Console.ReadLine();
        }
    }
}
