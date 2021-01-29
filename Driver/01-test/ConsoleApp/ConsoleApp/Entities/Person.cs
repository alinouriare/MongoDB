﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
   public class Person
    {
        public Person()
        {
            Id = ObjectId.GenerateNewId().ToString();

        }

        public string Id { get; private set; }

        public int Age { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string[] Tags { get; set; }
    }
}
