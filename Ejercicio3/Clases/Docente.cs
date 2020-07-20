using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Clases
{
    class Docente:Persona, ClsInterface<Docente>
    {
        public string codigo_docente { get; set; }
        public string clave_docente { get; set; }

        public DateTime fecha_creacion { get; set; }

        //public Cursos cursos { get; set; }

       

        public void Registrar(Docente o)
        {
            Program.listDocentes.Add(o);
        }

        public List<Docente> Listar()
        {
            var query = new List<Docente>();
            foreach (var item in Program.listDocentes)
            {
                query.Add(item);
            }
            return query;

        }

        public bool existe(string code)
        {
            bool exi = false;
            var query = Program.listDocentes.Where(x => x.codigo_docente == code).ToList();
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

        //public string datos2(string code)
        //{
        //    string nombre="";
        //    var query = Program.listDocentes.Where(x => x.codigo_docente == code).ToList();

        //    foreach (Docente item in query)
        //    {
        //        nombre = item.nombre;
        //    }

        //    return nombre;
        //}

        public Docente datos(string code)
        {
            var doc = new Docente();          
             
             doc = Program.listDocentes.Where(x => x.codigo_docente ==code).SingleOrDefault();  
           
            return doc;
        }

        public bool login(string code,string clave)
        {
            bool    existe = false;
            var query = Program.listDocentes.Where(x => x.codigo_docente == code && x.clave_docente==clave).ToList();

            if (query.Count>0)
            {
                existe = true;
            }
            else
            {
                existe = false;

            }
            return existe;

        }

        public List<CursoDocente> Miscrusos(string iddocente)
        {
            //var query = Program.listCursoDocente.Where(x => x.docente.codigo_docente == iddocente).ToList();
            //return query;
            List<CursoDocente> lista = new List<CursoDocente>();            
            var quer2 = (from p1 in Program.listCursoDocente
                         join p2 in Program.listCursos on p1.cursos.codigo_curso equals p2.codigo_curso
                         orderby p1.cursos.codigo_curso
                         where p1.docente.codigo_docente == iddocente
                         select new
                         {
                             p2.nombre_curso,
                             p2.codigo_curso

                         }).ToList();

            foreach (var item in quer2)
            {
                CursoDocente a = new CursoDocente();
                Cursos a1 = new Cursos();
                a1.nombre_curso = item.nombre_curso;
                a1.codigo_curso = item.codigo_curso;

                lista.Add(new CursoDocente()
                {
                    cursos = a1

                });

            }
            return lista;

        }

    }
}
