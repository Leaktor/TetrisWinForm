using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWinForm
{
    interface ICommand
    {
         (int[,]shape,int left,int right) command(AbstractShape ab);
    }
}
