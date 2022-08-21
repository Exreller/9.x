using System;
using System.Collections.Generic;

namespace test
{
    public class Person
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
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
            */

            //List<Person> PersonList = new();
            //PersonList.Add(person1);
            //PersonList.Add(person2);
            //PersonList.Add(person3);
            //PersonList.Add(person4);
            //PersonList.Add(person5);
            var PersonList = new List<string> { "Людвиг", "Феофан", "Веньямин", "Николай",
        "Александр"};
            PersonList.Sort();
            foreach (var person in PersonList)
            Console.WriteLine(person);


            

        }
    }
}
