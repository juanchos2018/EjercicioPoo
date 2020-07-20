using EjercicioPoo2Unidad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
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
        static void Main(string[] args)
        {
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
                default:
                    break;
            }

        }

        private static void verEntrenadñlistaLcubJUgdor()
        {

            Club_Jugador o = new Club_Jugador();
            Console.WriteLine("-------------------ide juadir       id  club");
            foreach (Club_Jugador item in o.litarTodo())
            {
                Console.WriteLine("------------"+item.id_jugador + "  ,  " + item.id_club);
            }
        }

        private static void AsignarClub_Jugador()
        {
            Jugador j = new Jugador();

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
                if (e.existe(code_entreador))
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

            Console.WriteLine("----------Elijio ek  Clucb + ");

            EntrenadorClub entre = new EntrenadorClub();

            //e.id_entrenador = code_entreador;
            //e.nombre = nombre_entrenador;
            //clu.codigo_club = id_club;
            //clu.nombre_club = nombre_entrenador;
            //entre.fecha_registro = DateTime.Now;
            //entre.entrenador = e;
            //entre.club = clu;

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
            Club o1 = new Club();
            Console.WriteLine("codigo jugador");

            o.id_jugador = Console.ReadLine();
            Console.WriteLine("Nombre jugador");
            o.nombre = Console.ReadLine();
            Console.WriteLine("Apellido jugador");
            o.apellido = Console.ReadLine();
            o.RegistrarJugador(o);
            Console.WriteLine("Registrado Jugador  ");
            Console.Clear();

            //   Console.WriteLine(" Tipo de Demarcacion");
            ////   Demarcacion demarcacion;
            //   Console.WriteLine("  1) Tipo : " + Demarcacion.arquero);
            //   Console.WriteLine("  2) Tipo : " + Demarcacion.defensa);
            //   Console.WriteLine("  3) Tipo : " + Demarcacion.delantero);
            //   Console.WriteLine("  4) Tipo : " + Demarcacion.volante);

            //   string op = Console.ReadLine();
            //   switch (op)
            //   {
            //       case "1":
            //           o.demarcacion = Demarcacion.arquero;
            //           break;
            //       case "2":
            //           o.demarcacion = Demarcacion.defensa;
            //           break;
            //       case "3":
            //           o.demarcacion = Demarcacion.delantero;
            //           break;
            //       case "4":
            //           o.demarcacion = Demarcacion.volante;
            //           break;
            //       default:
            //           Console.WriteLine(" opcion no valida    ");
            //           break;
            //   }
            ///  Demarcacion demarcacion;
            ///  
            //    var a = Demarcacion.arquero;

            //  demarcar = Demarcacion.arquero;
            //  o.demarcacion =demarcacion.;

            //Console.WriteLine("Elija a que club pertenece \n");
            //Console.WriteLine("Codigo  Club   ,   Nombre Club");
            //foreach (Club item in o1.ListarClub())
            //{
            //    Console.WriteLine(item.codigo_club + " ," + item.nombre_club);

            //}

            //string codigoclub = Console.ReadLine();
            //if (o1.exixteclub(codigoclub))
            //{
            //    o1.codigo_club = codigoclub;
            //    o.club = o1;
            //    o.fecha_registro = DateTime.Now;
            //    o.RegistrarJugador(o);
            //    Console.WriteLine("Registrado Jugador  ");

            //}
            //else
            //{
            //    Console.WriteLine("Codigo  de club no existe ");

            //}

            menu();
        }

        private static void listarEntrenador()
        {
            Entrenador o = new Entrenador();

            Console.WriteLine("--------------------------LISTA DE ENTRENADORES------\n");
            Console.WriteLine(" ------------Codio club | nombre club  |  cid entrenador |  nombre entrenador");

            foreach (Entrenador item in o.ListaEntrenador())
            {
                //  Console.WriteLine( item.club.codigo_club+"   , "+ item.club.nombre_club+",  "+item.id_entrenador+",  "+item.nombre);
                Console.WriteLine("----------------- "+item.id_entrenador + "   , " + item.nombre);
            }
            menu();
        }

        private static void registroEntrenador()
        {
            Entrenador o = new Entrenador();
            Club o1 = new Club();
            Console.WriteLine("codigo entrenador");

            o.id_entrenador = Console.ReadLine();
            Console.WriteLine("Nombre entrenador");
            o.nombre = Console.ReadLine();
            Console.WriteLine("Apellido entrenador");
            o.apellido = Console.ReadLine();
            o.fecha_registro = DateTime.Now;

            o.registrEntrenador(o);
            Console.WriteLine("Registrado Entrenador  ");

            //Console.WriteLine("Elija a que club pertenece \n");
            //Console.WriteLine("Codigo  Club   ,   Nombre Club");

            //foreach (Club item in o1.ListarClub())
            //{
            //    Console.WriteLine(item.codigo_club + " ," + item.nombre_club);

            //}

            //string codigoclub = Console.ReadLine();
            //if (o1.exixteclub(codigoclub))
            //{
            //    o1.codigo_club = codigoclub;
            //    o.club = o1;
            //    o.fecha_registro = DateTime.Now;
            //    o.registrEntrenador(o);
            //    Console.WriteLine("Registrado Entrenador  ");

            //}
            //else
            //{
            //    Console.WriteLine("Codigo  de club no existe ");

            //}

            menu();


        }

        private static void listarclub()
        {
            Club o = new Club();

            Console.WriteLine("--------------------------LISTA DE CLUBES------\n");
            foreach (Club item in o.ListarClub())
            {

                Console.WriteLine(item.codigo_club+" ,"+ item.nombre_club);
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
