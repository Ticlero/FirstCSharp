using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread_Concept
{
    class WaitPulse
    {
        const int LOOP_COUNT = 100;

        readonly object thisLock;
        bool lockedCount = false;

        private int count;

        public int Count
        { get { return count; } }

        public WaitPulse()
        {
            thisLock = new object();
            count = 0;
        }

        public void Increase()
        {
            int loopCount = LOOP_COUNT;
            while(loopCount-- >0)
            {
                lock(thisLock)
                {
                    while(count > 0 || lockedCount ==true)
                    {
                        Monitor.Wait(thisLock);
                    }

                    lockedCount = true;
                    count++;
                    Console.WriteLine("count++"+count);
                    lockedCount = false;

                    Monitor.Pulse(thisLock);
                }
            }
        }

        public void Decrease()
        {
            int loopCount = LOOP_COUNT;
            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    while (count < 0 || lockedCount == true)
                    {
                        Monitor.Wait(thisLock);
                    }

                    lockedCount = true;
                    count--;
                    Console.WriteLine("count-- "+count);
                    lockedCount = false;

                    Monitor.Pulse(thisLock);
                }
            }
        }
    }
}
