using System;
using System.Collections.Generic;

namespace DelegatePractices
{
    /// <summary>
    /// Пользовательское исключение
    /// </summary>
    class Myexception : Exception 
    {
        public Myexception(string message) 
            :base(message)
        { }
    }

    /// <summary>
    /// Класс приёма ввода с клавиатуры + проверка воода
    /// </summary>
    class InputReader
    {

        public int NumberRead()
        {
            
            Console.WriteLine("Для сортировки А-Я введите 1\nДля соритовки Я-А введите 2");
                        
            int number = Convert.ToInt32(Console.ReadLine());
            if(number != 1 && number != 2)
            {
                throw new Myexception("Неверный ввод");
            }
            else
            {
                return number;
            }
                
        }
               
    }

    /// <summary>
    /// Класс сортировки с делегатом и событием
    /// </summary>
    class Sort
    {
        public delegate void SortDelegate(List<string> personList);
        public event SortDelegate SortEvent;

        /// <summary>
        /// основной метод сортировки
        /// </summary>
        /// <param name="personList"></param>
        /// <param name="sortType"></param>
        public void SortName(List<string> personList, int sortType)
        {
            switch (sortType)
            {
                case 1:
                    {
                        personList.Sort();
                        break;
                    }
                case 2:
                    {
                        personList.Sort((x, y) => y.CompareTo(x));
                        break;
                    }
            }

            EnteredSortType(personList);

        }
                
        protected virtual void EnteredSortType(List<string> personList)
        {
            SortEvent?.Invoke(personList);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            
            List<string> PersonList = new List<string>{ "Людвиг", "Феофан", "Александр",
                "Николай", "Веньямин"};
            

            InputReader inputReader = new();
            Sort sort = new();
            sort.SortEvent += ShowSortedPerson;

            try
            {
                sort.SortName(PersonList, inputReader.NumberRead());
            }
            catch (Myexception e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Введены не цифры");
            }

            static void ShowSortedPerson(List<string> personList)
            {
                foreach(var person in personList)
                Console.WriteLine(person);
            }
        }
    }
}
