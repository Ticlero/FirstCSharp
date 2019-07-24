using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Concept
{
    //delegate callback 만들기
    // 접근한정자 delegate 반환형 이름(매개변수)
    public delegate int Callback_dele(int a, int b); //대리자 선언
    public delegate int Compare(int a, int b);
    public delegate int GCompare<T>(T a, T b);
    public delegate int TempCompare(int a, int b);
    public delegate void ThereIsFire(string loc);

    class MyDelegate
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }

        public int AscendCompare(int a, int b)
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }

        public int DescendCompare(int a, int b)
        {
            if (a < b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }

        public void BubbleSort(int[] arr, Compare compare)
        {
            int i = 0;
            int j = 0;
            int temp = 0;
            for (i = 0; i < arr.Length; i++)
            {
                for (j = (i >= arr.Length ? i + 1 : i); j < arr.Length; j++)
                {
                    if (compare(arr[i], arr[j]) > 0)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public void BubbleSort_2(int[] arr, TempCompare compare)
        {
            int i = 0;
            int j = 0;
            int temp = 0;
            for (i = 0; i < arr.Length; i++)
            {
                for (j = (i >= arr.Length ? i + 1 : i); j < arr.Length; j++)
                {
                    if (compare(arr[i], arr[j]) > 0)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public static void Call119(string loc)
        {
            Console.WriteLine("불 났습니다.  {0}건물에", loc);
        }

        public static void ShotOut(string loc)
        {
            Console.WriteLine("피하세요!! {0}에 불이 났습니다.", loc);
        }
        
        public static void Escape(string loc)
        {
            Console.WriteLine("{0}에서 나갑시다.", loc);
        }
    }
}
