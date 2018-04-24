using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisWinForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        Gamefield gf = new Gamefield(20, 10);
    
        private Point[] DrawShape(int startpointx,int startpointy)
        {
            int cellsize = 25;
            int filledcellsize = 20;
            Point p1 = new Point(startpointy * cellsize, startpointx * cellsize);
            Point p2 = new Point(startpointy * cellsize + filledcellsize, startpointx * cellsize);
            Point p3 = new Point(startpointy * cellsize, startpointx * cellsize + filledcellsize);
            Point p4 = new Point(startpointy * cellsize + filledcellsize, startpointx * cellsize + filledcellsize);
            return new Point[] { p1, p3, p4, p2 };
        }


        public void refresh()
        {

            int[,] myfield = gf.StartPos();



            Graphics formGraphics = CreateGraphics();
         //   Graphics form = CreateGraphics();
            SolidBrush cellcolor = new SolidBrush(Color.Cyan);
            SolidBrush filledcell = new SolidBrush(Color.Red);
          


            
         
          
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 10; y++)
                {
      

                    if (myfield[x, y] == 1)
                    {

                        
                        //      formGraphics.FillEllipse(brush2, new Rectangle(cellsize * y, cellsize * x, filledcellsize, filledcellsize));
                        
                        formGraphics.FillPolygon(filledcell, DrawShape(x,y));
                    }


                    if (myfield[x, y] == 0)
                    {


                        
                        /// formGraphics.FillEllipse(brush1, new Rectangle(cellsize * y, cellsize * x, filledcellsize, filledcellsize));
                        formGraphics.FillPolygon(cellcolor, DrawShape(x, y));

                    }


                }
            }
        }

  

        private void timer1_Tick(object sender, EventArgs e)
        {
            refresh();
            gf.Movedown();
            refresh();
        }

      
   

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S|| e.KeyCode == Keys.Down)
            {
                gf.Movedown();
                refresh();
            }

            if(e.KeyCode == Keys.A||e.KeyCode==Keys.Left)
            {
                gf.Moveleft();
                refresh();
            }
            if (e.KeyCode==Keys.D|| e.KeyCode == Keys.Right)
            {
                gf.MoveRight();
                refresh();
            }
            if (e.KeyCode == Keys.W|| e.KeyCode == Keys.Up)
            {
                refresh();          
                gf.Rev();
                refresh();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 300;
            timer1.Enabled = true;
          
        }

  
    }
}