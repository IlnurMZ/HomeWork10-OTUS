using System.Text;
using static System.Environment;
namespace HomeWork10_OTUS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"PathSeparatir {Path.PathSeparator}");
            //Console.WriteLine($"DirectorySeparator {Path.DirectorySeparatorChar}");
            //Console.WriteLine($"CurrentDirectory {Directory.GetCurrentDirectory()}");
            //Console.WriteLine($"SystemDirectory {Environment.SystemDirectory}");

            // Получение информации о дисках на компьютере
            //foreach (DriveInfo drive in DriveInfo.GetDrives())
            //{
            //    if (drive.IsReady)
            //    {
            //        Console.WriteLine($"{drive.Name} | {drive.DriveFormat} | {drive.TotalFreeSpace}");
            //    }
            //}

            // Создание папки
            string userFolder = GetFolderPath(SpecialFolder.Personal);
            string[] customPath = new[] { userFolder, "OTUS", "NewFolder" };
            string dir = Path.Combine(customPath); // комбинирует названия директорий
           
            //Console.WriteLine($"Is exist? {Directory.Exists(dir)}"); // проверка на существование папки

            //Directory.CreateDirectory(dir);
            //Console.WriteLine($"Is exist? {Directory.Exists(dir)}");

            //Directory.Delete(dir,true); // удаление папки
            //Console.WriteLine($"Is exist? {Directory.Exists(dir)}");

            var textFile = Path.Combine(dir,"Dummy.csv");
            //Console.WriteLine(textFile);

            //var textWriter = File.CreateText(textFile);
            //textWriter.WriteLine("Hi!"); // записывает данные в буфер
            //textWriter.Close();

            //Console.WriteLine(File.Exists(textFile));

            //File.Copy(textFile, textFile + ".docx"); // через пакет DocumentFormat.OpenXml

            //using (var textWriter = File.CreateText(textFile))
            //{
            //    textWriter.WriteLine("Boogy, boogy!");

            //}

            //File.Delete(textFile + ".docx");
            //Console.WriteLine(File.Exists(textFile + ".docx"));

            //var textReader = File.OpenText(textFile);
            //Console.WriteLine(textReader.ReadToEnd());

            //string s = "SomeText";
            //char[] chars = s.ToCharArray();

            //using (var writer = new StreamWriter(textFile, true))
            //{
            //    writer.WriteLine(chars);
            //}

            //using (var reader = new StreamReader(textFile))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        var row = reader.ReadLine();
            //        Console.WriteLine(row);
            //    }
            //}

            var csv = ReadData(textFile);
            //foreach (var row in csv)
            //{
            //    row[0] += "X";
            //}

            //WriteData(csv, textFile);

            static List<string[]> ReadData(string filename)
            {
                var result = new List<string[]>();
                try
                {
                    using (var reader = new StreamReader (filename))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line?.Split(';');
                            result.Add(values);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return result;
            }

            static void WriteData(List<string[]> data, string filename)
            {
                try
                {
                    using (var writer = new StreamWriter(filename))
                    {
                        foreach (var item in data)
                        {
                            writer.WriteLine(string.Join(";", item));
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}