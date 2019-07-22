using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace_Abstrat
{
    class Property
    {
        public Property()
        {
            BirthdayInfo birth = new BirthdayInfo();
            birth.Name = "성현";
            birth.Birthday = new DateTime(1992, 05, 16);

            Console.WriteLine($"Name: {birth.Name}");
            Console.WriteLine($"Birthday: {birth.Birthday.ToShortDateString()}");
            Console.WriteLine($"Age: {birth.Age}");
        }
    }

    class BirthdayInfo
    {

        public string Name
        {
            get;

            set;

        }

        public DateTime Birthday
        {
            get;
            set;

        }

        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
            }
        }
    }
}
