using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MAvilaS7
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public String Nombre { get; set; }
        [ MaxLength (50)]
        public String Usuario { get; set; }
        [MaxLength (50)]
        public String Contrasena { get; set;}
    }
}
