using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Clases
{
    class Matriculados
    {
        public Estudiante estudiantes { get; set; }
        public Cursos curso { get; set; }


        public void Registrar(Matriculados o)
        {
            Program.listMatriculados.Add(o);
        }

        public List<Matriculados> alumnincurso(string codecurso)
        {
            var query = Program.listMatriculados.Where(x => x.curso.codigo_curso == codecurso).ToList();
            return query;

        }
    }
}
