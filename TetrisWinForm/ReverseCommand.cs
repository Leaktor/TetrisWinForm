using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWinForm
{
    class ReverseCommand:ICommand
    {
       public (int[,]shape,int left,int right) command(AbstractShape ab)
        {
            int[,] reverse = new int[4, 4];

            for (int x = 0; x < 4; x++)
            {

                for (int y = 0; y < 4; y++)                {

                    reverse[x, y] = ab.shape[3 - y, x]; // по часовой
               //     reverse[x, y] = ab.shape[ y, 3-x];//против часовой


                }
                
            }

            return (reverse,0,0);
        }
    }
}
