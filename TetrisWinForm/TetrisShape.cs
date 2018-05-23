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
        ReverseCommand reversecommand = new ReverseCommand();

        AbstractShape[] shapes = { new IShape(), new JShape(), new OShape(), new LShape(), new SShape(), new TShape(), new ZShape() };

        public TetrisShape()
        {
            Random rand = new Random();
            _shape = shapes[rand.Next(shapes.Length)];
        }

        public int[,] reverse()
        {
          _shape.shape=reversecommand.command(_shape);
            return _shape.shape;
        }

        public void getAnothershape()
        {
            Random rand = new Random();
            _shape = shapes[rand.Next(shapes.Length)];

        }

        public AbstractShape getShape
        {
            get { return _shape; }
            set {}
            
            }
        public int[,] SetShape(AbstractShape shape)
        {
            _shape = shape;
            return _shape.shape;
        }
    }
}
