using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class level_C : Ilevel
    {
        public void LevelWahl(Board game)
        {
            game.Feldkreieren(30, 16, 99);
        }
    }
}
