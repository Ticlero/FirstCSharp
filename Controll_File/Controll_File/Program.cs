using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //객체를 직열화 및 역직렬화 하는 담당

namespace Controll_File
{
    class Program
    {
        static void Main(string[] args)
        {
            //print_01(args);
            //print_02(args);
            //print_03();
            //print_04();

            //BinaryWrite();
            //OpenStreamFile("a.dat");
            //BinaryRead();
            //print_05();
            print_06();
        }

        static void print_01(string[] args) //디렉토리 정보 보기~
        {
            string directory;
            if (args.Length < 1)
                directory = ".";
            else
                directory = args[0];

            Console.WriteLine($"{directory} directory Info");
            Console.WriteLine("- Directories");
            var directories = (from dir in Directory.GetDirectories(directory)
                               let info = new DirectoryInfo(dir) //let은 LINQ안의 var와 같은 기능 - LINQ안에서 새로운 변수를 만듬
                               select new
                               {
                                   Name = info.Name,
                                   Attributes = info.Attributes
                               }).ToList();

            foreach (var d in directories)
            {
                Console.WriteLine($"{ d.Name }, { d.Attributes }");
            }

            Console.WriteLine("-File");
            var files = (from file in Directory.GetFiles(directory)
                         let info = new FileInfo(file)
                         select new
                         {
                             Name = info.Name,
                             FileSize = info.Length,
                             Attributes = info.Attributes
                         }).ToList();

            foreach (var f in files)
            {
                Console.WriteLine(
                    $"{f.Name}: {f.FileSize}: {f.Attributes}");
            }
        }
        static void print_02(string[] args) //폴더 및 파일 생성하기~
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage:: Controll_File.exe <PATH>[TYPE: File or Directory]");
                return;
            }

            string path = args[0];
            string type = "File";
            if (args.Length > 1)
            {
                type = args[1];
            }

