using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo2Unidad.Clases
{
     public  class Club
    {
        public string  codigo_club { get; set; }
        public string  nombre_club { get; set; }


        public void RegistrarClub(Club o)
        {

            Program.ListdeClubes.Add(o);
        }
        public List<Club> ListarClub()
        {

         //   List<Club> lista = new List<Club>();
            var query = new List<Club>();
            foreach (var item in Program.ListdeClubes)
            {
                query.Add(item);
            }
            return query;


        }

        public bool exixteclub(string codigoclub)
        {
            bool existe = false;

            var query = Program.ListdeClubes.Where(x => x.codigo_club == codigoclub).ToList();

            if (query.Count>0)
            {
                existe = true;
            }
            else
            {
                existe = false;
            }
            //foreach (Club item in Program.ListdeClubes)
            //{
            //    if (item.codigo_club.Equals(codigo_club))
            //    {
            //        existe = true;
            //    }
            //    else
            //    {
            //        existe = false;
            //    }
            //}
            return existe;
        }


        public Club datos(string code)
        {
            var doc = new Club();
            doc = Program.ListdeClubes.Where(x => x.codigo_club == code).SingleOrDefault();
            return doc;
        }

    }
}
