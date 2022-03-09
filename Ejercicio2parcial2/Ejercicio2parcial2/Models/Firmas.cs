using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2parcial2.Models
{
    public class  Firmas
    {
        [PrimaryKey, AutoIncrement]
        public Int32 Id { get; set; }

        public String firma { get; set; }

        
        public String nombre { get; set; }
        public String Descrip { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
