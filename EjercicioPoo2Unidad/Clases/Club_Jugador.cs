using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo2Unidad.Clases
{
    class Club_Jugador
    {

        public string id_jugador { get; set; }
        public string id_club { get; set; }

        public Club club { get; set; }

        public Jugador jugador { get; set; }

        public  Demarcacion demarcacion { get; set; }
        public DateTime fecha_creacion { get; set; }

        public void RegistarClub_jugador(Club_Jugador o )
        {

            Program.ListJugadorClub.Add(o);

        }

       public List<Club_Jugador> litarTodo()
        {

            List<Club_Jugador> lista = new List<Club_Jugador>();

            var query = Program.ListJugadorClub.ToList();
            foreach (var item in query)
            {
                lista.Add(item);

            }

            return lista;
        }

        public List<Club_Jugador> litarClubJugador_idClub(string id_club)
        {

            List<Club_Jugador> lista = new List<Club_Jugador>();

            var quer = (from p1 in Program.ListJugadorClub
                        join p2 in Program.ListdeClubes on p1.id_club equals p2.codigo_club
                        join p3 in Program.ListdeJugador on p1.id_jugador equals p3.id_jugador
                        orderby p1.club
                        where p2.codigo_club== id_club
                        select new
                        {
                            p2.codigo_club,
                            p2.nombre_club,                          
                            p3.nombre,
                            p3.id_jugador,
                            p1.demarcacion

                        }).ToList();

            foreach (var item in quer)
            {
                Jugador j = new Jugador();
                Club c = new Club();
                j.id_jugador  = item.id_jugador;
                j.nombre = item.nombre;
                c.nombre_club = item.nombre_club;
                c.codigo_club = item.codigo_club;
                j.demarcacion = item.demarcacion;            

                lista.Add(new Club_Jugador()
                {
                    jugador = j,
                    club = c,
                    demarcacion=demarcacion

                });

            }

            return lista;


        }



    }
}
