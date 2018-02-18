using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01_1104017_1169317.Classes
{
    public class NodoDoble<T>
    {
        public NodoDoble<T> anterior;
        public T Valor;
        public NodoDoble<T> siguiente;

        public NodoDoble(NodoDoble<T> siguiente, T valores, NodoDoble<T> NodoDoble)
        {
            Valor = valores;
            this.siguiente = siguiente;
        }

        public NodoDoble(T valores) : this(null, valores, null) { }
        
    }


    /// <summary>
    /// Método que recibe un Listbox, lo limpia y le ingresa todos los elementos del ListBox
    /// </summary>
    /// <param name="elementos">LitBox de elementos</param>

    public class ListaDoble<T> : IEnumerable<T> where T : IComparable
    {
        NodoDoble<T> inicio;
        NodoDoble<T> final;
        int tamaño;


        public int Tamaño()
        {
            return tamaño;
        }

        /// Constructor de la clase ListaSimple
        /// </summary>
        public ListaDoble()
        {
            this.inicio = null;
            this.final = null;
            tamaño = 0;
        }

        /// <summary>
        /// Método que inserta todos los nodos al inicio de la lista
        /// </summary>
        /// <param name="nNuevo">Nodo a insertar</param>
        public void InsertarInicio(NodoDoble<T> nNuevo)
        {
            NodoDoble<T> nodoAuxiliar;

            if (ListaVacia())
            {
                inicio = nNuevo;
                final = nNuevo;
                tamaño++;
            }
            else
            {
                nodoAuxiliar = inicio;
                inicio = nNuevo;
                inicio.siguiente = nodoAuxiliar;
                nodoAuxiliar.anterior = inicio;
                tamaño++;
            }
        }

        /// <summary>
        /// Método que inserta cada nodo en el espacio que le corresponde dependiendo del valor "Numero" perteneciente a la Data
        /// </summary>
        /// <param name="nNuevo">Nodo a insertar</param>
        public void InsertarEnOrden(NodoDoble<T> nNuevo)
        {
            NodoDoble<T> nodoAuxiliar;

            if (ListaVacia() || nNuevo.Valor.CompareTo(inicio.Valor) < 0)
            {
                InsertarInicio(nNuevo);
            }
            else if (final.Valor.CompareTo(nNuevo.Valor) < 0)
            {
                InsertarUltimo(nNuevo);
            }
            else
            {
                nodoAuxiliar = inicio;

                while (nodoAuxiliar.Valor.CompareTo(nNuevo.Valor) < 0 && nodoAuxiliar.siguiente.Valor.CompareTo(nNuevo.Valor) < 0)
                {
                    nodoAuxiliar = nodoAuxiliar.siguiente;
                }

                nNuevo.siguiente = nodoAuxiliar.siguiente;
                nNuevo.anterior = nodoAuxiliar;
                nodoAuxiliar.siguiente = nNuevo;
                nodoAuxiliar = nodoAuxiliar.siguiente.siguiente;
                nodoAuxiliar.anterior = nNuevo;
                tamaño++;
            }
        }

        /// <summary>
        /// Método que inserta todos los nodos al final de la lista
        /// </summary>
        /// <param name="nNuevo">Nodo a insertar</param>
        public void InsertarUltimo(NodoDoble<T> nNuevo)
        {
            NodoDoble<T> nodoAuxiliar;
            if (ListaVacia())
            {
                inicio = nNuevo;
                final = nNuevo;
                tamaño++;
            }
            else
            {
                nodoAuxiliar = final;
                final = nNuevo;
                nodoAuxiliar.siguiente = nNuevo;
                final.anterior = nodoAuxiliar;
                tamaño++;
            }
        }

        /// <summary>
        /// Método que inserta un nodo a la lista por medio de un valor que representa una posicion en la lista
        /// </summary>
        /// <param name="posicion">Posicion donde debe de ir el nodo</param>
        /// <param name="nNuevo">Nodo a insertar</param>
        public void InsertarPorPosicion(int posicion, NodoDoble<T> nNuevo)
        {
            NodoDoble<T> nodoAuxiliar;
            nodoAuxiliar = inicio;

            if (posicion > 0)
            {
                posicion -= 1;

                while (posicion != 0 && nodoAuxiliar.siguiente != null)
                {
                    nodoAuxiliar = nodoAuxiliar.siguiente;
                    posicion--;
                }

                nNuevo.siguiente = nodoAuxiliar.siguiente;
                nodoAuxiliar.siguiente = nNuevo;
                nNuevo.anterior = nodoAuxiliar;

                if (nNuevo.siguiente != null)
                {
                    nodoAuxiliar = nNuevo.siguiente;
                    nodoAuxiliar.anterior = nNuevo;
                }
                
                tamaño++;
            }
            else
            {
                posicion += 1;

                if (posicion == 0)
                {
                    InsertarInicio(nNuevo);
                }
                else
                {
                    while (posicion != 0 && nodoAuxiliar.siguiente != null)
                    {
                        nodoAuxiliar = nodoAuxiliar.siguiente;
                        posicion--;
                    }

                    if (nodoAuxiliar.siguiente == null)
                    {
                        InsertarInicio(nNuevo);
                    }
                    else
                    {
                        nNuevo.siguiente = nodoAuxiliar;
                        nodoAuxiliar = nodoAuxiliar.anterior;
                        nodoAuxiliar.siguiente = nNuevo;
                        nodoAuxiliar = nNuevo.siguiente;
                        nNuevo.anterior = nodoAuxiliar;
                        nodoAuxiliar.anterior = nNuevo;
                        tamaño++;
                    }
                }
            }
        }

        /// <summary>
        /// Eliminar el primer elemento de la lista
        /// </summary>
        public NodoDoble<T> EliminarPrimero()
        {
            if (ListaVacia() != true)
            {
                T infoEli = inicio.Valor;
                NodoDoble<T> nodoTemporal = new NodoDoble<T>(infoEli);


                try
                {
                    inicio = inicio.siguiente;
                    inicio.anterior = null;
                    tamaño--;
                }
                catch
                {
                    inicio = null;
                }


                return nodoTemporal;
            }

            else
                throw new Exception("La lista de nodos está vacía, no se puede eliminar");
        }

        /// <summary>
        /// Método que elimina el nodo que concida con un dato enviado por el usuario.
        /// </summary>
        /// <param name="dato">Numero que envia el usuario</param>
        public NodoDoble<T> EliminarOrden(NodoDoble<T> dato)
        {
            NodoDoble<T> nodoAuxiliar;
            nodoAuxiliar = inicio;

            if (inicio.Valor.CompareTo(dato.Valor) == 0)
            {
                return EliminarPrimero();
            }
            else if (final.Valor.CompareTo(dato.Valor) == 0)
            {
                return EliminarUltimo();
            }
            else
            {
                while (nodoAuxiliar.siguiente.Valor.CompareTo(dato.Valor) != 0)
                {
                    nodoAuxiliar = nodoAuxiliar.siguiente;
                }

                T infoEli;
                infoEli = nodoAuxiliar.siguiente.Valor;
                NodoDoble<T> nodoTemporal = new NodoDoble<T>(infoEli);

                nodoAuxiliar.siguiente = nodoAuxiliar.siguiente.siguiente;
                nodoAuxiliar = nodoAuxiliar.siguiente;
                nodoAuxiliar.anterior = nodoAuxiliar.anterior.anterior;
                tamaño--;

                return nodoTemporal;
            }
        }

        /// <summary>
        /// Método que elimina el ultimo nodo de la lista.
        /// </summary>
        public NodoDoble<T> EliminarUltimo()
        {
            if (ListaVacia() != true)
            {
                NodoDoble<T> nodoAuxiliar;
                nodoAuxiliar = final.anterior;

                T infoEli = final.Valor;
                NodoDoble<T> nodoTemporal = new NodoDoble<T>(infoEli);

                try
                {
                    nodoAuxiliar.siguiente = null;
                    final = nodoAuxiliar;
                    tamaño--;
                }
                catch
                {
                    inicio = null;
                }

                return nodoTemporal;
            }
            else
                throw new Exception("La lista de nodos está vacía, no se puede eliminar");
        }

        /// <summary>
        /// Método que recibe un identificador de un nodo y lo corre x posiciones que dicta el usuario
        /// </summary>
        /// <param name="identificador">Numero que identifica al nodo a trasladar</param>
        /// <param name="posiciones">Numero que describe cuantas posiciones se correrá el nodo</param>
        public void CorrerNodo(NodoDoble<T> identificador, int posiciones)
        {
            NodoDoble<T> nodoAuxiliar;
            nodoAuxiliar = inicio;
            int contadorPosicion = 0;

            if (posiciones != 0)
            {
                if (nodoAuxiliar.Valor.CompareTo(identificador) == 0)
                {
                    if (posiciones > 0)
                    {
                        NodoDoble<T> nodoTemporal = EliminarOrden(identificador);
                        InsertarPorPosicion(posiciones, nodoTemporal);
                    }
                }
                else
                {
                    while (nodoAuxiliar.siguiente.Valor.CompareTo(identificador) != 0)
                    {
                        nodoAuxiliar = nodoAuxiliar.siguiente;
                        contadorPosicion++;
                    }

                    NodoDoble<T> nodoTemporal = EliminarOrden(identificador);
                    InsertarPorPosicion((contadorPosicion + posiciones), nodoTemporal);
                }
            }
        }

        /// <summary>
        /// Función que devuelve un valor booleano de si la lista está vaía o no.
        /// </summary>
        /// <returns>Si la lista está vacía</returns>
        public bool ListaVacia()
        {
            if (inicio == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Método que recibe un Listbox, lo limpia y le ingresa todos los elementos del ListBox
        /// </summary>
        /// <param name="elementos">LitBox de elementos</param>
        public List<T> ImprimirLista()
        {
            NodoDoble<T> nodoAuxiliar;
            nodoAuxiliar = inicio;

            List<T> ListadoJugadores = new List<T>();
            ListadoJugadores.Clear();

            while (nodoAuxiliar != null)
            {
                ListadoJugadores.Add(nodoAuxiliar.Valor);
                nodoAuxiliar = nodoAuxiliar.siguiente;
            }

            return ListadoJugadores;
        }


        public IEnumerator<T> GetEnumerator()
        {
            NodoDoble<T> current = inicio;
            int i = 0;
            while (current != null && i < tamaño)
            {
                yield return current.Valor;
                current = current.siguiente;
                i++;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}