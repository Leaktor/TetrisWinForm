using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWinForm
{
    class RightCommand:ICommand
    {
        public (int[,] shape, int left, int right) command(AbstractShape ab)
        {
            return (null, 0, 1);
        }
    }
}
