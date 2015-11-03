using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissorsASP.UrlGeneration;

namespace TestProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var generator = new BasicUrlGenerator();

            //const int testLength = 256985;
            //for (int i = 0; i < testLength; i++)
            //{
            //    Console.WriteLine(i + ": " + generator.GetUrl(i));   
            //}

            var sw = new Stopwatch();
            //sw.Start();
            //generator.GetUrl(0);
            //sw.Stop();

            //Console.WriteLine("1: " + sw.Elapsed);
            
            sw.Restart();
            Console.WriteLine(generator.GetUrl(50000000));
            //generator.GetUrl(500000);
            sw.Stop();

            Console.WriteLine("2: " + sw.Elapsed);

            Console.ReadKey();
        }
    }
}
