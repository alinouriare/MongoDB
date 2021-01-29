using ConsoleApp.Entities;
using MongoDB.Bson;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mongoclient = new MongoClientFactory().GetDefaultConstructor();
            // var databaseList = new MongoClientAction(mongoclient).DatabaseList();
            //if not exists database create
            var getdatabase = new MongoClientAction(mongoclient).GetDatabase("testdi");
            // new MongoDatabaseAction(getdatabase).CreateCollection("ali");
            //var collectionName = new MongoDatabaseAction(getdatabase).GetCollectionNameList();

            var bsoncollection = new MongoDatabaseAction(getdatabase).GetBsonCollection("bson");
            var personcollection = new MongoDatabaseAction(getdatabase).GetPocoCollection("person");

            //poco insert
            //PocoCollectionAction poco = new PocoCollectionAction(personcollection);
             Person p = new Person { Age=23,FirstName= "ali",LastName="nouri" ,Tags=new string[] { "T1","T2"} };
            //poco.InserOne(p);

            //bson insert
            //BsonCollectionAction bson = new BsonCollectionAction(bsoncollection);
            //bson.InsertOne("ali", "nouri", 55, new string[] { "t1", "t2" });


            //bson2 insert
            //BsonCollectionAction bson = new BsonCollectionAction(bsoncollection);
            //var bsondoc= p.ToBsonDocument();
            //bson.InsertOneBson(bsondoc);

            // bson insertMany
            //BsonCollectionAction bson = new BsonCollectionAction(bsoncollection);
            //bson.InserMany("ali", "nouri", 55, new string[] { "t1", "t2" });


            ///////find
            //BsonCollectionAction bson = new BsonCollectionAction(bsoncollection);
            //bson.FindAll();

            /// Find Filtter
            //BsonCollectionAction bson = new BsonCollectionAction(bsoncollection);
            //bson.FindFiltter();

            // poco insertMany
            //PocoCollectionAction bson = new PocoCollectionAction(personcollection);
            //bson.InserMany(p);


            //////poco FindFilteredLimit
            PocoCollectionAction bson = new PocoCollectionAction(personcollection);
            bson.FindFilteredLimit();
            Console.Read();
        }
    }
}
