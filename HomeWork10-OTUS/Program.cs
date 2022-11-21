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
           
            Console.WriteLine($"Is exist? {Directory.Exists(dir)}"); // проверка на существование папки

            //Directory.CreateDirectory(dir);
            //Console.WriteLine($"Is exist? {Directory.Exists(dir)}");

            //Directory.Delete(dir,true); // удаление папки
            //Console.WriteLine($"Is exist? {Directory.Exists(dir)}");

            var textFile = Path.Combine(dir,"Dummy2.txt");
            //Console.WriteLine(textFile);

            //var textWriter = File.CreateText(textFile);
            //textWriter.WriteLine("Hi!"); // записывает данные в буфер
            //textWriter.Close();

            //Console.WriteLine(File.Exists(textFile));

            //File.Copy(textFile, textFile + ".docx"); // через пакет DocumentFormat.OpenXml

            using (var textWriter = File.CreateText(textFile))
            {
                textWriter.WriteLine("Boogy, boogy!");

            }


        }
    }
}