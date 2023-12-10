
namespace WSDB.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Libros
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Precio { get; set; }
        public string AñoPublicacion { get; set; }
    }
}
