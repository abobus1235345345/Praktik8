using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static prakt8._2.Program;
using System.Runtime.Serialization.Formatters.Soap;

namespace ConsoleApplication1
{
    class Class1
    {
        public static void Main()
        {
            FileStream fs = new FileStream("D:\\ИС-22\\Praktik8\\Praktik8\\bin\\Debug\\MiniVan.bin", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            MiniVan mv = (MiniVan)bf.Deserialize(fs);
            Console.WriteLine(mv.PetName + "\t" + mv.CurrentSpeed + "\t" + mv.MaxSpeed + "\t" + mv.doors);
            fs.Close();

            FileStream f = new FileStream("D:\\ИС-22\\Praktik8\\Praktik8\\bin\\Debug\\SportCar.xml", FileMode.Open);
            SoapFormatter sf = new SoapFormatter();
            SportsCar sc = (SportsCar)sf.Deserialize(f);
            Console.WriteLine(sc.PetName + "\t" + sc.CurrentSpeed + "\t" + sc.MaxSpeed);
            f.Close();
        }
    }
}
