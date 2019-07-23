using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            //print_01(); //generic method
            print_02();
        }

        static void print_01()
        {
            int[] arr_01 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arr_02 = new int[arr_01.Length];

            CopyArray<int>(arr_01, arr_02);

            foreach (int eles in arr_02)
            {
                Console.Write(eles + " ");
            }
            Console.WriteLine();
        }

        static void print_02()
        {
            Generic_Class<string> str_list = new Generic_Class<string>();
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";
            str_list[5] = "pqr";
            str_list[6] = "stu";
            str_list[7] = "vwx";
            str_list[8] = "yz";

            for(int i = 0; i < str_list.Length; i++)
            {
                Console.WriteLine(str_list[i]);
            }
        }

        static void CopyArray<T>(T[] source, T[] target)
        {
            for(int i=0; i<source.Length; i++)
            {
                target[i] = source[i];
            }
        } //generic method
    }


    class Generic_Class<T> //Generic_Class
    {
        private T[] array;

        public Generic_Class()
        {
            array = new T[3];
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }

            set
            {
                if(index>=array.Length)
                {
                    Array.Resize<T>(ref array, index+1);
                    Console.WriteLine($"Array Resized : {array.Length}");
                }
                array[index] = value;
            }
        }

        public int Length
        {
            get { return array.Length; }
        }
    }



}
