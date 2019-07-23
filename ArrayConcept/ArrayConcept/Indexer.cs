using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConcept
{

    /*
        인덱서 형식
        
        class 이름
        {
            한정자 인덱서형식 this[형식 index]
            {

                get
                {
                    //index를 이용하여 내부 데이터 변환
                }

                set
                {
                    //index를 이용하여 내부 데이터 저장
                }
        }

    */

    class Indexer
    {
        private int[] array;
        public Indexer()
        {
            array = new int[3];
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if(index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine("Array Resized : {0}", array.Length);
                }
                array[index] = value;
            }
        }

        public int Length
        {
            get { return array.Length; }
        }
    }

    class MyEnumerator
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break;
            yield return numbers[3];
        }
    }
    
    class Indexer2 : IEnumerator, IEnumerable
    {
        private int[] array;
        private int position = -1;
        public Indexer2()
        {
            array = new int[3];
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine("Array Resized : {0}", array.Length);
                }
                array[index] = value;
            }
        }

        public int Length
        {
            get { return array.Length; }
        }

        //IEnumerator member
        public object Current
        {
            get
            {
                return array[position];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for(int i=0; i<this.array.Length; i++)
            {
                yield return (this.array[i]);
            }
        }

        public bool MoveNext()
        {
            if(this.position == array.Length-1)
            {
                Reset();
                return false;
            }
            position++;
            return (this.position < array.Length);
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}
