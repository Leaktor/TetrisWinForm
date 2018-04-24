﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWinForm
{
    class Gamefield
    {
        int[,] field;// = new int[20, 10];
        int[,] shape;
        int height;
        int length;
        int left;
        int[,] tempfield; //= new int[20, 10];
        int down=0;
        ReverseCommand reversecommand;
        AbstractShape dshape;
        TShape tsh = new TShape();
        IShape ish = new IShape();
        JShape jsh = new JShape();
        AbstractShape abSh = new LShape();
        AbstractShape[] shapes = { new IShape(), new JShape(), new OShape(), new LShape(), new SShape(), new TShape(), new ZShape() };

        private void getshape()
        {
            Random rand = new Random();
            abSh = shapes[rand.Next(shapes.Length)];

        }
        
        public Gamefield(int fieldX, int fieldY)
        {

            field = new int[fieldX, fieldY]; // Field(fieldX, fieldY).gamefield;
            tempfield = new int[fieldX, fieldY];// Field(fieldX, fieldY).gamefield;
            reversecommand = new ReverseCommand();

            SetShape(abSh);
            height = fieldX;
            length = fieldY;
            left = 0;
     

        }
        
        
        private void SetShape(AbstractShape _shape)
        {
            shape = _shape.shape;
            dshape = _shape;


        }

        public void Moveleft()
        {
          
            if (IsMovieLeft())
            {
                left += 1;
            }
        }
   
        public void Movedown()
        {
           
            if (isMovieDown())
            {
                down += 1;
            }
        } 

        public int[,] Reverse()
        {
            if (IsReverse())
                return (reversecommand.command(dshape).shape);
            else return null;
        }

        public void Rev()
        {          
           
            TetrisShape th = new TetrisShape(abSh);
            SetShape(abSh);
            th.getShape = Reverse();
        }

        bool IsReverse()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((shape[i, j] == 1) && ((j + ((length / 2 - left)) < 0)))
                    {
                        while ((shape[i, j] == 1) && ((j + ((length / 2 - left)) < 0)))
                            left -= 1;
                        left = length / 2;
                        return false;
                    }
                    if ((shape[i, j] == 1) && ((j + ((length / 2 - left)) > 19)))
                    {
                        while ((shape[i, j] == 1) && ((j + ((length / 2 - left)) > 19)))
                            left += 1;
                        return true;
                    }
                }
            }
            return true;
         }

        public   void ClearField()
        {
            for(int i=0;i< 20; i++)
            {
                for (int j = 0;j < 10; j++)
                {
                    field[i, j] = tempfield[i, j];
                }
            }
        }

        private bool LeftBorder(int i,int j)
        {


            if ((((shape[i, j] == 1)) && (((j + (length / 2 - left)) >= 0))))
                    {
                        return true;
                    }
         
            return false;
        }




        private bool DownBorder(int i, int j)
        {

            if (((shape[i, j] == 1) && ((i + down) <20)))
            {
                return true;
            }

            return false;
        }

        private bool RightBorder(int i, int j)
        {

            if ((((shape[i, j] == 1)) && (((j + (length / 2 - left)) < 10))))
            {
                return true;
            }

            return false;
        }


        public  int[,] StartPos()
        {
            ClearField();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j< 4; j++)
                {
                       if(LeftBorder(i,j)&& RightBorder(i,j)&& DownBorder(i,j))
                    {

                       field[i+down, j + (length / 2- left)] = 1;
                    

                    }
                }
            }
          
            return field;
        }
        public  void Set()
        {
          
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (((shape[i, j] == 1) && (((j + (length / 2 - left)) >= 0)))&& (((shape[i, j] == 1)) && (((j + (length / 2 - left)) <= 9))))
                    {
                        tempfield[i + down, j + (length / 2 - left)] = 1;
                       
                    }

                }
                }
            getshape();
            Rev();
            
        }
        
        private void Remove()
        {
            int count = 0;

            for (int i = 0; i <= 19; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (field[i, j] == 1)
                    {
                        count++;
                        
                    }

                    if (count >= 10)
                    {


                        for(int x = 0; x < 10; x++)
                        {
                            tempfield[i, x] = 0;
                            for (int a = i; a > 1; a--)
                            {
                              //  for (int b = 0; b < 10; b++)
                           //     {
                                    tempfield[a, x] = tempfield[a-1 , x];

                            //    }
                            }

                        }
                
                    }
                    
                }
                
                count = 0;
            }
      
        }
    
        
      private bool IsMovie()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (shape[i, j] == 1 && (j + ((length / 2 - left)) == 9)||shape[i, j] == 1 && (tempfield[i + down, j + ((length / 2 - left+1))]) == 1 )
                    {
                     
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsMovieLeft()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((shape[i, j] == 1)&&((j + ((length / 2 - left))==0)||shape[i, j] == 1 && (tempfield[i + down, j + ((length / 2 - left - 1))]) == 1))
                    {
                      
                        return false;
                    }
                }
            }
            return true;
        }
       private bool isMovieDown()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (((shape[i, j] == 1) && ((i + down) == 19)) || (shape[i, j] == 1) && (tempfield[i + down + 1, j + ((length / 2 - left))] == 1))
                    {
                        Set();
                        Remove();
                        left = 0;
                        down = 0;
                        return false;


                    }
                      }

                    }
             
            return true;
        }
        public void MoveRight()
        {
      
            if (IsMovie())
            {
                left -= 1;
            }
        }
    }
}