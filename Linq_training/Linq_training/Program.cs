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
            //print_01(); //LINQ 기초 문법
            //print_02(); //LINQ 응용 - select에 따른 형식 변화
            //print_03(); //원본데이터에 여러개의 데이터 질의하기
            //print_04(); //Group by into - 데이터를 그룹화 하여 분류하기
            //print_05(); //join을 이용한 데이터 연결 -내부 조인
            //print_06(); //외부 join을 이용한 데이터 연결
            //print_07();
            print_08();
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

        static void print_02()
        {
            Profile[] arrProfile =
            {
                new Profile(){Name = "정우성", Height=186},
                new Profile(){Name ="김태희", Height = 158},
                new Profile(){Name = "고현정", Height = 172},
                new Profile(){Name = "장성현",  Height = 184}
            };

            var profiles = from profile in arrProfile
                           where profile.Height < 175
                           orderby profile.Height descending
                           select new
                           {
                               Name = profile.Name,
                               Height = profile.Height * 0.393
                           };

            

            foreach(var eles in profiles)
            {
                Console.WriteLine($"{eles.Name}, {eles.Height}Inch");
            }


        }

        static void print_03() //여러개의 데이터 원본에 접근하는 쿼리식
        {
            Profile[] proflie =
            {
                new Profile{Name="해바라기반", Score = new int[] {100,98,79,38,50,88,83,81,43,55}},
                new Profile{Name="장미반", Score = new int[] {99,98,91,60,29,44,100,84,73,69}},
                new Profile{Name="소나무반", Score = new int[] {92, 30, 85, 94, 0, 17, 90 ,80, 100, 100}},
                new Profile{Name="은행나무반", Score = new int[] {100,80,30,20,100,54,98,89,78,77}}
            };

            var classes = from c in proflie
                          from s in c.Score
                          where s < 60
                          orderby c.Name, s ascending
                          select new
                          {
                              Name = c.Name,
                              Lowest = s
                          };
            foreach (var eles in classes)
            {
                Console.WriteLine($"{eles.Name}, {eles.Lowest}");
            }
        }

        static void print_04() //group by 를 이용한 데이터 분류 - "group A by B into C" A: from절에서 뽑아낸 변수, B: 분류 기준, C: 그룹변수
        {
            Profile[] arrProfile =
            {
                new Profile(){Name = "정우성", Height=186},
                new Profile(){Name ="김태희", Height = 158},
                new Profile(){Name = "고현정", Height = 172},
                new Profile(){Name = "장성현",  Height = 184},
                new Profile(){Name = "이문세", Height = 178},
                new Profile(){Name = "하하", Height = 171}
            };

            

            var groupList = from profiles in arrProfile
                            //orderby profiles.Height ascending
                            group profiles by profiles.Height < 175 into g
                            select new
                            {
                                GroupKey = g.Key,
                                Profiles = g,
                            };

            foreach(var group in groupList)
            {
                Console.WriteLine($"- 175 미만? : {group.GroupKey}");
                foreach(var p in group.Profiles)
                {
                    Console.WriteLine($"    {p.Name}, {p.Height}");
                }
            }


        }

        static void print_05()//조인 join a(범위변수) in b(원본데이터) on 조건(연산자 'equals'만 존재
        {
            Profile[] arrProfile =
            {
                new Profile(){Name = "정우성", Height=186},
                new Profile(){Name ="김태희", Height = 158},
                new Profile(){Name = "고현정", Height = 172},
                new Profile(){Name = "장성현",  Height = 184},
                new Profile(){Name = "이문세", Height = 178},
                new Profile(){Name = "하하", Height = 171}
            };

            Profile[] arrProduct =
            {
                new Profile(){Product = "비트", Star="정우성"},
                new Profile(){Product = "CF 다수", Star = "김태희"},
                new Profile(){Product = "아이리스", Star = "김태희"},
                new Profile(){Product = "모래시계", Star ="고현정"},
                new Profile(){Product = "Solo 예찬", Star = "이문세"}
            };

            var joinedList = from p in arrProfile
                             join arrp in arrProduct on p.Name equals arrp.Star
                             orderby p.Name ascending
                             select new
                             {
                                 Name = p.Name,
                                 Work = arrp.Product,
                                 Height = p.Height
                             };

            foreach(var eles in joinedList)
            {
                Console.WriteLine($"{eles.Name,-3}::{eles.Work,-5}::{eles.Height,5}");
            }
        }

        static void print_06() //외부조인
        {
            Profile[] arrProfile =
            {
                new Profile(){Name = "정우성", Height=186},
                new Profile(){Name ="김태희", Height = 158},
                new Profile(){Name = "고현정", Height = 172},
                new Profile(){Name = "장성현",  Height = 184},
                new Profile(){Name = "이문세", Height = 178},
                new Profile(){Name = "하하", Height = 171}
            };

            Profile[] arrProduct =
            {
                new Profile(){Product = "비트", Star="정우성"},
                new Profile(){Product = "CF 다수", Star = "김태희"},
                new Profile(){Product = "아이리스", Star = "김태희"},
                new Profile(){Product = "모래시계", Star ="고현정"},
                new Profile(){Product = "Solo 예찬", Star = "이문세"}
            };


            var exJoinList = from info in arrProfile
                             join p in arrProduct on info.Name equals p.Star into j
                             from product in j.DefaultIfEmpty(new Profile() { Product = "작품없음" })
                             select new
                             {
                                 Name = info.Name,
                                 Work = product.Product,
                                 Height = info.Height
                             };

            foreach(var eles in exJoinList)
            {
                Console.WriteLine($"{eles.Name}, {eles.Work}, {eles.Height}");
            }
        }

        static void print_07()
        {
            Profile[] arrProfile =
            {
                new Profile(){Name = "정우성", Height=186},
                new Profile(){Name ="김태희", Height = 158},
                new Profile(){Name = "고현정", Height = 172},
                new Profile(){Name = "장성현",  Height = 184},
                new Profile(){Name = "이문세", Height = 178},
                new Profile(){Name = "하하", Height = 171}
            };


            var list = from p in arrProfile
                       group p by p.Height > 177 into g
                       select new
                       {                           
                           Pass = g.Key == true ? "크다" : "작다",
                           Count = g.Count(),
                           Max = g.Max(p => p.Height),
                           Min = g.Min(p => p.Height),
                           g = g
                       };
            foreach(var eles in list)
            {
                foreach(var ele in eles.g)
                {
                    Console.WriteLine("그룹:{0}, 이름:{1}, 숫자:{2}, MAX:{3}",eles.Pass, ele.Name, eles.Count, eles.Max);
                }
            }
        }

        static void print_08()
        {
            Car[] car =
            {
                new Car(){Cost = 56, MaxSpeed =120},
                new Car(){Cost = 70, MaxSpeed =160},
                new Car(){Cost = 45, MaxSpeed =180},
                new Car(){Cost = 32, MaxSpeed =200},
                new Car(){Cost = 82, MaxSpeed =280}
            };

            var carList = from c in car
                          orderby c.Cost ascending
                          group c by c.Cost > 50 && c.MaxSpeed > 150 into g
                          select new
                          {
                              f = (g.Key == true ? "Cost: 50이상 MaxSpeed: 150이상" : "기준미달"),
                              Count = g.Count(),
                              MaxCost = g.Max(c => c.Cost),
                              MaxSpeed = g.Max(c => c.MaxSpeed),
                              MinCost = g.Min(c => c.Cost),
                              MinSpeed = g.Min(c => c.MaxSpeed),
                              detail = g
                          };

            var selected = from c in car
                           where c.Cost < 60
                           orderby c.Cost
                           select c;

            foreach (var eles in selected)
                Console.WriteLine($"{eles.Cost}::{eles.MaxSpeed}");

            foreach(var eles in carList)
            {
                Console.WriteLine($"{eles.f}    {eles.Count}");
                foreach(var ele in eles.detail)
                {
                    Console.WriteLine($"{ele.Cost}, {ele.MaxSpeed}");
                }
            }

        }
    }

    class Car
    {
        public int Cost { get; set; }
        public int MaxSpeed { get; set; }
    }

    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }

        public int[] Score
        {
            get;
            set;
        }

        public string Product
        { get; set; }
        public string Star { get; set; }

    }
}
