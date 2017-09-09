using CA.Expressions;
using CA.Factories;
using CA.Tokens;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA
{
    class Program
    {
        static void Main(string[] args)
        {
            ETLRuntime etlRuntime = new ETLRuntime();
            while(true)
            {
                string input = Console.ReadLine();
                string result = etlRuntime.Run(input);
                Console.WriteLine(result);
                Console.ReadKey(false);
                Console.Clear();
            }
        }
    }
}