using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running");

            var evenFib = from n in Fibonacci()
                          //where n % 2 == 0
                          select n;

            foreach (BigInteger n in evenFib)
            {
                Console.WriteLine(n);
                Thread.Sleep(300);
            }

            Console.ReadLine();
        }

        static IEnumerable<BigInteger> Fibonacci()
        {
            Console.WriteLine("calling Fibonacci");
            BigInteger n1 = 1;
            BigInteger n2 = 1;
            Console.WriteLine("yield return n1");
            yield return n1;
            
            while (true)
            {
                Console.WriteLine($"yield return n2, n1={n1} n2={n2}");
                yield return n2;
                BigInteger t = n1 + n2;
                n1 = n2;
                n2 = t;
            }
        }
    }
}
