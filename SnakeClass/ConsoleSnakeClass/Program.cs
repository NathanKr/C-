using System;
using System.Threading;

namespace ConsoleSnakeClass
{

    /*
     * 1) implement TODO in Snake class  
     * 2) invoke the application and compare what you expect to what you get
     * 
     */

    class Program
    {
        static void Sleep()
        {
            Thread.Sleep(1000);
        }
        static void testSnakeClass()
        {
            Snake snake = new Snake(
                new Point(5, 5), // head 
                new Point(0, 0), // board top left
                new Point(10, 10),// board botton , left
                'O', // snake head
                'x' // snake tail parts
                );


            // -------- check Move
            snake.Move(Direction.Right); // now snake head is in 5,6
            snake.Write(); // show snake at 5,6
            Sleep();

            snake.Move(Direction.Left); // now snake head is in 5,5
            snake.Write(); // show snake at 5,5
            Sleep();

            snake.Move(Direction.Up); // now snake head is in 5,4
            snake.Write(); // show snake at 5,4
            Sleep();

            snake.Move(Direction.Down); // now snake head is in 5,5
            snake.Write(); // show snake at 5,5
            Sleep();

            // -------- check Grow
            snake.Grow(); // 
            snake.Write();
            Sleep();

            snake.Grow(); // 
            snake.Write();
            Sleep();
        }
        static void Main(string[] args)
        {
            testSnakeClass();
        }
    }
}
