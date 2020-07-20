using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Clases
{
    class Estudiante:Persona,ClsInterface<Estudiante>
    {
        public string codigo_estudiante { get; set; }
        public string clave_estudiante { get; set; }

     //   public Cursos cursos { get; set; }
     //   public Notas notas { get; set; }

        public double promedio { get; set; }    

        public List<Estudiante> Listar()
        {
            var query = new List<Estudiante>();
            foreach (var item in Program.listEstudiantes)
            {
                query.Add(item);
            }
            return query;
        }

        public void Registrar(Estudiante o)
        {
            Program.listEstudiantes.Add(o);
        }

            public bool existe(string code)
            {
                bool exi = false;
                var query = Program.listEstudiantes.Where(x => x.codigo_estudiante == code).ToList();
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

            public Estudiante datos(string code)
            {
                var doc = new Estudiante();

                doc = Program.listEstudiantes.Where(x => x.codigo_estudiante == code).SingleOrDefault();

                return doc;
            }

        //public void RegistrarEstudiante(Estudiante o)
        //{
        //    Program.listEstudiantes.Add(o);

        //}
        //public List<Cursos> ListarEStudiantes()
        //{
        //    var query = new List<Cursos>();
        //    foreach (var item in Program.listCursos)
        //    {
        //        query.Add(item);
        //    }
        //    return query;


        //}

    }
}
