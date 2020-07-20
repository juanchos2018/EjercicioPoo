using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo2Unidad.Clases
{
    class Entrenador:Persona
    {
        public string id_entrenador { get; set; }
        public DateTime fecha_registro { get; set; }   
        public Club club { get; set; }

        public void registrEntrenador(Entrenador o)
        {
            Program.ListdeEntrenador.Add(o);

        }

        public List<Entrenador> ListaEntrenador()
        {
            List<Entrenador> lista = new List<Entrenador>();

            var query = Program.ListdeEntrenador.ToList();
            foreach (var item in query)
            {
                lista.Add(item);

            }

            return lista;
            
        }

    
        public List<Entrenador> ListarEntrenadorClub()
        {
              List<Entrenador> lista = new List<Entrenador>();
            //   var quer2 = Program.ListdeEntrenador.Join(Program.ListdeClubes, e=>e.id_entrenador,c=>c. )
            var quer2 = (from pd in Program.ListdeEntrenador
                         join od in Program.ListdeClubes on pd.club.codigo_club equals od.codigo_club
                         orderby od.codigo_club
                         select new
                         {
                             od.codigo_club,
                             od.nombre_club,                             
                             pd.id_entrenador,
                             pd.nombre,
                             pd.apellido                             

                         }).ToList();


            foreach (var item in quer2)
            {
                Club a = new Club();
                a.nombre_club = item.nombre_club;
                a.codigo_club = item.codigo_club;
                lista.Add(new Entrenador()
                {
                    id_entrenador=item.id_entrenador,
                    nombre = item.nombre,
                    apellido=item.apellido,
                    club = a
                });
                
            }            
          
            return lista;


        }


        public bool existe(string code)
        {
            bool exi = false;
            var query = Program.ListdeEntrenador.Where(x => x.id_entrenador == code).ToList();
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

            public Entrenador datos(string code)
            {
                var doc = new Entrenador();
                doc = Program.ListdeEntrenador.Where(x => x.id_entrenador == code).SingleOrDefault();
                return doc;
            }


    }
}
