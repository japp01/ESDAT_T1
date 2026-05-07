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

        //agregar impares de primera y pares de segunda, intercalados
        //me equivoque e hice el mismo metodo pero de otra manera, parece mas limpio.
        public ListaEnlazadaS Mezcla(ListaEnlazadaS segunda) {
            ListaEnlazadaS mezcla = new ListaEnlazadaS();
            NodoS temp1 = this.Primero;
            NodoS temp2 = segunda.Primero;

            //agrega hasta que termine de agregar una lista
            while (temp1 != null && temp2 != null) {
                mezcla.AgregaFin(temp1.Dato);
                temp1 = temp1.Siguiente;
                mezcla.AgregaFin(temp2.Dato);
                temp2 = temp2.Siguiente;
            }

            //Agrega los nodos de la lista faltante
            if (temp1 == null) {
                while (temp2 != null) {
                    mezcla.AgregaFin(temp2.Dato);
                    temp2 = temp2.Siguiente;
                }
            } else if (temp2 == null) {
                while (temp1 != null) {
                    mezcla.AgregaFin(temp1.Dato);
                    temp1 = temp1.Siguiente;
                }
            }

            return mezcla;
        }

        //agregar impares de primera y pares de segunda, intercalados.
        //esta vez de verdad
        public ListaEnlazadaS TrueMezcla(ListaEnlazadaS segunda) {
            ListaEnlazadaS mezcla = new ListaEnlazadaS();
            NodoS temp1 = this.Primero;
            NodoS temp2 = segunda.Primero;
            int pos = 1;

            //agregar hasta terminar una lista
            while(temp1 != null && temp2 != null){
                if(pos % 2 > 0) {
                    mezcla.AgregaFin(temp1.Dato);
                } else {
                    mezcla.AgregaFin(temp2.Dato);
                }
                temp1 = temp1.Siguiente;
                temp2 = temp2.Siguiente;
                pos++;
            }

            //agregar los pares/impares de la lista remanente
            if(temp1 != null) { //primera lista
                while(temp1 != null) {
                    if(pos % 2 > 0) {//agrega impar
                        mezcla.AgregaFin(temp1.Dato);
                    }
                    temp1 = temp1.Siguiente;
                    pos++;
                }
            } else { //segunda lista
                while(temp2 != null) { 
                    if(pos % 2 == 0) { //agrega par
                        mezcla.AgregaFin(temp2.Dato);
                    }
                    temp2 = temp2.Siguiente;
                    pos++;
                }
            }

            return mezcla;
        }

        public ListaEnlazadaS MezclaParImparA(ListaEnlazadaS segunda) {
            ListaEnlazadaS res = new ListaEnlazadaS();
            int pos = 0;
            NodoS pri = this.Primero;
            NodoS seg = segunda.Primero;
            while (pri != null || seg != null) {

                if (pos % 2 > 0 && pri != null) {//impar
                    res.AgregaFin(new Carro(pri.Dato.Marca, pri.Dato.Puertas, pri.Dato.CcMotor));
                    //Console.WriteLine(pos + " " + pri.dato);
                    pri = pri.Siguiente;
                    if (seg != null) {
                        seg = seg.Siguiente;
                    }
                } else if (pos % 2 > 0 && pri == null) {
                    if (seg != null) {
                        seg = seg.Siguiente;
                    }
                }
                if (pos % 2 == 0 && seg != null) {//par
                    res.AgregaFin(new Carro(seg.Dato.Marca, seg.Dato.Puertas, seg.Dato.CcMotor));
                    //Console.WriteLine(pos + " " + seg.dato);
                    seg = seg.Siguiente;
                    if (pri != null) {
                        pri = pri.Siguiente;
                    }
                } else if (pos % 2 > 0 && seg == null) {
                    if (pri != null) {
                        pri = pri.Siguiente;
                    }
                }
                pos++;
            }

            return res;
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
