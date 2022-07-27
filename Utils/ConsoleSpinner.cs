using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Utils
{
    class ConsoleSpinner
    {
        private Thread _t;
        private string _msg = "";
        private int _tid = 0;
        public bool started { get; set; }
        public void Start(string message)
        {
            _tid = Thread.CurrentThread.ManagedThreadId;
            started = true;
            _msg = message;
            _t = new Thread(new ThreadStart(Loop));
            _t.Priority = ThreadPriority.Lowest;
            _t.Start();
        }
        public static T Wrap<T>(Func<T> work, string msg)
        {
            //return work();
            T ret;
            ConsoleSpinner cs = new ConsoleSpinner();
            try
            {
                cs.Start(msg);
                ret = work();
                cs.Stop();
            }
            catch
            {
                if (cs.started)
                    cs.Stop();
                try { cs = null; }
                catch { }
                throw;
            }
            return ret;
        }


        public static void WrapAction(Action work, string msg)
        {
            ConsoleSpinner cs = new ConsoleSpinner();
            try
            {
                cs.Start(msg);
                work();
                cs.Stop();
            }
            catch
            {
                if (cs.started)
                    cs.Stop();
                try { cs = null; }
                catch { }
                throw;
            }

        }

        private void Loop()
        {
            try
            {
                //Console.WriteLine(string.Format("[{0}-{1}]", _tid,_msg));
                Console.WriteLine(_msg);
                while (_t != null)
                {
                    //Console.Write(string.Format("({0})",_tid));
                    Console.Write(".");
                    Thread.Sleep(250);
                    if (_t == null || _t.ThreadState != ThreadState.Running || !started)
                        break;
                }
            }
            catch { }
        }
        public void Stop()
        {
            try
            {
                started = false;
                _t.Abort();
            }
            catch { }
        }
    }
}
