using System;
using System.IO;
using System.Text;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\pc-3\source\repos\ConsoleApp17\ConsoleApp17\text.txt";
            string pathDirectory = @"C:\";
            ReadFile(path);

            string str = Console.ReadLine();
            WriteFile(path, str);

            FileInfo file = new FileInfo(path);
            Console.WriteLine(file.FullName);


            while (true)
            {
                Console.Write("C:>");
                string action = Console.ReadLine();
                switch(action)
                {
                    case "dirs":
                        showDirs(pathDirectory);
                        break;

                    case "files":
                        showFiles(pathDirectory);
                        break;
                }
            }
        }
        public static void showDirs(string path)
        {
            try
            {
                string[] files = Directory.GetDirectories(path);
                foreach (string fileName in files)
                {
                    Console.WriteLine(fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void showFiles(string path)
        {
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (string fileName in files)
                {
                    Console.WriteLine(fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void  ReadFile(string path)
        {
            try{
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader streamRead = new StreamReader(stream))
                    {
                        string line;
                        while ((line = streamRead.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteFile(string path, string str)
        {
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Write))
                {
                    byte[] bytes = new UTF8Encoding(true).GetBytes(str);

                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}