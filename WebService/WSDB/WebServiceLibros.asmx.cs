using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSDB.Model;

namespace WSDB
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]


    public class WebServiceLibros : System.Web.Services.WebService
    {
        [WebMethod(Description = "")]
        public List<Libros> ObtenerLibros()
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                var Obtener = from c in db.Libros select c;
                return Obtener.ToList();
            }
        }

        [WebMethod(Description = "")]
        public string InsertarLibros(string titulo, string autor, int precio, string añoPublicaión)
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                Libros oLibro = new Libros();
                oLibro.Titulo = titulo;
                oLibro.Autor = autor;
                oLibro.Precio = precio;
                oLibro.AñoPublicacion = añoPublicaión;

                db.Libros.Add(oLibro);
                db.SaveChanges();

                return "o";
            }
        }

        [WebMethod(Description = "")]
        public string ModificarLibros(int id, string titulo, string autor, int precio, string añoPublicaión)
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                var oLibro = (from c in db.Libros where c.Id == id select c).FirstOrDefault();
                
                if(oLibro != null)
                {
                    oLibro.Titulo = titulo;
                    oLibro.Autor = autor;
                    oLibro.Precio = precio;
                    oLibro.AñoPublicacion = añoPublicaión;

                    db.SaveChanges();

                    return "";
                }
                return "";
            }
        }
        
        [WebMethod(Description = "")]
        public string EliminarLibros(int id)
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                var oLibro = (from c in db.Libros where c.Id == id select c).FirstOrDefault();

                if (oLibro != null)
                {
                    db.Libros.Remove(oLibro);
                    db.SaveChanges();

                    return "";
                }
                return "";
            }
        }
    }
}
