using System;
using System.IO;

namespace Задание_1
{
    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string message) : base(message)
        { }
    }
    class Program
    {
        static void Example()
        {
            
            Console.WriteLine("В течении 10 секунд, введите число 1");
            DateTime start = DateTime.Now;
            string stringNumber =Console.ReadLine();
            TimeSpan stop = DateTime.Now - start;
            if (stop > TimeSpan.FromSeconds(10)) throw new TimeoutException();

            if (int.TryParse(stringNumber, out int result))
            {
                Console.WriteLine($"Введено число: {result}");
            }else { throw new FormatException(); }            

            if (result != 1) throw new MyException();            

        }
        static void Main(string[] args)
        {
            Exception[] exceptions = new Exception[5];
            exceptions[0] = new MyException("Введено значение отличное от 1");
            exceptions[1] = new FormatException("Введена не цифра");
            exceptions[2] = new TimeoutException("Превышен лимит времени в 10 секунд.");
            exceptions[3] = new DirectoryNotFoundException("Путь указан не верно");
            exceptions[4] = new FileNotFoundException("Файл не найден");


            try
            {
                Example();
                Console.WriteLine(@"Введите путь к файлу для записи. Формат ввода: C:\");
                DirectoryInfo directoryInfo = new DirectoryInfo(Console.ReadLine());
                if (!directoryInfo.Exists) throw new DirectoryNotFoundException();

                Console.WriteLine("Введите название файла");
                FileInfo fileInfo = new FileInfo(directoryInfo + Console.ReadLine());
                if (!fileInfo.Exists) throw new FileNotFoundException();
            }
            catch (MyException)
            {
                Console.WriteLine(exceptions[0]);
            }
            catch (FormatException)
            {
                Console.WriteLine(exceptions[1]);
            }
            catch (TimeoutException)
            {
                Console.WriteLine(exceptions[2]);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(exceptions[3]);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(exceptions[4]);
            }

        }
    }
}
