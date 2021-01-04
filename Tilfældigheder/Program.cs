using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;

namespace Tilfældigheder
{
    class Program
    {
        static Random rand = new Random();
        static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(RandomTest);
            Thread t2 = new Thread(CryptoTest);
            t1.Start();
            t2.Start();

            Thread.Sleep(10000);

        }

        /// <summary>
        /// Function to test the System.Random
        /// </summary>
        static void RandomTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                int value = rand.Next(0, 1000);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            Console.WriteLine("The random function generated 10000 number in: {0}", ts);
        }

        /// <summary>
        /// Function to test the RNGCryptoServiceProvider
        /// </summary>
        static void CryptoTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            byte[] data = new byte[4];
            for (int i = 0; i < 10000; i++)
            {
                rng.GetBytes(data);
                int value = BitConverter.ToInt32(data, 0);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            Console.WriteLine("The crypto function generated 10000 number in: {0}", ts);
        }
    }
}
