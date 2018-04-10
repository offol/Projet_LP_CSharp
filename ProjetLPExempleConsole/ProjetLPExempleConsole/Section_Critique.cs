using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetLPExempleConsole
{
    public static class Section_Critique
    {
        // Exemple de lock**********************************************************
        //Témoin du lock
        private static Object _lock = new object();

        public static bool _quitter = false;

        public static void Exemple_lock()
        {

            while (!_quitter)
            {
                lock (_lock)
                {
                    Console.WriteLine("Passage dans le lock");
                    Console.WriteLine("Thread #: " + Thread.CurrentThread.ManagedThreadId + " sort");
                }

                Thread.Sleep(250);
            }

        }
        //************************************************************************

        //Exemple de Mutex ******************************************************
        private static Mutex _mux = new Mutex();

        public static void Exemple_Mutex()
        {
            while (!_quitter)
            {
                _mux.WaitOne();


                Console.WriteLine("Passage dans le Mutex");
                Console.WriteLine("Thread #: " + Thread.CurrentThread.ManagedThreadId + " sort");

                _mux.ReleaseMutex();

                Thread.Sleep(250);
            }
        }
        //******************************************************************

        //Exemple de Semaphore *********************************************

        //le 3 signifie que trois threads peuvent passer en même temps
        private static SemaphoreSlim _semaph = new SemaphoreSlim(2);

        public  static void Exemple_Semaphore()
        {
            while (!_quitter)
            {
                _semaph.Wait();

                Console.WriteLine("Passage dans la Semaphore");
                Console.WriteLine("Thread #: " + Thread.CurrentThread.ManagedThreadId + " sort");

                _semaph.Release();
            }
        }
        //********************************************************************
    }
}
