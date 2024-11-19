using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEFI_ED
{
    internal class Arbol
    {
        public Nodo Raiz { get; set; }

        public Arbol()
        {
            Raiz = null;
        }

        public void Insertar(int codigo, string nombre, string tipo, string rango)
        {
            var nuevoNodo = new Nodo(codigo, nombre, tipo, rango);

            if (Raiz == null)
            {
                Raiz = nuevoNodo;
            }
            else
            {
                InsertarRecursivo(Raiz, nuevoNodo);
            }
        }

        private void InsertarRecursivo(Nodo actual, Nodo nuevoNodo)
        {
            if (nuevoNodo.Codigo >= actual.Codigo)
            {
                if (actual.Derecha == null)
                {
                    actual.Derecha = nuevoNodo;
                }
                else
                {
                    InsertarRecursivo(actual.Derecha, nuevoNodo);
                }
            }
            else
            {
                if (actual.Izquierda == null)
                {
                    actual.Izquierda = nuevoNodo;
                }
                else
                {
                    InsertarRecursivo(actual.Izquierda, nuevoNodo);
                }
            }
        }

        public List<Nodo> Listar(Nodo raiz)
        {
            List<Nodo> nodos = new List<Nodo>();
            ListarRecursivo(raiz, nodos);
            return nodos;
        }

        private void ListarRecursivo(Nodo actual, List<Nodo> nodos)
        {
            if (actual == null) return;

            if (actual.Izquierda != null)
            {
                ListarRecursivo(actual.Izquierda, nodos);
            }

            nodos.Add(actual);

            if (actual.Derecha != null)
            {
                ListarRecursivo(actual.Derecha, nodos);
            }
        }

        public Nodo Buscar(Nodo raiz, int codigo)
        {
            if (raiz == null || raiz.Codigo == codigo)
            {
                return raiz;
            }

            if (codigo < raiz.Codigo)
            {
                return Buscar(raiz.Izquierda, codigo);
            }

            return Buscar(raiz.Derecha, codigo);
        }

        public bool ExisteCodigo(Nodo raiz, int codigo)
        {
            if (raiz == null)
            {
                return false;
            }

            if (raiz.Codigo == codigo)
            {
                return true;
            }

            if (codigo < raiz.Codigo)
            {
                return ExisteCodigo(raiz.Izquierda, codigo);
            }
            else
            {
                return ExisteCodigo(raiz.Derecha, codigo);
            }
        }
    }
}
