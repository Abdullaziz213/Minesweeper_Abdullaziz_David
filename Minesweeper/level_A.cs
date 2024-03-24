using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class level_A : Ilevel
    {
        public void LevelWahl(Board game)
        {
            game.Feldkreieren(8, 8, 10);
        }
    }
}
