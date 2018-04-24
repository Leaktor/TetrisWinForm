using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWinForm
{
    class LeftCommand:ICommand
    {
      public  (int[,] shape, int left, int right) command(AbstractShape ab)
        {
         return (null, 1, 0);
        }
    }
}
