using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CSharp_JSon_Test
{
    class Program
    {
        private Dog dog;

        static void Main(string[] args)
        {
            Program p = new Program();

            //test();

            string result = p.JsonfileToString("tset.json");
            string vResult = p.JsonfileToString("vehicle.json");

            JObject obj = p.StringToJsonParse(result);
            JObject obj2 = p.StringToJsonParse(vResult);
            //Console.WriteLine(carlist);

            JToken jt = obj["dog"];
            Console.WriteLine($"JTOKEN_TEST{jt.Children()}");
            VehicleRoot vehicleList = new VehicleRoot();
            List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(obj2["Vehicle"].ToString());

            Vehicle v1 = vehicles[0];
            Console.WriteLine(v1.Owner.OwnerName);
            //Console.WriteLine(vehicles.Count);
            for (int i = 0; i < vehicles.Count; i++)
            {
                //Console.WriteLine(v.ToString());
                if (vehicles[i] != null)
                {
                    vehicleList.VehiclesList.Add(vehicles[i]);
                    Console.WriteLine(vehicleList.VehiclesList[i].Owner.PhoneNum);
                }
            }

            DogList dogs = new DogList();
            List<Dog> dogList = JsonConvert.DeserializeObject<List<Dog>>(obj["dog"].ToString());

            for (int i = 0; i < dogList.Count; i++)
            {
                if (dogList[i] != null)
                {
                    dogs.Dogs.Add(dogList[i]);
                }
            }

            foreach (Dog d in dogs.Dogs)
            {
                Console.WriteLine(d.Owner.PhoneNum);
            }

            string json = JsonConvert.SerializeObject(dogs.Dogs, Formatting.Indented);
            string json2 = JsonConvert.SerializeObject(vehicleList.VehiclesList, Formatting.Indented);

            stringTojsonFile("a.json", json);
            stringTojsonFile("b.json", json2);

            /*
            string output = JsonConvert.SerializeObject(p.dog);

            Dog deserializedDog = JsonConvert.DeserializeObject<Dog>(output);
            Console.WriteLine($"DogName: {deserializedDog.Name}\n" +
                $"DogAge: {deserializedDog.Age}\n" +
                $"DogWeight: {deserializedDog.Weight}\n" +
                $"OwnerName: {deserializedDog.Owner.OwnerName}\n" +
                $"OwnerPhone: {deserializedDog.Owner.Phone}\n");

            */
        }

        public Program()
        {
            this.dog = new Dog()
            {
                Name = "로키",
                Age = 7,
                Weight = 9.6f,
                Owner = new Owner()
                {
                    OwnerName = "장성현",
                    PhoneNum = "010-4283-6857"
                }
            };
        }

        public void JsonSerializer_Test()
        {
            Dog dog = new Dog()
            {
                Name = "로키",
                Age = 7,
                Weight = 9.6f,
                Owner = new Owner()
                {
                    OwnerName = "장성현",
                    PhoneNum = "010-4283-6857"
                }
            };

        }

        public string JsonfileToString(string path)
        {
            StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open));
            string result = null;
            /*
            while (sr.EndOfStream == false)
            {
                result += sr.ReadLine().Trim();
            }
            */
            result = sr.ReadToEnd();
            //Console.WriteLine(result);

            sr.Close();

            return result;
        }

        public static void stringTojsonFile(string path, string data)
        {
            StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create));
            sw.WriteLine(data);
            sw.Close();
        }

        public JObject StringToJsonParse(string jsonstring)
        {
            JObject obj;
            if (jsonstring.StartsWith("{") && jsonstring.EndsWith("}"))
            {
                obj = JObject.Parse(jsonstring);
                string result = obj.ToString();
                //Console.WriteLine(result);
                return obj;
            }
            else
            {
                Console.WriteLine("변환 실패");
                return null;
            }

        }

        static void test()
        {
            string json = @"[
  {
    'Name': 'Product 1',
    'ExpiryDate': '2000-12-29T00:00Z',
    'Price': 99.95,
    'Sizes': null
  },
  {
    'Name': 'Product 2',
    'ExpiryDate': '2009-07-31T00:00Z',
    'Price': 12.50,
    'Sizes': null
  }
]";
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

            //Console.WriteLine(products.Count);
            // 2

            Product p1 = products[0];

            //Console.WriteLine(p1.Name);
        }
    }
}
