using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo2Unidad.Clases
{
    class EntrenadorClub
    {
        public Entrenador entrenador { get; set; }
        public Club club { get; set; }

        public DateTime fecha_registro { get; set; }


        public string id_club { get; set; }
        public string id_entrenador { get; set; }

        public void RegistrarClubEntrenador(EntrenadorClub o)
        {
            Program.ListEntrendorClub.Add(o);

        }


        public List<EntrenadorClub> listaEntrenadorClub()
        {
            List<EntrenadorClub> lista = new List<EntrenadorClub>();

            var quer = (from p1 in Program.ListEntrendorClub
                        join p2 in Program.ListdeEntrenador on p1.id_entrenador equals p2.id_entrenador
                        join p3 in Program.ListdeClubes     on p1.id_club       equals p3.codigo_club
                        orderby p1.club
                        select new
                        {
                            p3.codigo_club,
                            p3.nombre_club,
                            p2.id_entrenador,
                            p2.nombre

                        }).ToList();

            foreach (var item in quer)
            {
                Entrenador a = new Entrenador();
                Club c = new Club();
                a.id_entrenador = item.id_entrenador;
                a.nombre = item.nombre;
                c.codigo_club = item.codigo_club;
                c.nombre_club = item.nombre_club;


                lista.Add(new EntrenadorClub()
                {
                    entrenador = a,
                    club=c

                }) ;

            }

            return lista;
        }

    }
}
