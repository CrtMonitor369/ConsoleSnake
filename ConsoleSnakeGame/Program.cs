using System;
using System.Security.Cryptography;

namespace ConsoleSnakeGame
{
    internal class Program
    {
        class Block
        {
            public int x;
            public int y;
            public Block(int x,int y)
            {
                this.x = x;
                this.y = y;
            }
            
        }

        
            

        
        static void Main(string[] args)
        {
            Console.CursorVisible=false;
            int width=50;
            int height=25;
            Console.SetWindowSize(width,height);
            List<Block> Snake =  new List<Block>();
            Block Fruit = new Block(10,10);
            Snake.Add(new Block(10,10));
            int dx,dy;

            dx = 1;
            dy=0;
            
            Random rnd = new Random();
            bool gameIsRunning = true;

            //Console.ReadKey();

            while(gameIsRunning)
            {   
                Console.Clear();
                for(int i=0;i<height;i++)
                {
                    for(int j=0;j<width;j++)
                {
                    Console.Write("-");
                }
                System.Console.WriteLine();
                }
                if(Snake[Snake.Count-1].x == Fruit.x && Snake[Snake.Count-1].y == Fruit.y )
                {
                    Snake.Add(new Block(Snake[Snake.Count-1].x ,Snake[Snake.Count-1].y ));
                    Fruit.x = rnd.Next(0,width-1);
                    Fruit.y = rnd.Next(0,height-1);
                }
                for(int i =0;i<Snake.Count;i++)
                {
                    
                    Console.Write(i);
                    if(i==Snake.Count-1)
                    {
                        Snake[i].x+=dx;
                        Snake[i].y+=dy;
                    }
                    else
                    {
                        Snake[i].x = Snake[i+1].x;
                         Snake[i].y = Snake[i+1].y;
                    }
                    
                }
                for(int i = 0;i<Snake.Count;i++)
                {
                    if(i!=Snake.Count-1 && (Snake[i].x==Snake[Snake.Count-1].x && Snake[i].y==Snake[Snake.Count-1].y))
                    {
                        gameIsRunning=false;
                    }
                    Console.SetCursorPosition(Snake[i].x,Snake[i].y);
                    
                    Console.Write("¤");
                }
                
                
                if(Console.KeyAvailable)
                {
                    switch(Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.RightArrow:
                        if(dx!=-1){
                            dy=0;
                            dx=1;
                        }
                            break;
                        case ConsoleKey.LeftArrow:
                        if(dx!=1){
                            dy=0;
                            dx=-1;
                        }
                            break;
                            
                        case ConsoleKey.UpArrow:
                        if(dy!=1){
                            dx = 0;
                            dy=-1;
                        }
                            break;
                        case ConsoleKey.DownArrow:
                        if(dy!=-1){
                            dx = 0;
                            dy=1;
                        }
                            break;
                    }
                }
                
                Console.SetCursorPosition(Fruit.x,Fruit.y);
                Console.Write("Ö");
                
                Thread.Sleep(50);
            }

        }
    }
}