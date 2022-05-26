using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotRPG
{
    public static class Pseudorandom
    {
        static int[] queue = new int[2] { 1,1 };
        public static int Next(int a,int b)
        {
            Random rnd = new Random();
            var x = rnd.Next(a,b);
            while (x==queue.Sum()/queue.Count())
            {
                x = rnd.Next(a,b);
            }
            moveQueue(x);
            testDisplay(x);
            return x;
        }
        private static void testDisplay(int x)
        {
            Console.Write($"\n{String.Join(",",queue)}\n{x}\n");
        }
        private static void moveQueue(int x)
        {
            queue[0] = queue[1];
            queue[1] = x;
        }
    }
}
