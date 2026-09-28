using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Caso_Balon
{
    public class Balon
    {
        //Atributos
        private String Material;
        private int capacidad;
        private String Color;
        private int CapActual;
        private String Forma;

        //Constructor sin Parametros
        //public void balon()
        //{
        //    Material = "Cuero";
        //    capacidad = 5;
        //    Forma = "Esferica";
        //    Color = "Blanco";
        //    CapActual = 0;
        //}
        //Constructor con Parametros
        public void balon(string m, int k, string f)
        {
            Material = m;
            capacidad = k;
            Forma = f;
            Color = "Sin definir";
            CapActual = 0;
        }
         //Inflar
        public void Inflar()
        {
            if((CapActual + 1)<= capacidad)
            {
                CapActual++;
            }
        }

        // Mostrar CapActul
        public void Capacidad()
        {
            Console.WriteLine("Capacidad actual: " + CapActual + "/" + capacidad);
        }
        //Cambiar Color 
        public void CambiarColor(string NuevoColor)
        {
            Color = NuevoColor;
        }
        public string GetMaterial()
        {
            return Material;
        }

        public int GetCapacidad()
        {
            return capacidad;
        }

        public String GetColor()
        {
            return Color;
        }

        public string GetForma()
        {
            return Forma;
        }

        public int GetCapActual()
        {
            return CapActual;
        }
    }
}
