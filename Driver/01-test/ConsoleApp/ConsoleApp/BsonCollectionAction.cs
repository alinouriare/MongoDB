using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
  public  class BsonCollectionAction
    {
        private readonly IMongoCollection<BsonDocument> collection;

        public BsonCollectionAction(IMongoCollection<BsonDocument> collection)
        {
            this.collection = collection;
        }

        public void InsertOne(string firstName ,string lastName,int age ,string[] tags)
        {
            var document = new BsonDocument
            {
                {"firstName" ,BsonValue.Create(firstName)},
                {"lastName",BsonValue.Create(lastName) },
                { "tags",BsonArray.Create(tags)},
                { "age",BsonInt32.Create(age)}
            };
            //var b = new BsonDocument();
            //b.Add();
          
            collection.InsertOne(document);
        }
        public void InserMany(string firstName, string lastName, int age, string[] tags)
        {
            List<BsonDocument> elements = new List<BsonDocument>();
            for (int i = 0; i < 100; i++)
            {
                var bson = new BsonDocument
                {
                      {"firstName" ,BsonValue.Create(firstName +i)},
                {"lastName",BsonValue.Create(lastName +i) },
                { "tags",BsonArray.Create(tags )},
                { "age",BsonInt32.Create(age +i)}
                };
                elements.Add(bson);
            }
            collection.InsertMany(elements);
        }

        public void FindAll()
        {
            FilterDefinition<BsonDocument> filter = FilterDefinition<BsonDocument>.Empty;
            FindOptions<BsonDocument> options = new FindOptions<BsonDocument>
            {
                BatchSize=20,
                NoCursorTimeout=false
               
            };

            using (IAsyncCursor<BsonDocument> cursor=collection.FindAsync(filter,options).Result)
            {
                while (cursor.MoveNext())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    foreach (BsonDocument doc in batch)
                    {
                        Console.WriteLine(doc);
                        Console.WriteLine();
                    }
                    Console.WriteLine("-----------------");

                }
            }

        }
        public void FindFiltter()
        {
            FilterDefinition<BsonDocument> filter =new FilterDefinitionBuilder<BsonDocument>().Gt("age",60);
            FindOptions<BsonDocument> options = new FindOptions<BsonDocument>
            {
                BatchSize = 20,
                NoCursorTimeout = false

            };

            using (IAsyncCursor<BsonDocument> cursor = collection.FindAsync(filter, options).Result)
            {
                while (cursor.MoveNext())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    foreach (BsonDocument doc in batch)
                    {
                        Console.WriteLine(doc);
                        Console.WriteLine();
                    }
                    Console.WriteLine("-----------------");

                }
            }

        }
        public void InsertOneBson(BsonDocument bsons)
        {
            collection.InsertOne(bsons);
        }
    }
}
