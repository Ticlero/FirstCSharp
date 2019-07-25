using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices; //호출자 정보 애트리뷰트 

namespace ReflectionANDAttribute
{
    //애트리뷰트는 데의터의 대한 정보 데이터(즉 메타데이터), 컴파일러가이 애트리뷰트를 이용하여 정보를 읽어 사용
    // 기본형식 - [애트리뷰트_이름(애트리뷰트 매개변수)]
    class Attribute_Concept
    {
        [Obsolete("'OldMethod()'는 보안상 문제로 사용을 지양해 주십시오. 'NewMethod()'를 사용해주십시오.")]
        public void OldMethod()
        {
            Console.WriteLine("I'm old method()");
        }

        public void NewMethod()
        {
            Console.WriteLine("I'm new method");
        }

        public static void WriteLine(string msg,
            [CallerFilePath] string fPath = "",
            [CallerLineNumberAttribute] int line = 0,
            [CallerMemberNameAttribute] string mName = "") //실행된 파일의 경로, 코드라인, 실행된 멤버의 메소드, 메시지 출력
        {
            Console.WriteLine("{0}(Line:{1}) {2}:{3}", fPath, line, mName, msg);
        }

        public void SomeMethod()
        {
            Attribute_Concept.WriteLine("즐거운 프로그래밍!!");
        }

    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)] //애트리뷰트를 겹쳐 사용할 수 있게 해주는 애트리뷰트의 애트리뷰트
    class History : System.Attribute //System.Attribute 를 이용하는 것만으로도 사용자 정의 애트리뷰트 생성!
    {
        private string worker;
        private string changeTime;

        public double Version
        {
            get; set;
        }

        public string ChangeTime
        {
            get { return changeTime; }
        }

        public History(string worker)
        {
            this.worker = worker;
            Version = 1.0;
            this.changeTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string Worker
        {
            get { return worker; }

        }
    }
    [History("shJang", Version = 0.1)]
    [History("shjang", Version = 0.2)]
    class TestClass
    {
        public void Write()
        {
            Console.WriteLine("Func()");
        }
    }
}
