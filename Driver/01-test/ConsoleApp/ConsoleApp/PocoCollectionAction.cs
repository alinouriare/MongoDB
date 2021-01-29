using ConsoleApp.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class PocoCollectionAction
    {
        private readonly IMongoCollection<Person> collection;

        public PocoCollectionAction(IMongoCollection<Person> collection)
        {
            this.collection = collection;
        }

        public void InserOne(Person person)
        {
            collection.InsertOne(person);
        }

        public void InserMany(Person person)
        {

            List<Person> elements = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                Person p = new Person
                {
                    Age = person.Age + i,
                    FirstName = person.FirstName + i,
                    LastName = person.LastName + i,
                    Tags = new string[] { i.ToString() }
                };
                elements.Add(p);
            }

            collection.InsertMany(elements);
        }


        public void FindFilteredLimit()
        {

           var result= collection.Find<Person>(c => c.Age > 50).Limit(5).ToList();
            foreach (var item in result)
            {
                System.Console.WriteLine($"{item.FirstName}----{item.Age}");
            }

        }

        public void FindPageLimit()
        {

            var result = collection.Find<Person>(c => c.Age > 50).Skip(10).Limit(5).ToList();
            foreach (var item in result)
            {
                System.Console.WriteLine($"{item.FirstName}----{item.Age}");
            }

        }
    }
}
