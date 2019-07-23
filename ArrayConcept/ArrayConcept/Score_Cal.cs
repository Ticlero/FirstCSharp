using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConcept
{
    class Score_Cal
    {
        public int[] Score
        {
            get;
            set;
        }

        public string[] hello
        {
            get;
            set;
        }

        public bool CheckPassed(int score)
        {
            if (score > 60)
                return true;
            else
                return false;
        }

        public void Print(int value)
        {
            Console.Write($"{value} ");
        }

        public void print_score(int[] score)
        {
            foreach (int eles in score)
                Console.Write($"{eles} ");
        }

        public void print_avg()
        {
            int sum = 0;
            float avg = 0.0f;
            foreach (int eles in this.Score)
                sum += eles;
            avg = (float)(sum / this.Score.Length);

            Console.WriteLine($"평균은: {avg}입니다.");         
        }
    }
}
