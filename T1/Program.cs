using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazadaS listaCar = new ListaEnlazadaS();

            listaCar.AgregaDosCarros("Honda", 2, 100, "BYD", 4, 10);
            listaCar.AgregaDosCarros("Honda", 2, 10, "BYD", 4, 100);
            listaCar.AgregaDosCarros("Honda", 2, 100, "BYD", 4, 10);
            listaCar.AgregaDosCarros("Honda", 2, 10, "BYD", 4, 100);
            listaCar.AgregaDosCarros("Honda", 2, 100, "BYD", 4, 10);

            Console.WriteLine(listaCar.ToString());

            ListaEnlazadaS newLista = new ListaEnlazadaS();
            newLista.AgregaFin(new Carro("text", 5, 100));
            newLista.AgregaFin(new Carro("text", 5, 2000));
            newLista.AgregaFin(new Carro("text", 5, 100));
            newLista.AgregaFin(new Carro("text", 5, 2000));
            newLista.AgregaFin(new Carro("text", 5, 100));
            newLista.AgregaFin(new Carro("text", 5, 2000));
            newLista.AgregaFin(new Carro("text", 5, 100));
            newLista.AgregaFin(new Carro("text", 5, 2000));
            newLista.AgregaFin(new Carro("text", 5, 100));
            newLista.AgregaFin(new Carro("text", 5, 2000));
            newLista.AgregaFin(new Carro("text", 5, 100));
            newLista.AgregaFin(new Carro("text", 5, 2000));


            Console.WriteLine(newLista.ToString());

            ListaEnlazadaS mezcla = listaCar.MezclaParImparA(newLista);
            Console.WriteLine(mezcla.ToString());
            Console.WriteLine(mezcla.cantidad);
            Console.WriteLine(newLista.cantidad);

        }
    }
}
