using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetLPExempleConsole
{
    public static class Exemple_Parallel
    {
        private static List<Tuple<double, int>> resultList = new List<Tuple<double, int>>();

        private static List<double> inputList = new List<double>() {
            2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26
        };

        private static string[] testArray =
         {
            "1. Vert",
            "2. Rouge",
            "3. Jaune",
            "4. Bleu",
            "5. Orange",
            "6. Mauve",
            "7. Violet",
            "8. Brun",
            "9. Rose",
            "10. Blanc",
            "11. Noir"
        };

        /// <summary>
        /// Exemple de parallel for loop
        /// </summary>
        public static void Exemple_For()
        {
            Console.WriteLine("Start For exemple");

            for (int y = 0; y <= 10; y++)
            {
                Console.WriteLine("{0}, Thread Id= {1}", testArray[y], Thread.CurrentThread.ManagedThreadId);
            };

            Console.WriteLine("Fin de la boucle For \n");

            //Exemple de Parallel for loop
            Parallel.For(0, 11, index =>
            {
                Console.WriteLine("{0}, Thread Id= {1}", testArray[index], Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("End For exemple");
        }
        //***********************************************************************************

        /// <summary>
        /// Exemple foreach loop
        /// </summary>
        public static void Exemple_Foreach()
        {
            Console.WriteLine("Start Foreach exemple");

            foreach (var item in testArray)
            {
                Console.WriteLine("{0}, Thread Id= {1}", item, Thread.CurrentThread.ManagedThreadId);
            };

            Console.WriteLine("Fin de la boucle foreach \n");

            //Exemple de  Parallel foreach
            Parallel.ForEach<string>(testArray, item =>
            {
                //Faire quelque chose au élément de la liste
                Console.WriteLine("{0}, Thread Id= {1}", item, Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("End Foreach exemple");
        }
        //***********************************************************************************

        /// <summary>
        /// Exemple PLINQ
        /// </summary>
        public static void Exemple_plinq()
        {
            Console.WriteLine("Start PLINQ exemple");

            //Exemple de PLINQ
            resultList = inputList.AsParallel().Select(val => new Tuple<double, int>((val / 8), Thread.CurrentThread.ManagedThreadId)).ToList();

            foreach (var item in resultList)
            {
                Console.WriteLine("Résulat: " + item.Item1 + "\t Thread: " + item.Item2);
            }

            Console.WriteLine("End PLINQ exemple");
        }
        //********************************************************************************************************************************************

            /// <summary>
            /// Exemple Parallel Invoke
            /// </summary>
        public static void Exemple_invoke()
        {

            Parallel.Invoke(() =>
            {
                Console.WriteLine("Begin first task...");
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("End First Task");

            },
             () =>
             {
                 Console.WriteLine("Begin second task...");
                 for (int i = 6; i <= 10; i++)
                 {
                     Console.WriteLine(i);
                 }
                 Console.WriteLine("End second Task");

             },
             () =>
             {
                 Console.WriteLine("Begin third task...");
                 for (int i = 11; i <= 15; i++)
                 {
                     Console.WriteLine(i);
                 }
                 Console.WriteLine("End third Task");

             }
             );
            Console.WriteLine("Returned from Parallel.Invoke");
        }
    }
}
