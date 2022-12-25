using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandrUrsu_ApiMaps.Models
{
    public class Favorite
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }
        public String Phone { get; set; }

        public String Website { get; set; }

    }
}
