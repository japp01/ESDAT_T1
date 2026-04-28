using System;
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
        }

        public ListaEnlazadaS MezclaParImpar(ListaEnlazadaS segunda)
        {
            ListaEnlazadaS l = new ListaEnlazadaS();
            NodoS temp1 = Primero;
            NodoS temp2 = l.Primero;

            while (temp1 != null)
            {

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
