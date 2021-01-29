using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
   public class MongoClientFactory
    {
        public MongoClient GetDefaultConstructor()
        {
            return new MongoClient();
        }

        public MongoClient GetConnectionString()
        {
            return new MongoClient("mongodb://localhost:27017");
        }

        public MongoClient GetUrl(bool useUrlCreator=true)
        {
            return useUrlCreator ? new MongoClient(MongoUrl.Create("mongodb://localhost:27017"))
                :
                new MongoClient(new MongoUrl("mongodb://localhost:27017"));
        }

        public MongoClient GetSetting()
        {
            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress("localhost", 27017),
                UseSsl = false
            };
            return new MongoClient(settings);
        }
    }
}
