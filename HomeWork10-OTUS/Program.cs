using System.Text;
using static System.Environment;
using static System.IO.Path;
namespace HomeWork10_OTUS
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            string[] customPath = new[] { "C:\\", "OTUS"};
            string catalog = Combine(customPath);
            DirectoryInfo directoryInfo = new DirectoryInfo(catalog);
            directoryInfo.Create();

            directoryInfo.CreateSubdirectory("TestDir1");
            directoryInfo.CreateSubdirectory("TestDir2");

            string catalog1 = Combine(catalog,"TestDir1");
            string catalog2 = Combine(catalog, "TestDir2");
            string[] catalogs = new[] { catalog1, catalog2 };

            // запись имени
            for (int i = 0; i < catalogs.Length; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    string name = "File" + j + ".txt";
                    string path = Combine(catalogs[i], name);
                    try
                    {
                        using (var writer = File.CreateText(path))
                        {
                            writer.WriteLine(name);                            
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }                    
                }
            }

            // запись времени
            for (int i = 0; i < catalogs.Length; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    string name = "File" + j + ".txt";
                    string path = Combine(catalogs[i], name);                    
                    try
                    {
                        using (var writer = new StreamWriter(path, true))
                        {
                            writer.WriteAsync(DateTime.Now.ToString());
                        }                        
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }                    
                }
            }

            // чтение файлов
            for (int i = 0; i < catalogs.Length; i++)
            {
                Console.WriteLine(catalogs[i]);
                for (int j = 1; j < 11; j++)
                {
                    string name = "File" + j + ".txt";
                    string path = Combine(catalogs[i], name);                    
                    try
                    {
                        using (var reader = new StreamReader(path))
                        {
                            while (!reader.EndOfStream)
                            {
                                var row = reader.ReadLine();
                                Console.Write(row + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }                    
                }
                Console.WriteLine();
            }

        }
    }
}