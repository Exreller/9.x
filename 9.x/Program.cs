using System;
using System.Collections.Generic;

namespace DelegatePractices
{
    public class Person
    {
        public string Name { get; set; }

    }

    class Myexception : Exception 
    {
        public Myexception(string message) 
            :base(message)
        {

        }
    }

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

    class Sort
    {
        public delegate void SortDelegate(List<Person> personList);
        public event SortDelegate SortEvent;

        public void SortName(List<Person> personList, int sortType)
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
                        personList.Reverse();
                        break;
                    }
            }

            EnteredSortType(personList);

        }
                
        protected virtual void EnteredSortType(List<Person> personList)
        {
            SortEvent?.Invoke(personList);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {

            Person person1 = new()
            {
                Name = "Александр"
            };

            Person person2 = new()
            {
                Name = "Николай"
            };

            Person person3 = new()
            {
                Name = "Веньямин"
            };

            Person person4 = new()
            {
                Name = "Феофан"
            };

            Person person5 = new()
            {
                Name = "Людвиг"
            };

            List<Person> PersonList = new();
            PersonList.Add(person1);
            PersonList.Add(person2);
            PersonList.Add(person3);
            PersonList.Add(person4);
            PersonList.Add(person5);

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

            static void ShowSortedPerson(List<Person> personList)
            {
                foreach(var person in personList)
                Console.WriteLine(personList);
            }
        }
    }
}
