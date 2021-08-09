using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectTecni.Models
{
    public class Address
    {
        [PrimaryKey,AutoIncrement]
        public int IdAddress { get; set; }
        public int IdPerson { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
