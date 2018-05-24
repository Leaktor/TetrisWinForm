using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TetrisWinForm
{
    class Cell
    {
        
            int cellsize = 25;
            int filledcellsize = 20;
            int startpointy;
            int startpointx;
            SolidBrush color;
            Graphics g;
            public Cell(Color color, Graphics g)
            {

                this.color = new SolidBrush(color);
                this.g = g;

            }

            private Point[] points()
            {
                Point p1 = new Point(startpointy * cellsize, startpointx * cellsize);
                Point p2 = new Point(startpointy * cellsize + filledcellsize, startpointx * cellsize);
                Point p3 = new Point(startpointy * cellsize, startpointx * cellsize + filledcellsize);
                Point p4 = new Point(startpointy * cellsize + filledcellsize, startpointx * cellsize + filledcellsize);
                return new Point[] { p1, p3, p4, p2 };
            }

            public void getCell(int startpointx, int startpointy)
            {

                this.startpointy = startpointy;
                this.startpointx = startpointx;

                g.FillPolygon(color, points());

            }

        }

    }

