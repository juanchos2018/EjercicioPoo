using EjercicioPoo2Unidad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace EjercicioPoo2Unidad
{
    class Program
    {


        public static List<Club> ListdeClubes = new List<Club>();
        public static List<Entrenador> ListdeEntrenador = new List<Entrenador>();
        public static List<Jugador> ListdeJugador = new List<Jugador>();
        public static List<Medico> ListdeMedicos = new List<Medico>();
        public static List<EntrenadorClub> ListEntrendorClub = new List<EntrenadorClub>();
        public static List<Club_Jugador> ListJugadorClub = new List<Club_Jugador>();
        public static List<Partido> ListEquipoJugar = new List<Partido>();

        public static int id_partido=1;
        static void Main(string[] args)
        {

            ///

            //int n1;
            //int n2;
            //for (int i = 0; i < 7; i++)
            //{
            //    n1 = rd1.Next(0, 7);
            //    n2 = rd1.Next(0, 7);

            //    while (n1 == n2)
            //    {
            //        n2 = rd1.Next(0, 7);
            //    }

            //    Console.WriteLine(n1 + "   ------------    " + n2);
            //    Thread.Sleep(2000);
            //}
            KemerDAtos();
            menu();
        
          
            Console.ReadKey();

        }

        private static void menu()
        {
            Console.WriteLine("============================================");
            Console.WriteLine(" 1 ) Registrar Club  ");
            Console.WriteLine(" 2 ) Registrar Entrenador  ");
            Console.WriteLine(" 3 ) Registrar Jugador  ");
            Console.WriteLine(" 4 ) Registrar Medico  ");
            Console.WriteLine(" 5 ) Registrar Nutricionista  ");

            Console.WriteLine(" 6 ) Listar Club  ");
            Console.WriteLine(" 7 ) Listar Entrenador  ");
            Console.WriteLine(" 8 ) Listar Jugadores  ");
            Console.WriteLine(" 9 ) Listar Medicos  ");
            Console.WriteLine(" 10 ) Asignar Club a Entrenador ");
            Console.WriteLine(" 11 ) Asignar Jugador  a Club ");


            Console.WriteLine(" 12 ) Ver Club -Entrenador  Todos ");
            Console.WriteLine(" 13 ) Ver Club -Jugador Todos ");
            Console.WriteLine(" 14 ) Registrar  Club para el Partido");
            Console.WriteLine(" 15 ) Empezar Partido");
            Console.WriteLine(" 16 ) Resultados ...");
            Console.WriteLine("============================================");



            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":

                    registroclub();
                    break;
                case "2":

                    registroEntrenador();
                    break;
                case "3":

                    registroJugador();
                    break;

                case "4":

                    registroMedico();
                    break;

                case "6":
                    listarclub();
                    break;
                case "7":
                    listarEntrenador();
                    break;
                case "8":
                    listarJugador();
                    break;
                case "9":
                    listarMedico();
                    break;
                case "10":
                    AsignarClubEntrenador();
                    break;
                case "11":
                    AsignarClub_Jugador();
                    break;
                case "12":
                    verEntrenadorClub();
                    break;
                case "13":
                    verEntrenadñlistaLcubJUgdor();
                    break;
                case "14":
                    RegistrarPartido();
                    break;
                case "15":

                    EmpezarPartido();
                //    verResultados();
                    break;
                case "16":

                      //EmpezarPartido();
                        verResultados();
                    break;
                default:
                    break;
            }

        }

        private static void EmpezarPartido()
        {
            try
            {

                Console.WriteLine("lista de equipos por Jugar");
                Console.WriteLine("#            Nomre Club               Nombre Club");
                foreach (Partido item in ListEquipoJugar)
                {
                    if (item.estadopartido.Equals("NoComienza"))
                    {
                        Console.WriteLine(item.id_partido + "    " + item.nombre_equipo_1 + "  " + item.nombre_equipo_2 + "  " + item.estadopartido);

                    }

                }

                Console.WriteLine("elija que numero");
                string opcion = Console.ReadLine();
                Partido o = new Partido();
                string c1 = o.datos(opcion).codigo_equipo_1;
                string c2 = o.datos(opcion).codigo_equipo_2;

                QueComienzeElJuego(c1, c2, opcion);
            }
            catch (Exception)
            {

                throw;
            }
        
        }

        private static void QueComienzeElJuego(string c1, string c2, string id)
        {
            Club no = new Club();
            Partido o = new Partido();
            string nombre1 = no.datos(c1).nombre_club;
            string nombre2 = no.datos(c2).nombre_club;
            Random rd1 = new Random();
            int n1 = 0;
            int n2 = 0;
            int t;
            Console.WriteLine(nombre1 + "                   " + nombre2);
            Console.WriteLine(n1 + "   ------------    " + n2);
            for (int i = 0; i < 7; i++)
            {
                t = rd1.Next(0, 2); //0   1
                if (t == 1)
                {
                    n1++;  //
                }
                else
                {
                    n2++;//0
                }
                Console.WriteLine(n1 + "   ------------    " + n2);
                Thread.Sleep(2000);
            }

            string equipoganador;
            Console.WriteLine("-- Resultado -- ");
            if (n1 > n2)
            {
                Console.WriteLine("El ganador es club " + nombre1);
                equipoganador = nombre1;
            }
            else if (n1 == n2)
            {
                Console.WriteLine("Empate");
                equipoganador = "Emapate";
            }
            else
            {
                Console.WriteLine("El ganador es Equipo 2" + nombre2);
                equipoganador = nombre2;
            }

            Partido ob = new Partido();
            foreach (Partido item in ListEquipoJugar)
            {
                if (item.id_partido.Equals(id))
                {
                    item.estadopartido = "Terminado";
                    item.goles_equipo_1 = n1;
                    item.goles_equipo_2 = n2;
                    item.fecha = DateTime.Now;
                    item.equipoGanador = equipoganador;
                }
            }


            Console.WriteLine("Temino");
            Console.WriteLine("----Enter para continuar");
            Console.ReadLine();
              menu();
        }

        private static void verResultados()
        {
            Console.WriteLine("===============================      RESULTADOS       ================================\n");
            Console.WriteLine("===============================================================================\n");
            foreach (Partido item in ListEquipoJugar)
            {
                if (item.estadopartido.Equals("Terminado"))
                {

                    Console.WriteLine("         " + item.nombre_equipo_1 + "  ( " + item.goles_equipo_1 + "," + item.goles_equipo_2 + " )" + item.nombre_equipo_2 + "      " + item.estadopartido + "-------------------   " + item.equipoGanador);

                }

            }

            Console.WriteLine("===============================================================================\n");   
     

        }

        private static void RegistrarPartido()
        {

            string[] equipo = new string[2];
            int contador = 0;
            Club c1 = new Club();
            Console.WriteLine("list de clubs");
            foreach (var item in c1.ListarClub())
            {
                Console.WriteLine("            " + item.codigo_club + "  " + item.nombre_club);

            }

            for (int i = 0; i < equipo.Length; i++)
            {
                Console.WriteLine("Elije  codigo el club ");
                string coodigo = Console.ReadLine();              
                equipo[contador] = coodigo;
                contador++;

            }

            Partido p = new Partido();
            Club no = new Club();
          
            string code1 =equipo[0];
            string code2 = equipo[1];

            string n1 = no.datos(code1).nombre_club;
            string n2 = no.datos(code2).nombre_club;

            p.id_partido = id_partido.ToString();


            p.codigo_equipo_1 = equipo[0];
            p.codigo_equipo_2 = equipo[1];

            p.nombre_equipo_1 = n1;
            p.nombre_equipo_2 = n2;
            p.fecha = DateTime.Now;
            p.estadopartido = "NoComienza";
            p.RegistrarPartido(p);

            id_partido++;          

            Console.WriteLine("Registrado");

            Console.Clear();
            menu();

         

        
                


        }

        private static void verEntrenadñlistaLcubJUgdor()
        {

            Club_Jugador o = new Club_Jugador();
            Console.WriteLine("----------------   club      Nombre jugador                  tipo");
            foreach (Club_Jugador item in o.litarTodo())
            {
               // Console.WriteLine("------------"+item.id_jugador + "  ,  "  +item.id_club);
                Console.WriteLine(" |   " + item.club.nombre_club + ",     " + item.jugador.nombre + ", " + item.demarcacion);
            }

            menu();
        }

        private static void AsignarClub_Jugador()
        {
            Jugador j = new Jugador();

            listarJugador2();

            Console.WriteLine("------------------------Agregar jugadir a un club--- \n");
            bool existejuador = true;
            string id_jugador = "";
            string nombr_jugador = "";
            while (existejuador)
            {
                Console.WriteLine("----------------Esciba el codigo del jugador \n");
                id_jugador = Console.ReadLine();
                if (j.existe(id_jugador))
                {
                    nombr_jugador = j.datos(id_jugador).nombre;
                    existejuador = false;
                }
                else
                {
                    Console.WriteLine("------------este juagdir no existe  We");
                    existejuador = true;
                }
                
            }

            Club_Jugador cu = new Club_Jugador();
            Console.WriteLine("       Tipo de Demarcacion para el  Jugador "+ nombr_jugador);
            //   Demarcacion demarcacion;
            Console.WriteLine("  1) Tipo : " + Demarcacion.arquero);
            Console.WriteLine("  2) Tipo : " + Demarcacion.defensa);
            Console.WriteLine("  3) Tipo : " + Demarcacion.delantero);
            Console.WriteLine("  4) Tipo : " + Demarcacion.volante);

            Console.WriteLine(" Elija ek tipo de  Demarcacion");

            string op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    cu.demarcacion = Demarcacion.arquero;
                    break;
                case "2":
                    cu.demarcacion = Demarcacion.defensa;
                    break;
                case "3":
                    cu.demarcacion = Demarcacion.delantero;
                    break;
                case "4":
                    cu.demarcacion = Demarcacion.volante;
                    break;
                default:
                    Console.WriteLine(" opcion no valida    ");
                    break;
            }

           

            Club clu = new Club();

            Console.WriteLine("------------------- Lista de Clubes    ");
            foreach (Club item in clu.ListarClub())
            {
                Console.WriteLine("       "+item.codigo_club+"     "+ item.nombre_club);
            }

            bool exiteclub=true;

            string codi_club="";
            string nombre_club = "";
            while (exiteclub)
            {
                Console.WriteLine("-----------esciba el codigo del club             \n");

                codi_club = Console.ReadLine();
                if (clu.exixteclub(codi_club))
                {
                    nombre_club = clu.datos(codi_club).nombre_club;
                 
                    exiteclub = false;
                }
                else
                {
                    Console.WriteLine("     ----ese club no existe  WE ");
                    exiteclub = true;
                }

                   
             }
            cu.id_jugador = id_jugador;
            cu.id_club = codi_club;
            cu.fecha_creacion = DateTime.Now;
            cu.RegistarClub_jugador(cu);


            Console.WriteLine("=========================      Jugadores del Club     " + nombre_club + "\n");

            foreach (Club_Jugador item in cu.litarClubJugador_idClub(codi_club))
            {
                Console.WriteLine(" |   " + item.club.nombre_club + ",     " + item.jugador.nombre + ", " + item.demarcacion);

            }
            Console.WriteLine("========================================================================== \n");
            Console.WriteLine("\n");

            Console.WriteLine("     ----eRegistado  WE ");
            Console.WriteLine("     ----Enter para continuar  W ");
            Console.ReadLine();

            Console.Clear();
            menu();


            

        }

        private static void verEntrenadorClub()
        {
            Console.WriteLine("--------------lista de entreadoir y su club we \n" );
            EntrenadorClub e = new EntrenadorClub();

            Console.WriteLine(" -----------id club | nombre club |   id entrenador | nombre entrenador  \n");
            foreach (EntrenadorClub item in e.listaEntrenadorClub())
            {
                Console.WriteLine("      "+item.club.codigo_club + "," + item.club.nombre_club + " ." + item.entrenador.id_entrenador + " , " + item.entrenador.nombre);
                
            }
            menu();

        }

        private static void AsignarClubEntrenador()
        {
            Entrenador e = new Entrenador();
            Console.WriteLine("------Elija que entrenador-----");

            foreach (Entrenador item in e.ListaEntrenador())
            {
                Console.WriteLine(item.id_entrenador+", "+item.nombre);


            }

            string code_entreador = "";
            string nombre_entrenador = "";
            bool exi = true;
            while (exi)
            {
                Console.WriteLine("----------------escriba el codigo delentrenadir ---");
                 code_entreador = Console.ReadLine();
                if (e.existe(code_entreador))//
                    
                {
                    nombre_entrenador = e.datos(code_entreador).nombre;
                    exi = false;
                }
                else
                {
                    Console.WriteLine("-----------ese codigo no exite we---");
                    exi = true;
                }

            }

            Console.WriteLine("-----------------Elijio el entrandor  : " + nombre_entrenador);
            Club clu = new Club();

            Console.WriteLine("----------------- Lista de clubes  : \n ");
            foreach (Club item in clu.ListarClub())
            {
                Console.WriteLine(item.codigo_club + " ," + item.nombre_club);
            }
            
            string id_club = "";
            bool exi2 = true;
            string nomnbre_club = "";
            while (exi2)
            {
                Console.WriteLine("--------------elijaa el club que va ea etrenar \n");
                id_club = Console.ReadLine();

                if (clu.exixteclub(id_club))
                {
                    nomnbre_club = clu.datos(id_club).nombre_club;
                    exi2 = false;
                }
                else
                {
                    Console.WriteLine("-------------------El codigo de clun no existe we");
                    exi2 = true;
                }               
            }

            Console.WriteLine("----------Elijio ek  Clucb + "+ nomnbre_club);

            EntrenadorClub entre = new EntrenadorClub();
             

            entre.id_entrenador = code_entreador;
            entre.id_club = id_club;
            entre.RegistrarClubEntrenador(entre);

            Console.WriteLine("REtgistradi entrenadir al club we");

            Console.Clear();
            menu();
        }

        private static void KemerDAtos()
        {
            Club clu1 = new Club();
            clu1.codigo_club = "1";
            clu1.nombre_club = "Sporting Cristal";
            clu1.RegistrarClub(clu1);

            Club clu2 = new Club();
            clu2.codigo_club = "2";
            clu2.nombre_club = "Lon Yanquiss";
            clu2.RegistrarClub(clu2);

            Club clu3 = new Club();
            clu3.codigo_club = "3";
            clu3.nombre_club = "River Plate";
            clu3.RegistrarClub(clu3);


            Club clu4 = new Club();
            clu4.codigo_club = "4";
            clu4.nombre_club = "La U";
            clu4.RegistrarClub(clu4);

            Club clu5 = new Club();
            clu5.codigo_club = "5";
            clu5.nombre_club = "Alianza Lima";
            clu5.RegistrarClub(clu5);




            Entrenador e1 = new Entrenador();
            e1.id_entrenador = "111";
            e1.nombre = "Kiara";
            e1.apellido = "ERes mi Amor --";
            e1.fecha_registro = DateTime.Now;
            e1.registrEntrenador(e1);

            Entrenador e2 = new Entrenador();
            e2.id_entrenador = "222";
            e2.nombre = "Yesica";
            e2.apellido = "Loquis";
            e2.fecha_registro = DateTime.Now;
            e2.registrEntrenador(e2);

            Entrenador e3 = new Entrenador();
            e3.id_entrenador = "333";
            e3.nombre = "Andres";
            e3.apellido = "CAla,aro";
            e3.fecha_registro = DateTime.Now;
            e3.registrEntrenador(e3);


            Jugador ju1 = new Jugador();
            ju1.id_jugador = "111";
            ju1.nombre = "Pepe lucho";
            ju1.apellido = "Gordo";
            ju1.fecha_registro = DateTime.Now;
            ju1.RegistrarJugador(ju1);

            Jugador ju2 = new Jugador();
            ju2.id_jugador = "222";
            ju2.nombre = "Jose Edi";
            ju2.apellido = "Sonso";
            ju2.fecha_registro = DateTime.Now;
            ju2.RegistrarJugador(ju2);

            Jugador ju3 = new Jugador();
            ju3.id_jugador = "333";
            ju3.nombre = "Diego";
            ju3.apellido = "CArdesas";
            ju3.fecha_registro = DateTime.Now;
            ju3.RegistrarJugador(ju3);


            Jugador ju4 = new Jugador();
            ju4.id_jugador = "444";
            ju4.nombre = "Santiago lucho";
            ju4.apellido = "rissas";
            ju4.fecha_registro = DateTime.Now;
            ju4.RegistrarJugador(ju4);

            Jugador ju5 = new Jugador();
            ju5.id_jugador = "555";
            ju5.nombre = "Pele Brasilero";
            ju5.apellido = "brasil";
            ju5.fecha_registro = DateTime.Now;
            ju5.RegistrarJugador(ju5);

            Jugador ju6 = new Jugador();
            ju6.id_jugador = "666";
            ju6.nombre = "Ronslandino";
            ju6.apellido = "Ronsladino";
            ju6.fecha_registro = DateTime.Now;
            ju6.RegistrarJugador(ju6);

            Jugador ju7 = new Jugador();
            ju7.id_jugador = "777";
            ju7.nombre = "Iniesta";
            ju7.apellido = "iniesta";
            ju7.fecha_registro = DateTime.Now;
            ju7.RegistrarJugador(ju7);


        }

        private static void listarMedico()
        {
            Medico o = new Medico();
            Console.WriteLine(" id medoco | nombre   |  apellido |  ");

            foreach (Medico item in o.ListarMedico())
            {
                Console.WriteLine(item.id_medico + "   , " + item.nombre + ",  " + item.apellido);

            }
            menu();
        }
   

        private static void registroMedico()
        {
            Medico o = new Medico();
            Console.WriteLine("Ingrese el codigo de medico");
            o.id_medico = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del medico");
            o.nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del medico");
            o.apellido = Console.ReadLine();
            o.RegistarMedico(o);
            Console.WriteLine("Medico  Registrado We");
            Console.WriteLine("\n");
            Console.Clear();
            menu();

        }

        private static void listarJugador()
        {
            Jugador o = new Jugador();
            Console.WriteLine("--------------------------LISTA DE JUGADORES------\n");
            Console.WriteLine(" ------------ Codio jugadr | nombre mjuagdir  ");

            foreach (Jugador item in o.ListaJuagador())
            {
                Console.WriteLine("-----------------   "+item.id_jugador + " , " + item.nombre);

            }
            menu();
        }
        private static void listarJugador2()
        {
            Jugador o = new Jugador();
            Console.WriteLine("--------------------------LISTA DE JUGADORES------\n");
            Console.WriteLine(" ------------ Codio jugadr | nombre mjuagdir  ");

            foreach (Jugador item in o.ListaJuagador())
            {
                Console.WriteLine("-----------------   " + item.id_jugador + " , " + item.nombre);

            }
         
        }

        Demarcacion demarcar;
        public Demarcacion Demarcar
        {
            get
            {
                return demarcar;
            }

            set
            {
                demarcar = value;
                // SetFormState();
            }
        }

        private static void registroJugador()
        {
            Jugador o = new Jugador();
         //   Club o1 = new Club();
            Console.WriteLine("codigo jugador");

            o.id_jugador = Console.ReadLine();
            Console.WriteLine("Nombre jugador");
            o.nombre = Console.ReadLine();
            Console.WriteLine("Apellido jugador");
            o.apellido = Console.ReadLine();
            o.RegistrarJugador(o);
            Console.WriteLine("Registrado Jugador  ");
            Console.Clear();

         

            menu();
        }

        private static void listarEntrenador()
        {
            Entrenador o = new Entrenador();
            Console.WriteLine("--------------------------LISTA DE ENTRENADORES------\n");
            Console.WriteLine(" ------------  cid entrenador |  nombre entrenador  |   fECHA");

            foreach (Entrenador item in o.ListaEntrenador())
            {
                //  Console.WriteLine( item.club.codigo_club+"   , "+ item.club.nombre_club+",  "+item.id_entrenador+",  "+item.nombre);
                Console.WriteLine("----------------- "+item.id_entrenador + "   , " + item.nombre+ "  "  + item.fecha_registro);
            }
            menu();
        }

        private static void registroEntrenador()
        {
            Entrenador o = new Entrenador();
         
            Console.WriteLine("codigo entrenador");

            o.id_entrenador = Console.ReadLine();
            Console.WriteLine("Nombre entrenador");
            o.nombre = Console.ReadLine();
            Console.WriteLine("Apellido entrenador");
            o.apellido = Console.ReadLine();
            o.fecha_registro = DateTime.Now;

            o.registrEntrenador(o);
            Console.WriteLine("Registrado Entrenador  ");

          

            menu();


        }

        private static void listarclub()
        {
            Club o = new Club();

            Console.WriteLine("--------------------------LISTA DE CLUBES------\n");
            Console.WriteLine("                codi club-  Nombe Club");
            foreach (Club item in o.ListarClub())
            {

                Console.WriteLine("              "+item.codigo_club+"    "+ item.nombre_club);
            }
           // Console.Clear();
            menu();
        }

        private static void registroclub()
        {
            Club o = new Club();
            Console.WriteLine("Ingrese el codigo del club");
            o.codigo_club = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del club");
            o.nombre_club = Console.ReadLine();
            o.RegistrarClub(o);
            Console.WriteLine("Club  Registrado We");
            Console.WriteLine("\n");
            Console.Clear();
            menu();


        }
    }
}
