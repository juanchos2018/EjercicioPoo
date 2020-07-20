using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo2Unidad.Clases
{
    class Medico : Persona
    {
        public string id_medico { get; set; }

        //  public int MyProperty { get; set; }

        public void RegistarMedico(Medico o)
        {
            Program.ListdeMedicos.Add(o);

        }

        public List<Medico> ListarMedico()
        {

            //   List<Club> lista = new List<Club>();
            var query = new List<Medico>();
            foreach (var item in Program.ListdeMedicos)
            {
                query.Add(item);
            }
            return query;


        }

    }
}
