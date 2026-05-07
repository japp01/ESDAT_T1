using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1 {
    internal class ListaEnlazadaS {
        public NodoS Primero { get; set; }
        public NodoS Ultimo { get; set; }
        public int cantidad;

        public void AgregaDosCarros(string marca1, int puertas1, double ccmotor1,
                                    string marca2, int puertas2, double ccmotor2) {
            
            AgregaIni(new Carro(marca1, puertas1, ccmotor1));
            AgregaFin(new Carro(marca2, puertas2, ccmotor2));
        }

        public ListaEnlazadaS ListaSegunPuerta(int min, int max) {
            ListaEnlazadaS l = new ListaEnlazadaS();
            NodoS temp = Primero;

            while (temp != null) {
                if (temp.Dato.Puertas >= min && temp.Dato.Puertas <= max) {
                    l.AgregaFin(temp.Dato);
                }
                temp = temp.Siguiente;
            }
            return l;
        }

        public void QuitaPenultimoCarro() {

            if (cantidad == 2) {
                Ultimo.Anterior = null;
                Primero = Ultimo;
                cantidad--;
            } else if (cantidad > 2) {
                Ultimo.Anterior = Ultimo.Anterior.Anterior;
                Ultimo.Anterior.Siguiente = Ultimo;
                cantidad--;
            } else if (cantidad == 1) {
                Ultimo = null;
                Primero = null;
                cantidad--;
            }
        }

        public ListaEnlazadaS MezclaParImpar(ListaEnlazadaS segunda) {
            ListaEnlazadaS mezcla = new ListaEnlazadaS();
            NodoS actual = this.Primero;

            //agrega primera lista
            while (actual != null) {
                mezcla.AgregaFin(actual.Dato);
                actual = actual.Siguiente;
            }
            //agregar la 2da lista a mezcla
            actual = mezcla.Primero;
            NodoS temp = segunda.Primero;

            while (temp != null && actual != null) {
                //agrega nodos cuando this > segunda
                NodoS nuevo = new NodoS(temp.Dato);

                nuevo.Siguiente = actual.Siguiente;
                nuevo.Anterior = actual;
                actual.Siguiente.Anterior = nuevo;
                actual.Siguiente = nuevo;
                mezcla.cantidad++;

                actual = actual.Siguiente.Siguiente;
                temp = temp.Siguiente;

                //cuando this <= segunda, agrega el resto de nodos de segunda a mezcla
                if (actual.Siguiente == null) {
                    while (temp != null) {
                        mezcla.AgregaFin(temp.Dato); //temp.Dato uses the same Carro, so if you change it, itll change in both
                        temp = temp.Siguiente;
                    }
                    break;
                }
            }
            return mezcla;
        }


        private void AgregaIni(Carro carro) {
            NodoS nuevo = new NodoS(carro);
            if (this.Primero == null) {
                this.Primero = nuevo;
                this.Ultimo = nuevo;
            } else {
                nuevo.Siguiente = this.Primero;
                this.Primero.Anterior = nuevo;
                this.Primero = nuevo;
            }
            cantidad++;
        }

        public void AgregaFin(Carro carro) {
            NodoS nuevo = new NodoS(carro);
            if (this.Primero == null) {
                this.Primero = nuevo;
                this.Ultimo = nuevo;
            } else {
                this.Ultimo.Siguiente = nuevo;
                nuevo.Anterior = this.Ultimo;
                this.Ultimo = nuevo;
            }
            cantidad++;
        }

        public override string ToString() {
            string str = "";
            NodoS temp = Primero;

            while (temp != null) {
                str += temp.Dato.ToString() + "\n";
                temp = temp.Siguiente;
            }

            return str;
        }
    }
}
