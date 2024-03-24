using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// Diese Klasse repräsentiert ein Feld im Spiel und enthält Logik für Spielaktionen.
    /// </summary>
    public class Feld : Board
    {
        
        private char[,] mineField;

        private bool gameOver = false;

        private char[,] grid;

        public int ZahlMinenUmgebung;


        /// <summary>
        /// Überprüft, ob die Gewinnbedingung erfüllt ist.
        /// </summary>
        private bool CheckWinCondition()
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == '.' && mineField[i, j] != '*')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Deckt ein Zelle im Feld auf.
        /// </summary>
        public void UncoverCell(int x, int y)
        {
            if (mineField[x, y] == '*')
            {
                gameOver = true;
                Console.WriteLine("Game Over! You uncovered a mine.");
            }
            else
            {
                UncoverConnectedCells(x, y);
                if (CheckWinCondition())
                {
                    Console.WriteLine("Congratulations! You've won the game!");
                    gameOver = true;
                }
            }
        }

        /// <summary>
        /// Überprüft ob eine Mine explodiert ist
        /// </summary>
        public bool Mineexpoldieren()
        {
            return gameOver;
        }

        /// <summary>
        /// Markiert ein Feld im Spiel.
        /// </summary>
        public void Feldmarkieren(int x, int y)
        {
            grid[x, y] = '!';
        }

        /// <summary>
        /// Deckt die verbundenen Zellen auf.
        /// </summary>
        private void UncoverConnectedCells(int x, int y)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            if (x < 0 || x >= rows || y < 0 || y >= cols || grid[x, y] != '.')
            {
                return;
            }

            grid[x, y] = mineField[x, y];
            if (mineField[x, y] == '0')
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        UncoverConnectedCells(x + dx, y + dy);
                    }
                }
            }
        }
    }



}
