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
            Console.WriteLine();

            ListaEnlazadaS newLista = listaCar.ListaSegunPuerta(1, 2);
            Console.WriteLine(newLista.ToString());

            listaCar.QuitaPenultimoCarro();
            Console.WriteLine(listaCar.ToString());
        }
    }
}
