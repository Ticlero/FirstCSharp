using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace Thread_Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            //print_02();
            //print_03(); 스레드의 상태 확인
            //print_04();
            //print_05();
            //print_06();
            //print_07();
            //string[] arg = new string[] { "a.txt" };
            //print_08(arg);
            //print_09();
            print_10();
        }


        static void print_01()
        {
            Thread thread = new Thread(new ThreadStart(DoSomeThing));
            thread.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main: {i}");
                Thread.Sleep(100);
            }

            Console.WriteLine("Wating until thread stop");
            thread.Join();

            Console.WriteLine("Finished");
        }

        static void print_02()
        {
            SideTask st = new SideTask(100);
            Thread t1 = new Thread(st.KeepAlive);

            t1.IsBackground = false;

            Console.WriteLine(t1.ThreadState);

            Console.WriteLine("Starting Thread....");
            t1.Start();

            Thread.Sleep(1000);
            Console.WriteLine(t1.ThreadState);
            Console.WriteLine("Aborting thread");
            t1.Abort();

            Console.WriteLine(t1.ThreadState);
            Console.WriteLine("Wating until thread Stop");
            t1.Join();
            Console.WriteLine(t1.ThreadState);
            Console.WriteLine("Finished");

        }

        static void print_03()
        {
            PrintThreadState(ThreadState.Running);
            PrintThreadState(ThreadState.StopRequested);
            PrintThreadState(ThreadState.SuspendRequested);
            PrintThreadState(ThreadState.Background);
            PrintThreadState(ThreadState.Unstarted);
            PrintThreadState(ThreadState.Stopped);
            PrintThreadState(ThreadState.WaitSleepJoin);
            PrintThreadState(ThreadState.Suspended);
            PrintThreadState(ThreadState.AbortRequested);
            PrintThreadState(ThreadState.Aborted);
            PrintThreadState(ThreadState.Aborted | ThreadState.Stopped);
            
        }

        static void print_04()
        {
            SideTask st = new SideTask(100);
            Thread t1 = new Thread(st.KeepAlive2);
            t1.IsBackground = false;
            Console.WriteLine("Starting thread");
            t1.Start();

            Thread.Sleep(1000);

            Console.WriteLine("Interruping thread");
            t1.Interrupt();

            Console.WriteLine("Wating untill thread stops");
            t1.Join();

            Console.WriteLine("Finished");
        }

        static void print_05()
        {
            Synchronize counter = new Synchronize();
            Thread incThread = new Thread(counter.Increase);
            Thread decThread = new Thread(counter.Decrease);

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            Console.WriteLine(counter.Count);
        }

        static void print_06()
        {
            Synchronize counter = new Synchronize();
            Thread incThread = new Thread(counter.Increase);
            Thread decThread = new Thread(counter.Decrease);

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            Console.WriteLine(counter.Count);
        }

        static void print_07()
        {
            WaitPulse counter = new WaitPulse();
            Thread t1 = new Thread(counter.Increase);
            Thread t2 = new Thread(counter.Decrease);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(counter.Count);
        }

        static void print_08(string[] args)
        {
            string srcFile = args[0];
            Action<object> FileCopyAction = (object state) =>
            {
                string[] paths = (string[])state;
                File.Copy(paths[0], paths[1]);

                Console.WriteLine("TaskID: {0}, ThreadID: {1}, {2} was copied to {3}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, paths[0], paths[1]);
            };

            Task t1 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy1" });
            Task t2 = Task.Run(() => FileCopyAction(new string[] { srcFile, srcFile + ".copy2" }));

            t1.Start();

            Task t3 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy3" });
            t3.RunSynchronously();

            t1.Wait();
            t2.Wait();
            t3.Wait();

           
        }

        static void print_09()
        {
            Console.WriteLine("시작범위를 입력해주세요>>");
            long from = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("범위의 마지막을 입력해주세요>>");
            long to = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("테스크의 수를 입력해주세요>>");
            int taskCount = Convert.ToInt32(Console.ReadLine());

           

            Func<object, List<long>> FindPrimeNum = (objRange) =>
            {
                long[] range = (long[])objRange;
                List<long> found = new List<long>();

                for(long i = range[0]; i< range[1]; i++)
                {
                    if (IsPrime(i))
                        found.Add(i);
                }
                return found;
            };
            
            Task<List<long>>[] tasks = new Task<List<long>>[taskCount];
            long currentFrom = from;
            long currentTo = to / tasks.Length;

            for(int i=0; i< tasks.Length; i++)
            {
                Console.WriteLine("Task[{0}] : {1} ~ {2}", i, currentFrom, currentTo);

                tasks[i] = new Task<List<long>>(FindPrimeNum, new long[] { currentFrom, currentTo });

                currentFrom = currentTo + 1;

                if (i == tasks.Length - 2)
                    currentTo = to;
                else
                    currentTo = currentTo + (to / tasks.Length);
            }

            Console.WriteLine("Plaese press enter to start");
            Console.ReadLine();
            Console.WriteLine("Started..");

            DateTime startTime = DateTime.Now;

            foreach(Task<List<long>> task in tasks)
            {
                task.Start();
            }

            List<long> total = new List<long>();

            foreach(Task<List<long>> task in tasks)
            {
                task.Wait();
                total.AddRange(task.Result.ToArray());
            }

            DateTime endTime = DateTime.Now;

            TimeSpan ellapsed = endTime - startTime;

            Console.WriteLine("Pirme number count between {0} and {1} , {2}", from, to, total.Count);

            Console.WriteLine("Ellapsed time : {0}", ellapsed);
        }

        static void print_10()
        {
            Console.WriteLine("시작범위를 입력해주세요>>");
            long from = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("범위의 마지막을 입력해주세요>>");
            long to = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Plaese press enter to start");
            Console.ReadLine();
            Console.WriteLine("Started..");

            DateTime startTime = DateTime.Now;
            List<long> total = new List<long>();

            Parallel.For(from, to, i =>
            {

                if (IsPrime(i))
                    total.Add(i);

            });

            DateTime endTime = DateTime.Now;

            TimeSpan ellapsed = endTime - startTime;
            Console.WriteLine("Pirme number count between {0} and {1} , {2}", from, to, total.Count);

            Console.WriteLine("Ellapsed time : {0}", ellapsed);

        }

        static void DoSomeThing()
        {
            for(int i=0; i< 5; i++)
            {
                Console.WriteLine("DoSomeThing : {0}", i);
                Thread.Sleep(100);
            }
        }

        static void PrintThreadState(ThreadState state)
        {
            Console.WriteLine("{0, -16} : {1}", state, (int)state);
        }

        static bool IsPrime(long number)
        {
            if (number < 2)
                return false;
            if(number % 2 == 0 && number != 2)
            {
                return false;
            }

            for(int i=2; i< number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }

    class SideTask
    {
        int count;
        public SideTask(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {
            try
            {
                while(count > 0)
                {
                    Console.WriteLine($"{count--} left");
                    Thread.Sleep(100);
                }
            }catch(ThreadAbortException e)
            {
                Console.WriteLine(e);
                Thread.ResetAbort();
            }
            finally
            {
                Console.WriteLine("Clearing resource");
            }
        }

        public void KeepAlive2()
        {
            try
            {
                Console.WriteLine("Running thread isn't gonna be interrupted");
                Thread.SpinWait(100000000);

                while (count>0)
                {
                    Console.WriteLine($"{count--} left");
                    Console.WriteLine("Entering into WaitJoinSleep State...");
                    Thread.Sleep(100);
                }
                Console.WriteLine("Count: 0");
            }catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e);
            }finally
            {
                Console.WriteLine("Clearing Resource");
            }
        }
    }

    class Synchronize
    {
        const int LOOP_COUNT = 100;

        readonly object thisLock;

        private int count;
        public int Count
        {
            get { return count; }
        }

        public Synchronize()
        {
            thisLock = new object();
            count = 0;
        }

        public void Increase()
        {
            int loopcount = LOOP_COUNT;
            while(loopcount-- > 0)
            {
                lock(thisLock)
                {
                    count++;
                }
                Thread.Sleep(1);
            }
        }

        public void Decrease()
        {
            int loopcount = LOOP_COUNT;
            while(loopcount-- > 0)
            {
                lock(thisLock)
                {
                    count--;
                }
                Thread.Sleep(1);
            }
        }


        public void Increase2()
        {
            int loopcount = LOOP_COUNT;
            while (loopcount-- > 0)
            {
                Monitor.Enter(thisLock);
                try
                {
                    count++;
                }finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }

        public void Decrease2()
        {
            int loopcount = LOOP_COUNT;
            while (loopcount-- > 0)
            {
                Monitor.Enter(thisLock);
                try
                {
                    count--;
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }
    }
}
