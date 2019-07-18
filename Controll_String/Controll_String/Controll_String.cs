using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Controll_String
{
    class Controll_String
    {
        static void Main(string[] args)
        {
            //print_01(); //String 문자열 가지고 놀기 - 지정된 문자(열) 찾기, 바꾸기
            //print_02(); //문자열 변형
            //print_03(); //문자열 쪼개기
            print_04();

        }

        static void print_01()
        {
            string greeting = "Good Morning";

            WriteLine(greeting);
            WriteLine();

            //IndexOf() - 찾고자 하는 지정된 문자(열)이 시작하는 첫번째 index반환
            WriteLine("IndexOf 'Good' : {0}", greeting.IndexOf("Good"));
            WriteLine("IndexOf 'o' : {0}", greeting.IndexOf('o'));
            WriteLine();

            //LastIndexOf() - 문자열에서 착고자 하는 문자열이 마지막으로 등장하는 위치에 대한 index를 반환
            WriteLine("LastIndexOf 'Good' : {0}", greeting.LastIndexOf("Good"));
            WriteLine("LastIndexOf 'o' : {0}", greeting.LastIndexOf('o'));
            WriteLine();

            //StartWith() - 지정된 문자열로 시작하는지 true, false 반환
            WriteLine("StartWith 'Good' : {0}", greeting.StartsWith("Good"));
            WriteLine("StartWith 'Morning : {0}", greeting.StartsWith("Morning"));
            WriteLine();

            //EndWith() - 지정된 문자열로 끝나는지 true, false 반환
            WriteLine("EndWith 'Morning' : {0}", greeting.EndsWith("Morning"));
            WriteLine("EndWith 'Good' : {0}", greeting.EndsWith("Good"));
            WriteLine();

            //Contains() - 지정된 문자(열)이 포함돼 있는지 true, false 반환
            WriteLine("Contains 'Evening' : {0}", greeting.Contains("Evening"));
            WriteLine("Contains 'Morning' : {0}", greeting.Contains("Morning"));
            WriteLine();

            //Replace() - 지정된 문자(열)을 다른 문자(열)로 변환 후, 변환된 문자열 전체 출력
            WriteLine("Replace 'Morning' with 'Evening' : {0}", greeting.Replace("Morning", "Evening"));
            WriteLine();



        }

        static void print_02()
        {
            //ToLower() & ToUpper()
            WriteLine("ToLower() : {0}", "ABC".ToLower());
            WriteLine("ToUpper() : {0}", "def".ToUpper());
            WriteLine();

            //Insert()
            string s = "Happy Friday!";
            WriteLine(s);
            WriteLine("Insert() : {0}", s.Insert(6, "Sunny "));
            WriteLine();

            //Remove()
            WriteLine("Remove() : {0}", s.Remove(0, 6));

            //Trim() 문자열 맨 앞과 맨 뒤만, TrimStart() 문자열 맨 앞만, TrimEnd() 문자열 맨 뒤만 삭제
            WriteLine("Trim() : '{0}'", " No Spaces  ".Trim());
            WriteLine("TrimStart() : '{0}'", " No Spaces ".TrimStart());
            WriteLine("TrimEnd() : '{0}'", " No Spaces ".TrimEnd());
        }

        static void print_03()
        {
            //SubString() 시작 구간과 끝 구간을 지정하여 문자열 출력
            string greeting = "Good Morning";
            WriteLine(greeting);
            WriteLine("Substring() : {0}", greeting.Substring(0, 5));
            WriteLine("SubString() : {0}", greeting.Substring(5));

            //Split() 문자열을 지정한 구문으로 나누어 문자열의 배열을 반환
            string[] arr = greeting.Split(' ');
            WriteLine("Word Count : {0}", arr.Length);
            foreach(string elements in arr)
            {
                WriteLine("{0}", elements);
            }
        }

        static void print_04()
        {
            //문자열의 서식을 맞추기
            //string.Format() 메소드 사용(= Console.WriteLine() 메소드와 사용법 동일)
            //WriteLine("Grammer {항목 순서(첨자), 왼쪽/오른쪽 맞춤 : 서식 문자열}, 문자~"
            //왼쪽 오른쪽 맞춤  '-/+',  '-'는 왼쪽부터 채워 넣기 '+'는 오른쪽부터 채워넣기

            string fmt = "{0,-20}{1,-15}{2, 30}";
            WriteLine(fmt, "Publisher", "Author", "Title");
            WriteLine(fmt, "Marvel", "Stan Lee", "Iron Man");
            WriteLine(fmt, "Hanbit", "SeongHyun Jang", "C# 7.0 Programming");
            WriteLine(fmt, "Prentice Hall", "K&R", "The C Programming Language");
        }
    }
}
