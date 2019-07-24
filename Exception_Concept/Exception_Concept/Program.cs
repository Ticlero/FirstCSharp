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
            //print_02(); //예외 처리2
            //print_03(); //사용자 지정 예외처리
            //print_04(); //조건을 넣어 예외 처리에 필터링 하기

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
                Console.WriteLine("0x{0,-8:X8}", MergeARGB(255, 111, 111, 111));
                Console.WriteLine("0x{0,-8:X8}", MergeARGB(1, 65, 192, 128));
                Console.WriteLine("0x{0,-8:X8}", MergeARGB(0, 255, 255, 300));
            }catch(MyException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Argument:{e.Argument}, Range: {e.Range}");
            }
        }

        static void print_04()
        {
            Console.Write("Please Enter a number(range 0~10)>>");
            string input = Console.ReadLine();

            try
            {
                int num = Int32.Parse(input);
                if(num <0 || num>10)
                {
                    throw new FilterableException()
                    {
                        ErrorNo = num
                    };
                }
                else
                {
                    Console.WriteLine($"you inputted Num::  {num}");
                }
            }catch(FilterableException e) when (e.ErrorNo < 0)
            {
                Console.WriteLine("You inputted number is negative range");
            }catch(FilterableException e) when (e.ErrorNo >10)
            {
                Console.WriteLine("You inputted number is this program is not allowed");
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
                        Range = "0~255"
                    };
            }
            Console.WriteLine($"test:: 0x{red,-8:X8}");
            return (alpha << 24 & 0xFF000000) | (red << 16 & 0x00FF0000) | (green << 8 & 0x0000FF00) | (blue & 0x000000FF);
        } //사용자 지정 예외처리 클래스

        class FilterableException : Exception
        {
            public int ErrorNo { get; set; }
        }
    }
}

