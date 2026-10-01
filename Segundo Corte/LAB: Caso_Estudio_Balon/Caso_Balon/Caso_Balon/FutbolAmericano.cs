using System;
using System.Collections.Generic;
using System.Text;

namespace Caso_Balon
{
    public class FutbolAmericano : Balon
    {
        public FutbolAmericano() : base("default material", 0, "default forma")
        {
        }

        public FutbolAmericano(string material, int capacidad, string forma)
            : base(material, capacidad, forma)
        {
        }

        public override string ToString()
        {
            return "Balón de fútbol americano\n" +
                   "Material: " + GetMaterial() + "\n" +
                   "Capacidad: " + GetCapacidad() + "\n" +
                   "Forma: " + GetForma() + "\n" +
                   "Color: " + GetColor() + "\n" +
                   "Capacidad actual: " + GetCapActual();
        }
    }
}
