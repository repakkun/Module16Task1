using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Module16Task1
{
    class Program
    {
        public static void DeleteData(DirectoryInfo d)
        {    
            FileInfo[] files = d.GetFiles();
            foreach (FileInfo f in files)
            {
                f.Delete();
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                di.Delete(true);
            }        
          
                      
        }
        static void Main(string[] args)
        {
            try
            {               
                          
                Console.WriteLine("Введите путь до папки");
                string folderName = Console.ReadLine();
                DirectoryInfo directoryInfo = new DirectoryInfo(folderName);
                if (directoryInfo.Exists)
                {
                    var start = DateTime.Now;   
                    var end = directoryInfo.LastWriteTime;
                    if (start - end >= TimeSpan.FromMinutes(30))
                    {
                        DeleteData(directoryInfo);
                        Console.WriteLine("данные удалены");
                    }
                    else { Console.WriteLine("Ничего не удалено"); }
                }          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
