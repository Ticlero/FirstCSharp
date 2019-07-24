using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_training
{
    class Program
    {
        //데이터에 질의를 하여 필요한 데이터를 뽑아내는 문법!!
        //LINQ의 대표적 표준 연산자 from, where, oderby, select
        //LINQ의 시작은 반드시 from -IEnumerable을 상속받은 객체만 가능 즉, foreach문으로 표현 가능한 데이터만 가능!
        //from (범위변수) in (data원본)
        //where 뽑아내고 싶은 데이터의 조건
        //orderby 원하는 데이터를 지정하여 오름차 내림차 정렬
        //select
        static void Main(string[] args)
        {
            print_01();
        }

        static void print_01()
        {
            int[] arr = { 9, 8, 7, 98, 76, 5, 4, 3, 54, 32, 2, 1 };
            var result = from n in arr
                         where n % 2 == 0
                         orderby n ascending //or descending
                         select n;

            foreach(int n in result)
            {
                Console.WriteLine($"짝수: {n}");
            }

            Nullable<DateTime> d = null;
            
        }
    }
}
