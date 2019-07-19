using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;

namespace Controll_String
{
    class Controll_String
    {
        public int member = 10;
        static void Main(string[] args)
        {
            print_01(); //String 문자열 가지고 놀기 - 지정된 문자(열) 찾기, 바꾸기
            //print_02(); //문자열 변형
            //print_03(); //문자열 쪼개기
            //print_04(); // Format 서식화
            //print_05(); //숫자 서식화
            //print_06(); //날짜 서식화 System.Globalization.CultureInfo 클래스 도움을 통해 날짜 및 시간  서식 통제가능
            //print_07(); //문자열 보간 - C# 6.0이상 ver 부터! (vs string.Format())
            //print_08(); //Nullabale을 이용한 객체 접근 Null 조건부 연산자
            //print_09(); //시프트 연산자
            //print_10(); //논리 연산자
            //print_11(); //Null 병합 연산자
            //print_12(); //
            //print_13(); //간단한 별 찍기
            //print_14(); //간단한 별 찍기2

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
            foreach (string elements in arr)
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

        static void print_05()
        {
            //D 10진수
            WriteLine("10진수: {0:D}", 123);
            WriteLine("10진수: {0:D5}\n", 123);

            //X 16진수
            WriteLine("16진수: {0:X}", 0xFF1234);
            WriteLine("16진수: {0:X8}\n", 0xFF1234);

            //N 숫자
            WriteLine("숫자: {0:N}", 123456789);
            WriteLine("숫자: {0:N0}\n", 123456789); //0은 소수점 이하를 제거

            //F 고정소수점
            WriteLine("고정소수점: {0:F}", 123.45);
            WriteLine("고성소수점: {0:F8}\n", 123.456); //F뒤에 오는 숫자는 소수점이하의 자릿수

            //E: 공학용
            WriteLine("공학: {0:E}", 123.456789);
        }

        static void print_06()
        {
            DateTime dt = new DateTime(2018, 11, 3, 23, 18, 22); //사용자 지정 날짜 서식
            CultureInfo ciEn = new CultureInfo("en-US"); //영어 시간
            CultureInfo ciKr = new CultureInfo("ko-KR"); //한국언어 시간
            WriteLine("{0}", dt);

            //12시간 형식
            WriteLine("12시간 형식: {0:yyyy-MM-dd tt hh:mm:ss (ddd)}", dt); //tt 오전&오후 ddd 요일
            //24시간 형식
            WriteLine("24시간 형식: {0:yyyy-MM-dd tt HH:mm:ss (dddd)}", dt);

            //미국언어 시간
            WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciEn));
        }

        static void print_07()
        {
            int n = 123;
            string s = "최강한화";
            WriteLine($"{123},{"최강한화"}");
            WriteLine($"{123,-10:D5}");
            WriteLine($"{n},{s}");
            WriteLine($"{(n > 123 ? "크다" : "작다")}"); // 논리 ? 참 : 거짓
            WriteLine();

            string name = "김튼튼";
            int age = 28;
            WriteLine($"{name,-10}, {age:D3}");

            name = "이비실";
            age = 17;
            WriteLine($"{name},{(age > 20 ? "성인" : "미성년")}");
        }

        static void print_08()
        {
            Controll_String cs = null;
            Controll_String cs2 = new Controll_String();
            cs2.member = 10;
            int? bar;
            if (cs == null)
                bar = null;
            else
                bar = cs.member;

            WriteLine(bar);

            bar = cs2?.member; //cs?는 cs객체가 널이 아니면 멤버변수에 접근

            WriteLine(bar);

            //'?[]'을 이용한 배열과 같은 컬렉션 객체 사용

            ArrayList a = null;
            WriteLine("ArrayList 객체인 a 에Null 객체 생성");
            a?.Add("야구");
            a?.Add("축구");
            WriteLine($"Count: {a?.Count}");
            WriteLine($"{a?[0]}");
            WriteLine($"{a?[1]}");

            WriteLine("ArrayList 객체인 a 에 ArrayList 객체 생성");
            a = new ArrayList();
            a?.Add("야구");
            a?.Add("축구");
            WriteLine($"Count: {a?.Count}");
            WriteLine($"{a?[0]}");
            WriteLine($"{a?[1]}");
        }

        static void print_09()
        {
            WriteLine("Testing <<...");

            int a = 1;
            WriteLine("a     :{0:D5} (0x{0:X8})", a);
            WriteLine("a << 1:{0:D5} (0x{0:X8})", a << 1);
            WriteLine("a << 2:{0:D5} (0x{0:X8})", a << 2);
            WriteLine("a << 5:{0:D5} (0x{0:X8})", a << 5);

            int b = 255;
            WriteLine("\nTesting >>...");
            WriteLine("b     :{0:D5} (0x{0:X8})", b);
            WriteLine("b >> 1:{0:D5} (0x{0:X8})", b >> 1);
            WriteLine("b >> 2:{0:D5} (0x{0:X8})", b >> 2);
            WriteLine("b >> 5:{0:D5} (0x{0:X8})", b >> 5);

            int c = -255;
            WriteLine("\nTesting >>...");
            WriteLine("c     :{0:D5} (0x{0:X8})", c);
            WriteLine("c >> 1:{0:D5} (0x{0:X8})", c >> 1);
            WriteLine("c >> 2:{0:D5} (0x{0:X8})", c >> 2);
            WriteLine("c >> 5:{0:D5} (0x{0:X8})", c >> 5);
        }

        static void print_10()
        {
            int a = 9;
            int b = 10;

            WriteLine($"{a} & {b} = {a & b}");
            WriteLine($"{a} | {b} = {a | b}");
            WriteLine($"{a} ^ {b} = {a ^ b}");

            int c = 255;
            WriteLine("~{0}(0x{0:X8}) : {1}(0x{1:X8})", c, ~c);
        }

        static void print_11()
        {
            int? a = null;
            WriteLine($"{a ?? 0}");
            a = 99;
            WriteLine($"{a ?? 0}");

            string str = null;
            WriteLine($"{str ?? "Default"}");
            str = "spring";
            WriteLine($"{str ?? "Default"}");

        }

        static void print_12()
        {
            int a = 0xF0 | 0x0F;
            int b = -255;
            WriteLine($"{a}");
            WriteLine($"{b:X}");
        }

        static void print_13()
        {
            /*
            for(int i=0; i<5; i++)
            {
                for(int j=0; j<i+1; j++)
                {
                    Write("{0}", '*');
                }
                WriteLine();
            }


            for(int y=5; y>0; y--)
            {
                for(int k=0; k<y;k++)
                {
                    Write("{0}", '*');
                }
                WriteLine();
            }
            */
            int i = 5;
            int j = 0;
            /*
            while (i<5)
            {
                while(j<i+1)
                {
                    Write("{0}", '*');
                    j++;
                }
                WriteLine();
                i++;
                j = 0;
            }
            
            while(i>0)
            {
                while(j<i)
                {
                    Write("{0}", '*');
                    j++;
                }
                WriteLine();
                i--;
                j = 0;
            }
            */
        }

        static void print_14()
        {
            int count = 0;
            while (true)
            {
                Write("반복 횟수를 입력해주세요: ");
                count = int.Parse(Console.ReadLine());
                if (count <= 0)
                { 
                    WriteLine("0보다 작거나 같은 수는 입력할 수 없습니다.");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < i + 1; j++)
                        {
                            Write("{0}", '*');
                        }
                        WriteLine();
                    }
                    break;
                }
            }



        }
    }
}