            if (File.Exists(path) || Directory.Exists(path))
            {
                switch (type)
                {
                    case "File":
                        File.SetLastWriteTime(path, DateTime.Now);
                        break;
                    case "Directory":
                        Directory.SetLastWriteTime(path, DateTime.Now);
                        break;
                    default:
                        OnWrongPathType(type);
                        return;
                }
            }
            else
            {
                if (type == "File")
                    File.Create(path).Close();
                else if (type == "Directory")
                    Directory.CreateDirectory(path);
                else
                {
                    OnWrongPathType(path);
                    return;
                }
                Console.WriteLine($"Created {path}, {type}");
            }

        }

        static void print_03() //파일 읽기 쓰기
        {

            //byte[] byte = 읽은 데이터를 담을 byte 배열
            //int offset = byte 배열 내의 시작 오프셋
            //int count = 읽을 데이터의 최대 바이트 수
            long someValue = 0x123456789ABCDEF0;
            Console.WriteLine($"Origin Data: 0x{someValue:X16}");

            Stream outStream = new FileStream("a.dat", FileMode.Create);
            byte[] wByte = BitConverter.GetBytes(someValue);

            Console.Write($"{"Byte array : ",-12}");

            foreach (byte b in wByte)
                Console.Write($"{b:X2} ");
            Console.WriteLine();

            
            outStream.Write(wByte, 0, wByte.Length);
            outStream.Close();

            Stream inStream = new FileStream("a.dat", FileMode.Open);
            byte[] rByte = new byte[8];

            int i = 0;
            while (inStream.Position < inStream.Length)
                rByte[i++] = (byte)inStream.ReadByte();

            long readValue = BitConverter.ToInt64(rByte, 0);
            Console.WriteLine($"{"Read Data  : ",-12}0x{readValue:X16}");
        }

        static void print_04() //Stream을 생성하면서 부터 읽거나 쓸 때 pointer가 생성되고 (0 부터) write/read를 함으로써 1씩 증가 seek를 함으로써 현재 포인터에서 지정한 포인터로 옮길 수 있다. 단위는 바이트
        {
            Stream outStream = new FileStream("a.dat", FileMode.Create);
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.WriteByte(0x01); //0번에 쓰고 1번으로 ++
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.WriteByte(0x02); //1번에 쓰고 2번으로 ++
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.WriteByte(0x03); //2번에 쓰고 3번으로 ++
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.WriteByte(0x04); //3번에 쓰고 4번으로 ++
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.WriteByte(0x05); //4번에 쓰고 5번으로 ++
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.WriteByte(0x06); //5번에 쓰고 6번으로 ++
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.WriteByte(0x07); //6번에 쓰고 7번으로 ++
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.WriteByte(0x08); //7번에 쓰고 8번으로 ++
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.Seek(5, SeekOrigin.Current); //현재위치 8에서 5번 뛰어넘어 13번으로
            Console.WriteLine($"Current Position: {outStream.Position}");

            outStream.WriteByte(0x09); //13번에 쓰고 14번으로
            Console.WriteLine($"Current Position: {outStream.Position}");
        }
        static void OnWrongPathType(string type)
        {
            Console.WriteLine($"{type} is worng type");
            return;
        }

        static void OpenStreamFile(string fName)
        {
            Stream inStream = new FileStream(fName, FileMode.Open);
            byte[] rbyte = new byte[inStream.Length];
            int i = 0;

            Console.Write("{0,-12}  ", "Offset(h)");
            while (i < 16)
            { 
                Console.Write($"{i:X2} ");
                i++;
            }

            i = 0;
            Console.WriteLine();

            int count = 10;
            while (inStream.Position < inStream.Length)
            {
                rbyte[i] = (byte)inStream.ReadByte();
                
                if(i == 0)
                    Console.Write("{0,-12}  ", "00000000");
                if (i > 0 && i % 16 == 0)
                {
                    Console.WriteLine();
                    Console.Write("{0,-12:D8}  ", count);
                    count += 10;
                }
                Console.Write($"{rbyte[i]:X2} ");
                
                i++;
            }
            Console.WriteLine();

            inStream.Close();

        }

        static void BinaryWrite()
        {
            BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create));
            string test = 
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaa" +
                "aaa"; //255
            string test2 = test + "a"; //256
            bw.Write(int.MaxValue);
            bw.Write("Good morning!");
            bw.Write(uint.MaxValue);
            bw.Write("안녕하세요!");
            bw.Write(test2);
            bw.Write(double.MaxValue);
            bw.Close();
        }

        static void BinaryRead()
        {
            BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open));

            Console.WriteLine($"\nFile Size : {br.BaseStream.Length}Byte");
            int a = br.ReadInt32();
            string b = br.ReadString();
            uint c = br.ReadUInt32();
            string d = br.ReadString();
            string e = br.ReadString();
            double f = br.ReadDouble();

            Console.WriteLine("{0}\n" +
                "{1}\n" +
                "{2}\n" +
                "{3}\n" +
                "{4}\n" +
                "{5}", a, b, c, d, e, f);

            br.Close();
        }

        static void print_05()
        {
            Stream wst = new FileStream("b.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            MyClass mc = new MyClass()
            {
                Name = "장성현",
                phone = "010-4283.6857",
                Age = 28
            };

            serializer.Serialize(wst, mc);
            wst.Close();

            //OpenStreamFile("b.dat");

            Stream rst = new FileStream("b.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            MyClass mc2;
            mc2 = (MyClass)deserializer.Deserialize(rst);
            rst.Close();

            Console.WriteLine($"Name:{mc2.Name}");
            Console.WriteLine($"Age:{mc2.Age}");
            Console.WriteLine($"Phone:{mc2.Phone}");
        }

        static void print_06()
        {
            Stream wst = new FileStream("c.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            List<MyClass> list = new List<MyClass>();
            list.Add(new MyClass() { Name = "김연아", Age = 33, Phone = "0101234567" });
            list.Add(new MyClass() { Name = "장성현", Age = 28, Phone = "01098745612" });
            list.Add(new MyClass() { Name = "장미란", Age = 26, Phone = "010555555555" });

            serializer.Serialize(wst, list);
            wst.Close();

            Stream rst = new FileStream("c.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();
            List<MyClass> list2 = (List<MyClass>)deserializer.Deserialize(rst);

            foreach (MyClass mc in list2)
                Console.WriteLine("{0}  ,{1}  ,  {2}",mc.Name, mc.Age, mc.Phone);
        }
    }

    [Serializable] //복합데이터 - 클래스, 필드, 멤버, 프로퍼티 등등 파일에 저장할 수 있게 하는 방법
    class MyClass
    {
        
        public string phone;

        public string Name
        {get;
            set;
        }

        
        public string Phone { get; set; }
        public int Age { get; set; }
    }
}
