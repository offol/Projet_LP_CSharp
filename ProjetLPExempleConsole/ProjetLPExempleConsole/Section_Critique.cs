using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetLPExempleConsole
{
    public class Section_Critique
    {
        // Exemple de lock**********************************************************
        //Témoin du lock
        private static Object _lock = new object();

        private static bool _quitter = false;

        public void Exemple_lock()
        {

            while (!_quitter)
            {
                lock (_lock)
                {
                    //code
                }

                Thread.Sleep(250);
            }

        }
        //************************************************************************

        //Exemple de Mutex ******************************************************
        private static Mutex _mux = new Mutex();

        public void Exemple_Mutex()
        {
            while (!_quitter)
            {
                _mux.WaitOne();

                //code

                _mux.ReleaseMutex();

                Thread.Sleep(250);
            }
        }
        //******************************************************************

        //Exemple de Semaphore *********************************************

        //le 3 signifie que trois threads peuvent passer en même temps
        private SemaphoreSlim _semaph = new SemaphoreSlim(3);

        public void Exemple_Semaphore()
        {
            _semaph.Wait();

            //code

            _semaph.Release();
        }
        //********************************************************************
    }
}
