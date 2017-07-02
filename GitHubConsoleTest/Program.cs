using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

            reevalDeferred();

            //callFibonacci();

            Console.ReadLine();
        }

        private static void callFibonacci()
        {
            var evenFib = from n in Fibonacci()
                              //where n % 2 == 0
                          select n;

            foreach (BigInteger n in evenFib)
            {
                Console.WriteLine(n);
                Thread.Sleep(300);
            }
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

        // reevaluating of a deferred query
        private static void reevalDeferred()
        {
            var sw = Stopwatch.StartNew();

            //var commaCultures = from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
            //                    where culture.NumberFormat.NumberDecimalSeparator == ","
            //                    select culture;

            var commaCultures = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(c => c.NumberFormat.NumberDecimalSeparator == ",").ToList();

            object[] numbers = { 1, 100, 100.2, 10000.2 };

            foreach (object number in numbers)
            {
                foreach (CultureInfo culture in commaCultures)
                {
                    Console.WriteLine(string.Format(culture, "{0}: {1:c}",
                        culture.Name, number));
                }
            }

            sw.Stop();
            Console.WriteLine($"Result: {sw.ElapsedMilliseconds} ms");
        }
    }
}
