using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWinForm
{
    class TetrisShape
    {
        private AbstractShape _shape;
        ICommand reversecommand = new ReverseCommand();
        public TetrisShape(AbstractShape shape)
        {
            _shape = shape;

        }
        public int[,] reverse()
        {
          return  (reversecommand.command(_shape).shape);
        }
        public int [,] getShape{
            get
            {
                return _shape.shape;
            }
            set
            {
                _shape.shape = value;
            }
            }
    }
}
