using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_example
{
    public static class Extendmethod //확장 메소드 public static class 클래스이름
    {

        public static int Power(this int myint, int a) //확장 메소드  public static 반환형식 메소드이름(this <확장하고자 하는 클래스 또는 형식> 식별자, 매개변수)
        {
            int power = 1;
            for(int i=0; i < a; i++)
            {
                power = power * myint;
            }
            return power;
        }

        public static string Append(this string myString, string apped)
        {
            return myString + apped;
        }

        public static int Squre(this int myInt)
        {
            return myInt * myInt;
        }
    }
}
