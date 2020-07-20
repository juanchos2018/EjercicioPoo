using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Clases
{
    class CursoDocente:ClsInterface<CursoDocente>
    {
        public Docente docente { get; set; }
        public Cursos cursos { get; set; }

        public void Registrar(CursoDocente o)
        {
            Program.listCursoDocente.Add(o);
        }
        public List<CursoDocente> Listar()
        {

            var query = new List<CursoDocente>();
            foreach (var item in Program.listCursoDocente)
            {
                query.Add(item);
            }
            return query;

        }
        public bool existe(string code)
        {
            throw new NotImplementedException();
        }

        public bool existe2(string code,string idcurso)
        {
            bool existe = false;
            var query = Program.listCursoDocente.Where(x => x.docente.codigo_docente == code && x.cursos.codigo_curso == idcurso).ToList();

            if (query.Count > 0)
            {
                existe = true;
            }
            else
            {
                existe = false;

            }
            return existe;
        }


    }
}
