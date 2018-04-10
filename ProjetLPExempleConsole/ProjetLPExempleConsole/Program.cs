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
        private static bool _quitter = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Écrire un chiffre de 1 a 5");
            Console.WriteLine("1. Exemple task");
            Console.WriteLine("2. Exemple Invoke");
            Console.WriteLine("3. Exemple ForEach");
            Console.WriteLine("4. Exemple For");
            Console.WriteLine("5. Exemple PLinq");
            Console.WriteLine("Q. Exit");

            while (!_quitter)
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
                        Exemple_Parallel.Exemple_invoke();
                    }
                    else if (Int32.Parse(cki.KeyChar.ToString()) == 3)
                    {
                        //Exemple foreach
                        Exemple_Parallel.Exemple_Foreach();
                    }
                    else if (Int32.Parse(cki.KeyChar.ToString()) == 4)
                    {
                        //Exemple for loop
                        Exemple_Parallel.Exemple_For();
                    }
                    else if (Int32.Parse(cki.KeyChar.ToString()) == 5)
                    {
                        //exemple plinq
                        Exemple_Parallel.Exemple_plinq();
                    }


                }
                else if (cki.KeyChar.ToString() == "q" || cki.KeyChar.ToString() == "Q")
                {
                    _quitter = true;
                }

            }

           /* Console.WriteLine("Press any key to exit");
            Console.ReadKey();*/
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

       
    }
}
