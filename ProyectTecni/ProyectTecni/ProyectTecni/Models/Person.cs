using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectTecni.Models
{
    public class Person
    {
        [PrimaryKey,AutoIncrement]
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
    }
}
