using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDog.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string ImagUrl { get; set; }
    }
}
