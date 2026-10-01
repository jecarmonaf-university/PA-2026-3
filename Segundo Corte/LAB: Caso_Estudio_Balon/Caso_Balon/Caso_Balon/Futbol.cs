using System;
using System.Collections.Generic;
using System.Text;

namespace Caso_Balon
{
    public class Futbol : Balon
    {
        public Futbol() : base("default material", 0, "default forma")
        {
        }

        public Futbol(string material, int capacidad, string forma)
            : base(material, capacidad, forma)
        {
        }

        public override string ToString()
        {
            return "Balón de fútbol\n" +
                   "Material: " + GetMaterial() + "\n" +
                   "Capacidad: " + GetCapacidad() + "\n" +
                   "Forma: " + GetForma() + "\n" +
                   "Color: " + GetColor() + "\n" +
                   "Capacidad actual: " + GetCapActual();
        }
    }
}
