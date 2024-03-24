using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// Diese Klasse repräsentiert das Spielfeld und enthält Logik zum Erstellen und Verwalten des Spiels.
    /// </summary>
    public class Board
    {

        private char[,] grid;

        private char[,] mineField;

        private Random random = new Random();

        private bool gameOver = false;

        /// <summary>
        /// Erstellt das Spielfeld mit den angegebenen Dimensionen und platziert die Minen.
        /// </summary>
        public void Feldkreieren(int rows, int cols, int totalMines)
        {
            grid = new char[rows, cols];
            mineField = new char[rows, cols];
            UngedecktFeld(rows, cols);
            MinePlazieren(totalMines, rows, cols);
            MinenInUmgebung(rows, cols);
        }

        /// <summary>
        /// Erstellt ein Spielfeld ohne aufgedeckte Felder.
        /// </summary>
        public void UngedecktFeld(int rows, int cols)
        {
            for (int hoehe = 0; hoehe < rows; hoehe++)
            {
                for (int breite = 0; breite < cols; breite++)
                {
                    grid[hoehe, breite] = '.';
                }
            }
        }

        /// <summary>
        /// Platziert die Minen im Spielfeld.
        /// </summary>
        public void MinePlazieren(int totalMines, int rows, int cols)
        {
            int minesPlaced = 0;
            while (minesPlaced < totalMines)
            {
                int x = random.Next(rows);
                int y = random.Next(cols);
                if (mineField[x, y] != '*')
                {
                    mineField[x, y] = '*';
                    minesPlaced++;
                }
            }
        }

        /// <summary>
        /// Berechnet die Anzahl der Minen in der Umgebung jedes Feldes im Spielfeld.
        /// </summary>
        public void MinenInUmgebung(int rows, int cols)
        {
            for (int hoehe = 0; hoehe < rows; hoehe++)
            {
                for (int breite = 0; breite < cols; breite++)
                {
                    if (mineField[hoehe, breite] != '*')
                    {
                        int count = 0;
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            for (int dy = -1; dy <= 1; dy++)
                            {
                                int nx = hoehe + dx;
                                int ny = breite + dy;
                                if (nx >= 0 && nx < rows && ny >= 0 && ny < cols && mineField[nx, ny] == '*')
                                {
                                    count++;
                                }
                            }
                        }
                        mineField[hoehe, breite] = count.ToString()[0];
                    }
                }
            }
        }



        /// <summary>
        /// Setzt das Spiel zurück, um ein neues Spiel zu starten.
        /// </summary>
        public void ResetGame()
        {
            gameOver = false;
        }
    }
}
