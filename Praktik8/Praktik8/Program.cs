using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace prakt8._2
{
    public class Program
    {

        public enum EngineState { engineAlive, engineDead }

        [Serializable]
        public abstract class Car
        {
            public string PetName { get; set; }
            public int CurrentSpeed { get; set; }
            public int MaxSpeed { get; set; }
            protected EngineState egnState = EngineState.engineAlive;
            public EngineState EngineState
            {
                get { return egnState; }
            }
            public abstract void TurboBoost();
            public virtual void Show()
            {
                Console.WriteLine(PetName);
                Console.WriteLine(MaxSpeed);
                Console.WriteLine(CurrentSpeed);
                Console.WriteLine(egnState);
            }

            public Car() { } //конструктор по умолчанию
            public Car(string name, int maxSp, int currSp)  // конструктор с параметрами
            {
                PetName = name;
                MaxSpeed = maxSp;
                CurrentSpeed = currSp;
            }

        }
        [Serializable]
        public class SportsCar : Car
        {
            public SportsCar() { }  // конструктор по умолчанию
            public SportsCar(string name, int maxSp, int currSp) // конструктор с параметрами
            : base(name, maxSp, currSp) { }
            public override void TurboBoost()  // переопределение метода TurboBoost() обязательно!
            {
                MessageBox.Show("Таранная скорость!", "Чем быстрее, тем лучше...");
            }
        }
        [Serializable]
        public class MiniVan : Car
        {
            [NonSerialized]
            public int doors;

            public MiniVan() { }  // конструктор по умолчанию
            public MiniVan(string name, int maxSp, int currSp, int doors)
            : base(name, maxSp, currSp)
            {
                this.doors = doors;
            }  // конструктор с параметрами
            public override void TurboBoost()
            {
                egnState = EngineState.engineDead;
                MessageBox.Show("Упс!", " Ваш блок двигателя взорвался!");
            }
        }


        public static void Main()
        {
            FileStream fs = new FileStream("MiniVan.bin", FileMode.Create);
            MiniVan mv = new MiniVan("jh", 120, 100, 2);
            mv.TurboBoost();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, mv);
            fs.Close();

            FileStream f = new FileStream("SportCar.xml", FileMode.Create);
            SportsCar sc = new SportsCar("hjk", 120, 130);
            sc.TurboBoost();
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(f, sc);
            f.Close();
        }


    }
}