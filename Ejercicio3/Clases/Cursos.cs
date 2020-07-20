using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Clases
{
    class Cursos:ClsInterface<Cursos>
    {
        public string codigo_curso { get; set; }
        public string nombre_curso { get; set; }          

        public List<Cursos> Listar()
        {
            var query = new List<Cursos>();
            foreach (var item in Program.listCursos)
            {
                query.Add(item);
            }
            return query;
        }

        public void Registrar(Cursos o)
        {
            Program.listCursos.Add(o);
        }    

        public bool existe(string code)
        {
            bool exi = false;
            var query = Program.listCursos.Where(x => x.codigo_curso == code).ToList();
            if (query.Count > 0)
            {
                exi = true;
            }
            else
            {
                exi = false;
            }

            return exi;
        }

        public Cursos datos(string code)
        {
            var doc = new Cursos();
            try
            {
               
                doc = Program.listCursos.Where(x => x.codigo_curso == code).SingleOrDefault();
               
            }
            catch (Exception ex)
            {
                throw;
            }
            return doc;
        }

    }
}
