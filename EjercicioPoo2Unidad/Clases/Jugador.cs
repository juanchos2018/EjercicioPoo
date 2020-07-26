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
            //List<Jugador> lista = new List<Jugador>();

            //var query = Program.ListdeJugador.ToList();
            //foreach (var item in query)
            //{
            //    lista.Add(item);

            //}

            var query = Program.ListdeJugador.ToList();
            return query;


        }


    }
}
