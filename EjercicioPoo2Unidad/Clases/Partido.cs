using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo2Unidad.Clases
{
    class Partido
    {


        public string id_partido { get; set; }
        public string codigo_equipo_1 { get; set; }
        public string codigo_equipo_2 { get; set; }


        public string nombre_equipo_1 { get; set; }
        public string nombre_equipo_2 { get; set; }
        public DateTime fecha { get; set; }
        public int goles_equipo_1 { get; set; }
        public int goles_equipo_2 { get; set; }

        public Club club { get; set; }

        public string equipoGanador { get; set; }
        public string estadopartido { get; set; }

        public void RegistrarPartido(Partido o )
        {

            Program.ListEquipoJugar.Add(o);

        }

        public bool existeequipos(string codigo)
        {
            bool existe = false;

            var query = Program.ListEquipoJugar.Where(x => x.codigo_equipo_1 == codigo || x.codigo_equipo_2 == codigo).ToList();

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


        public  Partido datos(string id)
        {
            var dato = new Partido();

            dato = Program.ListEquipoJugar.Where(x => x.id_partido == id).SingleOrDefault();

            return dato;
        }

    

    }
}
