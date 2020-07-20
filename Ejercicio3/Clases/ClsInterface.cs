using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Clases
{
    interface ClsInterface<T> where T:class
    {

        void Registrar(T o);

        List<T> Listar();

        bool existe(string code);    


    }
}
