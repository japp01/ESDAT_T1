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

            listaCar.AgregaDosCarros("Honda", 2, 300, "BYD", 4, 400);
            listaCar.AgregaDosCarros("Honda", 2, 200, "BYD", 4, 500);
            listaCar.AgregaDosCarros("Honda", 2, 100, "BYD", 4, 600);

            Console.WriteLine(listaCar.ToString());

            ListaEnlazadaS newLista = new ListaEnlazadaS();
            newLista.AgregaFin(new Carro("text", 5, 1000));
            newLista.AgregaFin(new Carro("text", 5, 2000));
            newLista.AgregaFin(new Carro("text", 5, 3000));
            newLista.AgregaFin(new Carro("text", 5, 4000));
            newLista.AgregaFin(new Carro("text", 5, 5000));
            newLista.AgregaFin(new Carro("text", 5, 6000));
            newLista.AgregaFin(new Carro("text", 5, 7000));
            newLista.AgregaFin(new Carro("text", 5, 7000));
            newLista.AgregaFin(new Carro("text", 5, 7000));
            newLista.AgregaFin(new Carro("text", 5, 7000));

            Console.WriteLine(newLista.ToString());

            ListaEnlazadaS mezcla = listaCar.MezclaParImpar(newLista);
            Console.WriteLine(mezcla.ToString());
            Console.WriteLine(mezcla.cantidad);
            Console.WriteLine(newLista.cantidad);

        }
    }
}
