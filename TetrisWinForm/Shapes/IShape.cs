using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWinForm
{
    class IShape : AbstractShape
    {
        private int[,] ishape ={{ 1,1,1,1 },
                                { 0,0,0,0 },
                                { 0,0,0,0 },
                                { 0,0,0,0 }};
        public  int[,] shape
        {
            get { return ishape; }
            set
            {
                ishape = value;
            }
        }
    }
}

