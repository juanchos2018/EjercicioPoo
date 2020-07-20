using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo2Unidad.Clases
{
    class Jugador:Persona
    {
        public string id_jugador { get; set; }
        public DateTime fecha_registro { get; set; }

        
        //public Club club { get; set; }

        public Demarcacion demarcacion { get; set; }



        public void RegistrarJugador(Jugador o)
        {
            Program.ListdeJugador.Add(o);
        }

        public bool existe(string code)
        {
            bool exi = false;
            var query = Program.ListdeJugador.Where(x => x.id_jugador == code).ToList();
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

        public Jugador datos(string code)
        {
            var doc = new Jugador();
            doc = Program.ListdeJugador.Where(x => x.id_jugador == code).SingleOrDefault();
            return doc;
        }


        public List<Jugador> ListaJuagador()
        {
            List<Jugador> lista = new List<Jugador>();

            var query = Program.ListdeJugador.ToList();
            foreach (var item in query)
            {
                lista.Add(item);

            }

            return lista;

        }

        public List<Jugador> ListarJugadorClub()
        {
            List<Jugador> lista = new List<Jugador>();
            //var quer3 = Program.ListdeEntrenador.Join(Program.ListdeClubes, e => e.id_entrenador,x).t;


         //   var quer2 = (from pd in Program.ListdeJugador
            //             join od in Program.ListdeClubes on pd.club.codigo_club equals od.codigo_club
            //             orderby od.codigo_club
            //             select new
            //             {
            //                 od.codigo_club,
            //                 od.nombre_club,
            //                 pd.id_jugador,
            //                 pd.nombre,
            //                 pd.apellido,
            //                 pd.demarcacion

            //             }).ToList();


            //foreach (var item in quer2)
            //{
            //    Club a = new Club();
            //    a.nombre_club = item.nombre_club;
            //    a.codigo_club = item.codigo_club;
            //    lista.Add(new Jugador()
            //    {
            //        id_jugador = item.id_jugador,
            //        nombre = item.nombre,
            //        apellido = item.apellido,
            //       club = a,
            //        demarcacion=item.demarcacion
            //    });

            //}

            return lista;


        }
    }
}
