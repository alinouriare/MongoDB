using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
   public class MongoClientAction
    {
        MongoClient _client;

        public MongoClientAction(MongoClient client)
        {
            _client = client;
        }

        public IMongoDatabase GetDatabase(string dbName)
        {
            return _client.GetDatabase(dbName);
        }

        public bool DropDataBase(string dbName)
        {
            _client.DropDatabase(dbName);
            return true;
        }

        public string DatabaseList()
        {
            var result = _client.ListDatabaseNames().ToList();
            return string.Join(',', result);
        }
    }
}
