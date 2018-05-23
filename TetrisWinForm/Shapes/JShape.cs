using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWinForm
{
    class JShape : AbstractShape
    {
        private int[,] tshape =  {{ 0,0,1,1 },
                                  { 0,0,1,0 },
                                  { 0,0,1,0 },
                                  { 0,0,0,0 }};
        public int[,] shape
        {
            get { return tshape; }
            set { tshape = value;}
        }
    }
}
