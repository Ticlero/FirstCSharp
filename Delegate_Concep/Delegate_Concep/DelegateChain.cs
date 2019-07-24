using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Concept
{
    public delegate void Notify(string msg);

    class DelegateChain
    {

    }
    class Notifier
    {
        public Notify notifier;
    }

    class EventListener
    {
        public string Name
        {
            get;
            set;
        }

        public void SomethingHappend(string msg)
        {
            Console.WriteLine($"{Name}.SomethingHappend : {msg}");
        }
    }

    
}
