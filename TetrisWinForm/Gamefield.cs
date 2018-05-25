using System;
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
        AbstractShape abSh;


        TetrisShape th = new TetrisShape();
        

       
        
        public Gamefield(int fieldX, int fieldY)
        {
            th.getAnothershape();
            abSh = th.getShape;
            field = new int[fieldX, fieldY]; // Field(fieldX, fieldY).gamefield;
            tempfield = new int[fieldX, fieldY];// Field(fieldX, fieldY).gamefield;
            

            SetShape(abSh);
            height = fieldX;
            length = fieldY;
            left = 0;
     

        }
        private void getshape()
        {

            th.getAnothershape();
            abSh = th.getShape;

        }

        private void SetShape(AbstractShape _shape)
        {
            shape = _shape.shape;
        
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
           
            if (isMovieDown()&&IsReverse())
            {
                down += 1;
            }
        } 



        public void Reverse()
        {

            if (IsReverse())
            {
                th.SetShape(abSh);
                SetShape(abSh);
                th.getShape.shape = th.reverse();
            }
        }

        bool IsReverse()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if ((shape[i, j] == 1) && ((j + ((length / 2 - left)) > 9)))
                    {
                        while ((shape[i, j] == 1) && ((j + ((length / 2 - left)) > 9)))
                            left += 1;
                        return false;
                    }

                    if ((shape[i, j] == 1) && ((j + ((length / 2 - left)) <0)))
                    {
                        while ((shape[i, j] == 1) && ((j + ((length / 2 - left)) < 0)))
                        left -= 1;                       
                        return false;
                    }

                
                   
                }
               
            }
            return true;
         }

        public   void ClearField()
        {
            for(int i=0;i< height; i++)
            {
                for (int j = 0;j < length; j++)
                {
                    if (IsReverse())
                    {
                        field[i, j] = tempfield[i, j];
                    }
                }
            }
        }

        private bool IsLeftBorder(int i,int j)
        {


            if ((isFilledSquare(i,j) && (j + (length / 2 - left) >= 0)))
                    {
                        return true;
                    }
         
            return false;
        }

        private bool isFilledSquare(int i, int j)
        {
           if( shape[i, j] == 1)
                {
                return true;
            }
            return false;

        }



        private bool DownBorder(int i, int j)
        {

            if (((shape[i, j] == 1) && ((i + down) <height)))
            {
                return true;
            }

            return false;
        }

        private bool IsRightBorder(int i, int j)
        {

            if (( (((j + (length / 2 - left)) < length))))
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
                       if(IsLeftBorder(i,j)&& IsRightBorder(i,j)&& DownBorder(i,j))
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
                    if (IsLeftBorder(i, j)&& (((shape[i, j] == 1)) && (((j + (length / 2 - left)) <= 9)&&IsReverse())))
                    {
                        tempfield[i + down, j + (length / 2 - left)] = 1;
                       
                    }

                }
                }

            getshape();

            Reverse();
            
        }
        
        private void Remove()
        {
            int count = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (field[i, j] == 1)
                    {
                        count++;
                        
                    }

                    if (count >= 10)
                    {


                        for(int x = 0; x < length; x++)
                        {
                            tempfield[i, x] = 0;
                            for (int a = i; a > 1; a--)
                            {
                              
                                    tempfield[a, x] = tempfield[a-1 , x];

                          
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
                    if ((shape[i, j] == 1) && ((j + ((length / 2 - left))==0)||shape[i, j] == 1 && (tempfield[i + down, j + ((length / 2 - left - 1))]) == 1))
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

                    if ((isFilledSquare(i,j) &&((i + down) == 19)) || (shape[i, j] == 1) && (tempfield[i + down + 1, j + ((length / 2 - left))] == 1 && IsReverse()))
                    {
                        if (IsReverse())
                        {
                            Set();
                            Remove();
                        }
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
