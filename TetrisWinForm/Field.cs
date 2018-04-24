using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWinForm
{
    class Field
    {
        static  int height;
        static int length;
        public Field(int _height, int _length)
        {
            height = _height;
            length = _length;
        }
       
       int[,] field = new int[height, length]; 
       public int[,] gamefield
        {
            get
            {
                return field;
            }
            set
            {
                field = value;
            }
        }
    }
}
