using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            //print_01(); //예외 처리
            //print_02(); //
            print_03();
        }

        static void print_01()
        {
            int[] arr = new int[3] { 1, 2, 3 };

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"arr[{i}]: {arr[i]} ");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"\n벗어난 범위에 접근하려 하고 있습니다. Setted Size:{arr.Length}");
                Console.Write("\n종료");
            }

        }

        static void print_02()
        {
            try
            {
                int? a = null;
                int b = a ?? throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                int[] arr = new int[] { 1, 2, 3 };
                int index = 4;
                int value = arr[index > 0 && index < 4 ? index : throw new IndexOutOfRangeException()];

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }

        static void print_03()
        {
            try
            {
                Console.WriteLine("0x{0:X}", MergeARGB(255, 111, 111, 111));
                Console.WriteLine("0x{0:X}", MergeARGB(1, 65, 192, 128));
                Console.WriteLine("0x{0:X}", MergeARGB(0, 255, 255, 300));
            }catch(MyException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Argument:{e.Argument}, Range: {e.Rage}");
            }
        }

        static uint MergeARGB(uint alpha, uint red, uint green, uint blue)
        {
            uint[] args = new uint[] { alpha, red, green, blue };

            foreach (uint arg in args)
            {
                if (arg > 255)
                    throw new MyException()
                    {
                        Argument = arg,
                        Rage = "0~255"
                    };
            }

            return (alpha << 24 & 0xFF000000) | (red << 16 & 0x00FF00) | (green << 8 & 0x0000FF00) | (blue & 0x000000FF);
        }
    }
}

