using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class ListaEnlazadaS
    {
        public NodoS Primero {  get; set; }
        public NodoS Ultimo { get; set; }
        private int cantidad;

        public void AgregaDosCarros(string marca1, int puertas1, double ccmotor1, 
                                    string marca2, int puertas2, double ccmotor2)
        {
            NodoS nodoIni = new NodoS(new Carro(marca1, puertas1, ccmotor1));
            NodoS nodoFin = new NodoS(new Carro(marca2, puertas2, ccmotor2));

            if(Primero == null)
            {
                Primero = nodoIni;
                Ultimo = nodoFin;
                Primero.Siguiente = nodoFin;
                Ultimo.Anterior = nodoIni;

            }
            else 
            {
                nodoIni.Siguiente = Primero;
                Primero.Anterior = nodoIni;
                Primero = nodoIni;

                Ultimo.Siguiente = nodoFin;
                nodoFin.Anterior = Ultimo;
                Ultimo = nodoFin;
            } 
            
            cantidad += 2;
        }

        public ListaEnlazadaS ListaSegunPuerta(int min, int max)
        {
            ListaEnlazadaS l = new ListaEnlazadaS();
            NodoS temp = Primero;

            while (temp != null)
            {
                if(temp.Dato.Puertas >= min && temp.Dato.Puertas <= max)
                {
                    NodoS nuevo = new NodoS(temp.Dato);

                    if (l.Primero == null)
                    {
                        l.Primero = nuevo;
                        l.Ultimo = nuevo;
                    }
                    else
                    {
                        nuevo.Siguiente = l.Primero;
                        l.Primero.Anterior = nuevo;
                        l.Primero = nuevo;
                    }
                }                    

                temp = temp.Siguiente;
            }

            return l;
        }

        public void QuitaPenultimoCarro()
        {
            if (Ultimo.Anterior != null)
            {
                if(Ultimo.Anterior.Anterior == null)
                {
                    Ultimo.Anterior = null;
                    Primero = Ultimo;
                } 
                else
                {
                    Ultimo.Anterior = Ultimo.Anterior.Anterior;
                    Ultimo.Anterior.Siguiente = Ultimo;
                }
            }
            else
            {
                Ultimo = null;
                Primero = null;
            }
            cantidad--;
        }

        public ListaEnlazadaS MezclaParImpar(ListaEnlazadaS segunda)
        {
            ListaEnlazadaS l = new ListaEnlazadaS();
            NodoS temp = Primero;

            //agrega lista inicial
            while (temp != null)
            {
                NodoS nuevo = new NodoS(temp.Dato);                

                if(l.Primero == null)
                {
                    l.Primero = nuevo;
                    l.Ultimo = nuevo;
                }
                else
                {
                    l.Ultimo.Siguiente = nuevo;
                    nuevo.Anterior = Ultimo;

                }
                l.cantidad++;

                temp = temp.Siguiente;
            }

            //agregar dato segunda lista cuando indice es par
            temp = l.Primero;
            NodoS temp2 = segunda.Primero;
            while (temp != null && temp2 != null)
            {
                NodoS nuevo = new NodoS(temp2.Dato);

                temp2.Anterior = temp;
                temp2.Siguiente = temp.Siguiente;
                temp.Siguiente = temp2;
                
                temp = temp.Siguiente;
                if (temp2.Siguiente != null) temp2 = temp2.Siguiente;
            }

            return l;
        }


        public override string ToString()
        {
            string str = "";
            NodoS temp = Primero;

            while (temp != null)
            {
                str += temp.Dato.ToString() + "\n";

                temp = temp.Siguiente;
            }

            return str;
        }
    }
}
