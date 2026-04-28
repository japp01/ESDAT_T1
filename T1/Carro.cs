using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class Carro
    {
        public string Marca {  get; set; }
        public int Puertas { get; set; }
        public double CcMotor { get; set; }

        public Carro(string marca, int puertas, double ccMotor)
        {
            Marca = marca;
            Puertas = puertas;
            CcMotor = ccMotor;
        }
        public override string ToString()
        {
            return $"marca: {Marca}, motor: {CcMotor}.";
        }
    }
}
