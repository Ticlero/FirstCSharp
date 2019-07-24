using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramda_Funtion
{
    class FriendList
    {
        private List<string> list = new List<string>();

        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);

        public void PrintAll()
        {
            foreach (object eles in list)
            {
                Console.WriteLine(eles);
            }
            
        }
        public FriendList() => Console.WriteLine("Friend List()");
        ~FriendList() => Console.WriteLine("~Friend List()");

        //public int Capacity => list.Capacity  읽기전용
        
        public int Capacity
        {
            get => list.Capacity;
            set => list.Capacity = value;
        }

        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }
}
