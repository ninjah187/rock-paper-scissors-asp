using System;
using System.Collections.Generic;
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

            const int testLength = 256985;
            for (int i = 0; i < testLength; i++)
            {
                Console.WriteLine(i + ": " + generator.GetUrl(i));   
            }

            Console.ReadKey();
        }
    }
}
