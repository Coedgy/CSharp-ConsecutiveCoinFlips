using System;
using System.Diagnostics;

namespace CoinFlipper
{
    internal class Program
    {
        public static Random r = new Random();
        
        public static void Main(string[] args)
        {
            Console.WriteLine("How many same side results in a row:");
            int targetAmount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("How many seconds to run for:");
            int seconds = Int32.Parse(Console.ReadLine());
            
            long tryCount = 1;
            long nextPrint = 1000000;
            int streak = 0;
            Side prevSide = FlipCoin();

            Stopwatch s = new Stopwatch();
            s.Start();

            while (s.Elapsed < TimeSpan.FromSeconds(seconds))
            {
                Side result = FlipCoin();

                if (prevSide == result)
                {
                    streak++;
                }
                else
                {
                    streak = 0;
                }

                if (tryCount == nextPrint)
                {
                    Console.WriteLine("Mid-time report: " + tryCount + " flips counted");
                    nextPrint = nextPrint * 5;
                }
                
                tryCount++;
                prevSide = result;
            }
            
            s.Stop();

            Console.WriteLine("It took " + s.ElapsedMilliseconds + " ms to calculate " + tryCount + " flips");
        }

        static Side FlipCoin()
        {
            int x = r.Next(0, 2);
            return (Side)x;
        }
    }

    public enum Side
    {
        Heads,
        Tails
    }
}