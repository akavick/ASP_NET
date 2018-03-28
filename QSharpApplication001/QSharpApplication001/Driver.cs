using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace QSharpApplication001
{
    internal class Driver
    {
        private static void Main()
        {
            Process();
            Console.WriteLine();
            Process2();
            Console.WriteLine();
            Process3();
            Console.WriteLine();
        }



        private static void Process()
        {
            using (var sim = new QuantumSimulator())
            {
                // Try initial values
                Result[] initials = { Result.Zero, Result.One };
                foreach (var initial in initials)
                {
                    //var (numZeros, numOnes) = BellTest.Run(sim, 1000, initial).Result;
                    var (numZeros, numOnes) = BellTest.Run(sim, 1000, initial).Result;
                    Console.WriteLine($"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4}");
                }
            }
        }




        private static void Process2()
        {
            using (var sim = new QuantumSimulator())
            {
                // Try initial values
                Result[] initials = { Result.Zero, Result.One };
                foreach (var initial in initials)
                {
                    //var (numZeros, numOnes) = BellTest.Run(sim, 1000, initial).Result;
                    var (numZeros, numOnes) = BellTest2.Run(sim, 1000, initial).Result;
                    Console.WriteLine($"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4}");
                }
            }
        }





        private static void Process3()
        {
            using (var sim = new QuantumSimulator())
            {
                // Try initial values
                Result[] initials = { Result.Zero, Result.One };
                foreach (var initial in initials)
                {
                    var (numZeros, numOnes, agree) = BellTest3.Run(sim, 1000, initial).Result;
                    Console.WriteLine($"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4} agree={agree,-4}");
                }
            }
        }


    }
}

//https://habrahabr.ru/company/microsoft/blog/351622/