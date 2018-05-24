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
    public partial class TetrisForm : Form
    {

        public TetrisForm()
        {
            InitializeComponent();
            

            

        }
        
        Gamefield gf = new Gamefield(20, 10);
        
        
    
        
        //Cell cell = new Cell();
        public void refresh()
        {

            int[,] myfield = gf.StartPos();

            Graphics formGraphics = CreateGraphics();
            Cell filledcell = new Cell(Color.Red, formGraphics);
            Cell cell = new Cell(Color.Cyan, formGraphics);







            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 10; y++)
                {
      

                    if (myfield[x, y] == 1)
                    {

                        //  formGraphics.FillPolygon(filledcell, DrawShape(x,y));

                        filledcell.getCell(x, y);
                    }


                    if (myfield[x, y] == 0)
                    {



                        cell.getCell(x, y);
                     //   formGraphics.FillPolygon(cellcolor, DrawShape(x, y));

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
                gf.Reverse();
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