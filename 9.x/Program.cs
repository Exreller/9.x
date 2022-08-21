using System;
using System.Collections.Generic;

namespace DelegatePractices
{
    
    
    class Program
    {
        
        public void SortName(List<_9.x.Person> personList, int sortType)
        {

        }

        static void Main(string[] args)
        {

            _9.x.Person person1 = new()
            {
                Name = "Александр"
            };

            _9.x.Person person2 = new()
            {
                Name = "Николай"
            };

            _9.x.Person person3 = new()
            {
                Name = "Веньямин"
            };

            _9.x.Person person4 = new()
            {
                Name = "Феофан"
            };

            _9.x.Person person5 = new()
            {
                Name = "Людвиг"
            };

            List<_9.x.Person> PersonList = new();
            PersonList.Add(person1);
            PersonList.Add(person2);
            PersonList.Add(person3);
            PersonList.Add(person4);
            PersonList.Add(person5);


        }
    }
}
