using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class level_B : Ilevel
    {
        public void LevelWahl(Board game)
        {
            game.Feldkreieren(16, 16, 40);
        }
    }
}
