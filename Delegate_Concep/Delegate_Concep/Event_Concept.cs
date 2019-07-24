using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Concept
{
    //1단계 대리자 선언 클래스 밖 or 내부
    public delegate void EventHandler(string msg);
    class Event_Concept
    {
        //2단계, 클래스 내에 선언된 대라자의 인스턴스를 event 키워드로 선언
        public event EventHandler eventhandler;

        public void DoSomething(int msg)
        {
            int temp = msg % 10;
            if(temp != 0 && temp % 3 == 0)
            {
                eventhandler(string.Format("{0} :짝", msg));
            }
        }

    }
}
