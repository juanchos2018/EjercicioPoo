using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Clases
{
    class Asistencia:ClsInterface<Asistencia>
    {
        public string dia { get; set; }
        public bool asiste { get; set; }

        public Estudiante estudiante { get; set; }
        public Cursos curso { get; set; }

        public string id_curso { get; set; }
        public void Registrar(Asistencia o)
        {
            Program.listAsistencia.Add(o);

        }
        public List<Asistencia> Listar()
        {
            throw new NotImplementedException();
        }
        public bool existe(string code)
        {
            throw new NotImplementedException();
        }

      

      
    }
}
