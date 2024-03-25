using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                string DestName = @"D:\ИС-22\MyDir\temp\";
            DirectoryInfo dir = new DirectoryInfo(@"D:\ИС-22\Praktik8\111\");
            if (!dir.Exists)
                {
                    Console.WriteLine("Каталог " + dir.Name + " не существует");
                    return;
                }
            else
                {
                    Console.WriteLine("Подкатологи ");
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo dr in dirs) 
                    {
                        Console.WriteLine(dr.FullName);
                    }
                }
            if(dir.Exists && !Directory.Exists(DestName))
                {
                    dir.MoveTo(DestName);
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
