using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Spielmemento
    {
        public char[,] Grid { get; private set; }
        public bool Spielverloren { get; private set; }

        public Spielmemento(char[,] grid, bool gameOver)
        {
            Grid = grid;
            Spielverloren = gameOver;
        }
    }
}
