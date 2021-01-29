using ConsoleApp.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class MongoDatabaseAction
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDatabaseAction(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public void CreateCollection(string collectionName)
        {
            _mongoDatabase.CreateCollection(collectionName);
        }

        public IMongoCollection<BsonDocument> GetBsonCollection(string collectionName)
        {
            return _mongoDatabase.GetCollection<BsonDocument>(collectionName);
        }
        public IMongoCollection<Person> GetPocoCollection(string collectionName)
        {
            return _mongoDatabase.GetCollection<Person>(collectionName);
        }
        public string GetCollectionNameList()
        {
            var result = _mongoDatabase.ListCollectionNames().ToList();
            return string.Join(",", result);
        }
    }
}
