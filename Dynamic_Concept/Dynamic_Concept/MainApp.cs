using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Dynamic_Concept
{
    class MainApp
    {
        static void Main(string[] args)
        {
            //print_01();
            //print_02();
            print_03();
        }

        static void print_01()
        {
            dynamic[] arr = new dynamic[] { new Duck(), new Mallard(), new Robot() };

            
            foreach(dynamic eles in arr)
            {
                Console.WriteLine(eles.GetType());
                eles.Walk();
                eles.Swim();
                eles.Quack();
                Console.WriteLine();
            }
        }

        static void print_02()
        {
            string savePath = System.IO.Directory.GetCurrentDirectory(); //현재 프로젝트의 디렉토리
            string[,] array = new string[,]
            {
                {"뇌를 자극하는 알고리즘", "2009" },
                {"뇌를 자극하는 C# 4.0", "2011" },
                {"뇌를 자극하는 C# 5.0", "2013" },
                {"뇌를 자극하는 파이썬 3", "2016" },
                {"이것이 C#이다", "2018" }
            };

            Console.WriteLine("Creating Excel File in old way.......");
            Oldway(array, savePath);
            Console.WriteLine("Old way Complete!");
            Console.WriteLine("Creating Excel File in new way.........");
            Newway(array, savePath);
            Console.WriteLine("New way Complete!");

        } //COM을 이용한 엑셀파일 만들기

        static void print_03()
        {
            PythonWith.print();
        }
        
        static void Oldway(string[,] data, string savePath)//COM(Component Object Model - 마이크로소프트 사의 소프트웨어 컴포넌트 규격)을 이용하여 엑셀에 접근하기
        {
            Excel.Application excelApp = new Excel.Application();

            excelApp.Workbooks.Add(Type.Missing);

            Excel.Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;

            for(int i=0; i< data.GetLength(0); i++)
            {
                ((Excel.Range)worksheet.Cells[i + 1, 1]).Value2 = data[i, 0];
                ((Excel.Range)worksheet.Cells[i + 1, 2]).Value2 = data[i, 1];
            }

            worksheet.SaveAs(savePath + "\\shjang-book-old.xlsx", 
                Type.Missing, 
                Type.Missing, 
                Type.Missing, 
                Type.Missing, 
                Type.Missing, 
                Type.Missing, 
                Type.Missing
                );

            excelApp.Quit();
        }

        static void Newway(string[,] data, string savePath)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            Excel._Worksheet worksheet = excelApp.ActiveSheet;

            for(int i=0; i< data.GetLength(0); i++)
            {
                worksheet.Cells[i+1, 1] = data[i, 0];
                worksheet.Cells[i+1, 2] = data[i, 1];
            }

            worksheet.SaveAs(savePath + "\\shjang-book-dynamic.xlsx");
            excelApp.Quit();

        }
    }
}
