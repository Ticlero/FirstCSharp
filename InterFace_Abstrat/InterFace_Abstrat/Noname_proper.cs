using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace_Abstrat
{
    class Noname_proper
    {
        public Noname_proper()
        {
            var myInstance = new { Name = "장성현", Age = "28" }; //무명형식 객체생성 - 인스턴스화
            Console.WriteLine($"name={myInstance.Name}, {myInstance.Age}");
            //myInstance.Name = "장방구"; 한 번 생성된 무명형식 인스턴스는 상수화 됨. 즉, 값 변화 불가
            var b = new { Subject = "수학", Score = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 } };
            Console.WriteLine($"\n과목 >> {b.Subject}");
            foreach(int eles in b.Score)
            {
                Console.WriteLine(eles);
            }
        }
    }
}

