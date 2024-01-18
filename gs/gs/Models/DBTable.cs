using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace gs.Models
{
    public class Types
    {
        [PrimaryKey, AutoIncrement] 
        public int ID { get; set; }
        public string Title { get; set; }
    }
    public class Ammo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Info { get; set; }
        public string ImagePath { get; set; }
        public int TypeId { get; set; }
    }
    public class Gun
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Info { get; set; }
        public string ImagePath { get; set; }
        public int TypeId { get; set; }
        public int AmmoId { get; set; }
    }
}
