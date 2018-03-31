using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetLPExempleConsole
{
    class Program
    {
        private static List<Tuple<double,int>> resultList = new List<Tuple<double, int>>();

        private static List<MonObjet> maliste = new List<MonObjet>()
        {
            new MonObjet("Bob", "5 des pedrix", "819-534-6346", 28),
            new MonObjet("George", "8 rue de quelque chose", "819-234-7653", 108),
            new MonObjet("Timoter", "19 boulevard de l'épervier", "819-262-4564", 36)

        };

        private static List<double> inputList = new List<double>() {
            2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26
        };

        static string[] testArray =
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

        static void Main(string[] args)
        {
            Console.WriteLine("Écrire un numéro de 1 a 5");
            for (int i = 1; i <= 5; i++)
            {
                ConsoleKeyInfo cki;
                cki = Console.ReadKey(true);

                if (Int32.TryParse(cki.KeyChar.ToString(), out int num))
                {
                    if (Int32.Parse(cki.KeyChar.ToString()) == 1)
                    {
                        //Exemple de Task
                        Task task1 = new Task(new Action(Test2));

                        Task task2 = new Task(new Action(Test));

                        task1.Start();
                        task2.Start();
                    }
                    else if (Int32.Parse(cki.KeyChar.ToString()) == 2)
                    {
                        //Exemple de Parallel invoke
                        ParallelInvoke();
                    }
                    else if (Int32.Parse(cki.KeyChar.ToString()) == 3)
                    {
                        Console.WriteLine("Start Foreach exemple");

                        foreach(var item in testArray)
                        {
                            Console.WriteLine("{0}, Thread Id= {1}", item, Thread.CurrentThread.ManagedThreadId);
                        };

                        Console.WriteLine("Fin de la boucle foreach");

                        //Exemple de  Parallel foreach
                        Parallel.ForEach<string>(testArray, item =>
                        {
                            //Faire quelque chose au élément de la liste
                            Console.WriteLine("{0}, Thread Id= {1}", item, Thread.CurrentThread.ManagedThreadId);
                        });

                        Console.WriteLine("End Foreach exemple");
                    }
                    else if (Int32.Parse(cki.KeyChar.ToString()) == 4)
                    {
                        Console.WriteLine("Start For exemple");

                        for (int y = 0; y <= 10; y++)
                        {
                            Console.WriteLine("{0}, Thread Id= {1}", testArray[y], Thread.CurrentThread.ManagedThreadId);
                        };

                        Console.WriteLine("Fin de la boucle For");

                        //Exemple de Parallel for loop
                        Parallel.For(0, 11, index =>
                        {
                            Console.WriteLine("{0}, Thread Id= {1}", testArray[index], Thread.CurrentThread.ManagedThreadId);
                        });

                        Console.WriteLine("End For exemple");
                    }
                    else if (Int32.Parse(cki.KeyChar.ToString()) == 5)
                    {
                        Console.WriteLine("Start PLINQ exemple");

                        //Exemple de PLINQ
                        resultList = inputList.AsParallel().Select(val => new Tuple<double, int> ((val / 8), Thread.CurrentThread.ManagedThreadId)).ToList();

                        foreach (var item in resultList)
                        {
                            Console.WriteLine("Résulat: " + item.Item1 + "\t Thread: "+ item.Item2);
                        }

                        Console.WriteLine("End PLINQ exemple");
                    }
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static async void Test()
        {
            Console.WriteLine("Start Test");
            for (int i = 0; i <= 15; i++)
            {
                Console.WriteLine(i + 10);
                await Task.Delay(TimeSpan.FromSeconds(0.5));
            }

            Console.WriteLine("End Test");
        }

        private async static void Test2()
        {
            Console.WriteLine("Start Test2");
            for (int i = 0; i <= 15; i++)
            {
                Console.WriteLine("bla" + i);
                await Task.Delay(TimeSpan.FromSeconds(0.5));
            }

            Console.WriteLine("End Test2");
        }

        private static void ParallelInvoke()
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
