using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEFI_ED
{
    internal class Nodo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Rango { get; set; }

        public Nodo Izquierda { get; set; }
        public Nodo Derecha { get; set; }

        public Nodo(int codigo, string nombre, string tipo, string rango)
        {
            Codigo = codigo;
            Nombre = nombre;
            Tipo = tipo;
            Rango = rango;
            Izquierda = null;
            Derecha = null;
        }
    }
}
