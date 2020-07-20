using Ejercicio3.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {

        public static List<Cursos>       listCursos = new List<Cursos>();
        public static List<Estudiante>   listEstudiantes = new List<Estudiante>();
        public static List<Docente>      listDocentes = new List<Docente>();
        public static List<CursoDocente> listCursoDocente = new List<CursoDocente>();
        public static List<Matriculados> listMatriculados = new List<Matriculados>();

        public static List<Asistencia> listAsistencia = new List<Asistencia>();
        static void Main(string[] args)
        {
            cargarCurso();
            cargarDocentes();
            cargarEStudiantes();
            menu();
        }

        private static void menu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("1 =  Agregar Cursos ");
            Console.WriteLine("2 =  Agregar Docente ");
            Console.WriteLine("3 =  Asignar Curso a Docente ");

            Console.WriteLine("4 =  Agregar Estudiante ");
            Console.WriteLine("5 =  Matricular estudiante a Curso");
            Console.WriteLine("6 =  Ver  Todos lOs Cursos");
            Console.WriteLine("7 =  Ver  Todos lOs EStudiantes");
            Console.WriteLine("8 =  Entrar como docente");
            //Console.WriteLine("6 =  ver todo");
            Console.WriteLine("================================");

            string opcion = Console.ReadLine();
            if (opcion.Equals("1"))
            {
                agregarcursos();
            }
            if (opcion.Equals("2"))
            {
                agregarDocente();
            }
            if (opcion.Equals("3"))
            {
                asigcarCursoDocnete();
            }
            if (opcion.Equals("4"))
            {
                agregarestudiante();
            }
            if (opcion.Equals("5"))
            {
                asignarcursoestudiante();
            }
            if (opcion.Equals("6"))
            {
                listarcursos();
            }
            if (opcion.Equals("7"))
            {
                listarEStudiantes();
            }
            if (opcion.Equals("8"))
            {
                logindicnete();
            }
        }

        private static void asignarcursoestudiante()
        {
            Estudiante o = new Estudiante();

            Cursos cur = new Cursos();


            bool regis = true;
            string nombreestudiante = "";
            string code_estudoante = "";
            while (regis)
            {
                Console.WriteLine("   -----Ingrese codigo de estudiante \n ");
                string code = Console.ReadLine();
                if (o.existe(code))
                {
                    regis = false;
                    //  o.datos(code);
                    nombreestudiante = o.datos(code).nombre;
                    code_estudoante = o.datos(code).codigo_estudiante;
                }
                else
                {
                    Console.WriteLine(" ----No exite ese codigo de estidnate");
                    regis = true;
                }

            }

            Console.WriteLine("Elija lis cursos para el estudiante          " + nombreestudiante);
            bool e1 = true;
            while (e1)
            {
                Cursos cu = new Cursos();
                Console.WriteLine("-----------------------Todos los cursos-----------");
                Console.WriteLine("  -------------codigo curso   | nombre curso \n ");
                foreach (Cursos item in cu.Listar())
                {
                    Console.WriteLine(item.codigo_curso + " ," + item.nombre_curso);
                }

                bool e2 = true;
                while (e2)
                {
                    string cocurso = "";
                    Console.WriteLine("Elija el codigo del curso");
                    cocurso = Console.ReadLine();
                    if (cu.existe(cocurso))
                    {
                        string nombrecurso = "";
                        string codde_curso = "";
                        nombrecurso = cur.datos(cocurso).nombre_curso;
                        codde_curso = cur.datos(cocurso).codigo_curso;
                        Console.WriteLine(" curso  " + nombrecurso + "\n");
                        o.codigo_estudiante = code_estudoante;
                        o.nombre = nombreestudiante;
                        cur.codigo_curso = codde_curso;
                        cur.nombre_curso = nombrecurso;

                        Matriculados ma = new Matriculados();
                        ma.estudiantes = o;
                        ma.curso = cur;
                        ma.Registrar(ma);

                        e2 = false;
                    }
                    else
                    {
                        Console.WriteLine("codigo de curso no existe");
                        e2 = true;
                    }
                }
                Console.WriteLine("Registrado curso a Docente");
                Console.WriteLine("Desea agregarle otro cursi mas ?");
                Console.WriteLine("-----(s/n) ----");
                string respo = Console.ReadLine();
                if (respo.Equals("s") || respo.Equals("S"))
                {
                    e1 = true;
                }
                else
                {
                    e1 = false;
                }

            }
            Console.WriteLine("Salio del Bucle");
            Console.Clear();
            menu();



            //if (o.existe(code))
            //{

            //    nombreestudiante = o.datos(code).nombre;
            //    Console.WriteLine("No Elija los cursos para el Estudiante" + nombreestudiante);
            //    Console.WriteLine("codigo curso   | nombre curso");
            //    foreach (Cursos item in cur.Listar())
            //    {
            //        Console.WriteLine(item.codigo_curso + ", " + item.nombre_curso);
            //    }

            //    bool seguir = true;

            //    while (seguir)
            //    {
            //        string cocurso = "";
            //        Console.WriteLine("Elija el codigo del curso");
            //        cocurso = Console.ReadLine();

            //        if (cur.existe(cocurso))
            //        {
            //            string nombrecurso = "";
            //            string codde_curso = "";
            //            nombrecurso = cur.datos(cocurso).nombre_curso;
            //            codde_curso = cur.datos(cocurso).codigo_curso;
            //            Console.WriteLine(" curso  " + nombrecurso + "\n");                        
            //            o.codigo_estudiante = code;
            //            o.nombre = nombreestudiante;
            //            cur.codigo_curso = codde_curso;
            //            cur.nombre_curso = nombrecurso;

            //            Matriculados ma = new Matriculados();
            //            ma.estudiantes = o;
            //            ma.curso = cur;
            //            ma.Registrar(ma);
            //            Console.WriteLine("matrculado en el curso");
            //            seguir = false;







            //        }
            //        else
            //        {
            //            Console.WriteLine("codigo de curso no existe");
            //            seguir = true;
            //        }

            //    }

            //}



        }

        private static void agregarestudiante()
        {
            Estudiante o = new Estudiante();

            Console.WriteLine("------------Codigo Estudiante");
            o.codigo_estudiante = Console.ReadLine();
            Console.WriteLine("------------Nombre Estudiante");
            o.nombre = Console.ReadLine();
            Console.WriteLine("------------Apellido Estudiante");
            o.apellido = Console.ReadLine();

            Console.WriteLine("------------clave Estudiante");
            o.clave_estudiante = Console.ReadLine();
            o.Registrar(o);
            Console.WriteLine("--------------Registrado \n ");
            Console.Clear();
            menu();



        }

        private static void logindicnete()
        {
            Docente o = new Docente();
            Console.WriteLine("---------ingrese codigo de docente");
            string codigo = Console.ReadLine();
            Console.WriteLine("-------ingrese clave de docente \n ");
            string clave = Console.ReadLine();

            string co = "";
            if (o.login(codigo, clave))
            {

              ///  menuDocente(codigo);
                menuDocente2(codigo);
            }
            else
            {
                return;
            }

        }

        private static void menuDocente2(string codigo)
        {
            Docente o = new Docente();
            string nombre;
            nombre = o.datos(codigo).nombre;
            Console.WriteLine("Bienvenido  docente   --------> " + nombre);
            Console.WriteLine("1  Ver mis  Cursos");
            Console.WriteLine("2  Entrar a clase de curso");
            Console.WriteLine("3  ingresar Notas");
            Console.WriteLine("4  Ver Asistencia");
            Console.WriteLine("5  Salir \n ");
            string op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    vermiscursos(codigo);

                    break;
                case "2":
                    EntrarClasase(codigo);

                    break;
                case "4":
                    verAsistenca(codigo);

                    break;
                default:
                    break;
            }

        }
        private static void cargarCurso()
        {
            Cursos o1 = new Cursos();
            o1.codigo_curso = "1";
            o1.nombre_curso = "matematica";
            listCursos.Add(o1);

            Cursos o2 = new Cursos();
            o2.codigo_curso = "2";
            o2.nombre_curso = "ingles";
            listCursos.Add(o2);

            Cursos o3 = new Cursos();
            o3.codigo_curso = "3";
            o3.nombre_curso = "Fisica";
            listCursos.Add(o3);

        }

        private static void cargarDocentes()
        {
            Docente o1 = new Docente();
            o1.codigo_docente = "111";
            o1.nombre = "pepe";
            o1.apellido = "pepe";
            o1.clave_docente = "111";
            o1.fecha_creacion = DateTime.Now;

            listDocentes.Add(o1);

            Docente o2 = new Docente();
            o2.codigo_docente = "222";
            o2.nombre = "juan";
            o2.apellido = "juan";
            o2.clave_docente = "222";
            o2.fecha_creacion = DateTime.Now;

            listDocentes.Add(o2);
            Docente o3 = new Docente();
            o3.codigo_docente = "333";
            o3.nombre = "lucho";
            o3.apellido = "lucho";
            o3.clave_docente = "333";
            o3.fecha_creacion = DateTime.Now;
            listDocentes.Add(o3);
        }


        private static void cargarEStudiantes()
        {
            Estudiante o1 = new Estudiante();
            o1.codigo_estudiante = "123";
            o1.nombre = "katy";
            o1.apellido = "loca";        
            listEstudiantes.Add(o1);

            Estudiante o2 = new Estudiante();
            o2.codigo_estudiante = "1234";
            o2.nombre = "edsn";
            o2.apellido = "foca";
            listEstudiantes.Add(o2);

            Estudiante o3 = new Estudiante();
            o3.codigo_estudiante = "12345";
            o3.nombre = "andrea";
            o3.apellido = "montenegro";
            listEstudiantes.Add(o3);


        }
        private static void verAsistenca(string codigo)
        {
            ///  Asistencia 
            ///  
            Console.WriteLine("Asisentew  we");
            foreach (Asistencia item in listAsistencia)
            {

                Console.WriteLine(item.estudiante.nombre + "," + item.asiste);

            }
            Console.ReadKey();
        }

        private static void EntrarClasase(string codigo)
        {
            Console.Clear();
            Docente o = new Docente();
            Console.WriteLine("        id curso   | nomnre cutso  \n ");
            foreach (CursoDocente item in o.Miscrusos(codigo))
            {
                Console.WriteLine("     "+item.cursos.nombre_curso + "  ,  " + item.cursos.codigo_curso);
            }
            Console.WriteLine("\n");

            Console.WriteLine(" -------------Elija el codigo del  curso a entrar \n ");
         

            bool e = true;
            string opcion="";
            while (e)
            {
                CursoDocente ob = new CursoDocente();
                 opcion = Console.ReadLine();
                if (ob.existe2(codigo,opcion))
                {
                 //   var listaestudiantes=
                   
                    e = false;
                }
                else
                {
                    Console.WriteLine(" -------------ese curso no existe we :V \n ");
                    e = true;
                }

            }
            Matriculados m1 = new Matriculados();

            int cont = m1.alumnincurso(opcion).Count;
            string[] array1 = new string[cont];
            int contador = 0;
            Console.WriteLine("--------------------Estudiants \n");

            Console.WriteLine("----nombre  | apellid    | Codigo estdiante \n");
            foreach (Matriculados item in m1.alumnincurso(opcion))
            {
                Console.WriteLine(item.estudiantes.nombre + " , " + item.estudiantes.apellido + "  ,  " + item.estudiantes.codigo_estudiante);
                array1[contador] = item.estudiantes.nombre;
                contador++;
            }
            Console.WriteLine("    enter para timar asistencia   \n");
            Console.ReadLine();

            for (int i = 0; i < array1.Length; i++)
            {
                string pre = "";

                Asistencia asi = new Asistencia();
                Estudiante es = new Estudiante();
                Console.WriteLine(" -----    vino esl estudiante    " + array1[i]+"  ?");
                Console.WriteLine("  ----  s => si  /  n => No");
                pre = Console.ReadLine();
                if (pre.Equals("s") || pre.Equals("S"))
                {
                    es.nombre = array1[i].ToString();
                    asi.dia = "MArtes";
                    asi.estudiante = es;
                    asi.asiste = true;
                    asi.Registrar(asi);

                }
                else
                {
                    es.nombre = array1[i].ToString();
                    asi.dia = "MArtes";
                    asi.estudiante = es;
                    asi.asiste =false;
                    asi.Registrar(asi);
                }

            }

            Console.Clear();
            menuDocente2(codigo);


        }

        private static void vermiscursos(string codigo)
        {
            Console.Clear();
            Docente o = new Docente();
            Console.WriteLine("id curso   | nomnre cutso");
            foreach (CursoDocente item in o.Miscrusos(codigo))
            {
                Console.WriteLine(item.cursos.nombre_curso + "," + item.cursos.codigo_curso);
            }
            
            menuDocente2(codigo);
        }

        private static void menuDocente(string codigo)
        {
            // estemuno ya no
            Docente o = new Docente();
            string nombre;
            nombre = o.datos(codigo).nombre;
            bool dentro = true;
            while (dentro)
            {
                Console.WriteLine("Bienvenido  docente   --------> " + nombre);
                Console.WriteLine("1  Ver mis  Cursos");
                Console.WriteLine("2  Entrar a clase de curso");
                Console.WriteLine("3  ingresar Notas");
                Console.WriteLine("4  tomar Asistencia");
                Console.WriteLine("5  Salir \n ");
                string op = Console.ReadLine();
                if (op.Equals("1"))
                {
                    foreach (CursoDocente item in o.Miscrusos(codigo))
                    {
                        Console.WriteLine(item.cursos.nombre_curso + "," + item.cursos.codigo_curso);
                    }
                    dentro = true;
                }

                if (op.Equals("2"))
                {
                    foreach (CursoDocente item in o.Miscrusos(codigo))
                    {
                        Console.WriteLine(item.cursos.nombre_curso + "," + item.cursos.codigo_curso);
                    }

                    Console.WriteLine(" -------------Elija el codigo del  curso a entrar \n ");
                    string opcion = Console.ReadLine();
                    Matriculados m1 = new Matriculados();
                    Console.WriteLine(" -------------Alumno del curso-----------------");
                    Console.WriteLine(" Alumno nombre estudiante |  apellido  |  codio estudiante \n ");
                    foreach (Matriculados item in m1.alumnincurso(opcion))
                    {
                        Console.WriteLine(item.estudiantes.nombre+" , " +item.estudiantes.apellido+"  ,  " +item.estudiantes.codigo_estudiante);
                    }
                    Console.WriteLine("------- 1 Tomar Asistencia------");

                    foreach (Matriculados item in m1.alumnincurso(opcion))
                    {
                        Asistencia asi = new Asistencia();
                        Cursos cur = new Cursos();
                        cur.codigo_curso = opcion;
                        Console.WriteLine( "vino :"+ item.estudiantes.nombre );
                        Console.WriteLine("--(s /n)    si  /  no");
                        string presente = Console.ReadLine();
                        if (presente.Equals("s"))
                        {
                            asi.curso = cur;
                            asi.asiste = true;
                        }
                        if (presente.Equals("n"))
                        {
                            asi.curso = cur;
                            asi.asiste = false;
                        }
                        asi.Registrar(asi);
                        Console.WriteLine("Registro Aistencia");
                        
                    }
                    Console.ReadLine();

                    dentro = true;
                }
                if (op.Equals("5"))
                {                   
                    dentro = false;
                }
            }
            Console.Clear();
            menu();
        }

        private static void vercursodocete()
        {
            CursoDocente o = new CursoDocente();
            Console.WriteLine("codigo curso, |nombre cruso | codigo docente | nombre docente");

            foreach (CursoDocente item in o.Listar())
            {
                Console.WriteLine(item.cursos.codigo_curso + "," + item.cursos.nombre_curso+ " , "  +item.docente.codigo_docente + " , " +item.docente.nombre);

            }
            menu();
        }

        private static void asigcarCursoDocnete()
        {
            Docente o = new Docente();
           
            Console.WriteLine("Codigo docnete ,  Nombre docnte");
            foreach (Docente item in o.Listar())
            {
                Console.WriteLine(item.codigo_docente + " ," + item.nombre+"," +item.apellido);
            }

            string nombre="";
            string apellido="";
            string code="";
            bool regis = true;
            while (regis)
            {
                 Console.WriteLine("Elija con el codigo de docente");
                 code = Console.ReadLine();
                if (o.existe(code))
                {   
                    regis = false;
                  //  o.datos(code);
                    nombre = o.datos(code).nombre;
                    apellido = o.datos(code).apellido;
                }
                else
                {   Console.WriteLine("No exite ese codigo de docnete");
                    regis = true;

                }

            }
            Console.WriteLine("Docnte" + nombre + ", " + apellido);

            bool e1 = true;

            while (e1)
            {
                Cursos cu = new Cursos();
                Console.WriteLine("No Elija los cursos para el docente");
                Console.WriteLine("codigo curso   | nombre curso");
                foreach (Cursos item in cu.Listar())
                {
                    Console.WriteLine(item.codigo_curso + " ," + item.nombre_curso);
                }                             
               
                bool e2 = true;
                while (e2)
                {
                    string cocurso = "";
                    Console.WriteLine("Elija el codigo del curso");
                    cocurso = Console.ReadLine();
                    if (cu.existe(cocurso))
                    {
                        string nombrecurso = "";
                        string codde_curso = "";
                        nombrecurso = cu.datos(cocurso).nombre_curso;
                        codde_curso = cu.datos(cocurso).codigo_curso;

                        Console.WriteLine(" curso  " + nombrecurso +"\n");
                        o.codigo_docente = code;
                        cu.codigo_curso = codde_curso;
                        cu.nombre_curso = nombrecurso;
                        CursoDocente cudo = new CursoDocente();
                        cudo.docente = o;
                        cudo.cursos = cu;
                        cudo.Registrar(cudo);  

                        e2 = false;
                    }
                    else
                    {
                        Console.WriteLine("codigo de curso no existe");
                        e2 = true;
                    }
                }
                Console.WriteLine("Registrado curso a Docente");
                Console.WriteLine("Desea agregarle otro cursi mas ?");
                Console.WriteLine("-----(s/n) ----");
                string respo = Console.ReadLine();
                if (respo.Equals("s") || respo.Equals("S"))
                {
                    e1 = true;
                }
                else
                {
                    e1 = false;
                }

            }
            Console.WriteLine("Salio del Bucle");
            menu();
        }

        private static void agregarDocente()
        {
            Docente o = new Docente();
            Console.WriteLine("Codigo Docente");
            o.codigo_docente = Console.ReadLine();
            Console.WriteLine("Nombre Docente");
            o.nombre = Console.ReadLine();
            Console.WriteLine("Apellido Docente");
            o.apellido = Console.ReadLine();
            Console.WriteLine("Clave Docente");
            o.clave_docente = Console.ReadLine();
            o.fecha_creacion = DateTime.Now;
            o.Registrar(o);
            //Console.WriteLine("que cursos va a enseña ?");

            //Cursos c = new Cursos();

            //foreach (Cursos item in c.Listar())
            //{
            //    Console.WriteLine(item.codigo_curso + "." + item.nombre_curso);
            //}
          

            //bool regis = true;
            //while (regis)
            //{
            //    Console.WriteLine("escriba el codigo del curso  para agregar al docente");
            //    string codicurso = Console.ReadLine();
            //    if (c.exite(codicurso))
            //    {
            //        c.codigo_curso = codicurso;
            //        o.cursos = c;
            //        Console.WriteLine("Registrado Docente");
            //        regis = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine("No exite ese codigo de curso");
            //        regis = true;

            //    }

            //}
           
            Console.WriteLine("Registrado");
            Console.Clear();
            menu();
        }

        private static void listarcursos()
        {
            Cursos o = new Cursos();

            Console.WriteLine("  ----   Codigo curso ,  Nombre curso");
            foreach (Cursos item in o.Listar())
            {
                Console.WriteLine( " " + item.codigo_curso + "  ,    "    + item.nombre_curso);

            }
            Console.WriteLine("\n");

            menu();
        }

        private static void listarEStudiantes()
        {
            Console.Clear();
            Estudiante o = new Estudiante();

            Console.WriteLine("  ----   Codigo EStudiante ,  Nombre EStudiante");
            foreach (Estudiante item in o.Listar())
            {
                Console.WriteLine(" " + item.codigo_estudiante + "  ,    " + item.nombre);

            }
            Console.WriteLine("\n");

            menu();
        }
        private static void agregarcursos()
        {
            Cursos o = new Cursos();
            Console.WriteLine("================================");
            Console.WriteLine("  ingrese codigo de curso");
            o.codigo_curso = Console.ReadLine();
            Console.WriteLine("  ingrese nombre de curso ");
            o.nombre_curso = Console.ReadLine();
            
            o.Registrar(o);
            Console.WriteLine("Curso Registrado");
            Console.Clear();
            menu(); 

        }
    }
}
