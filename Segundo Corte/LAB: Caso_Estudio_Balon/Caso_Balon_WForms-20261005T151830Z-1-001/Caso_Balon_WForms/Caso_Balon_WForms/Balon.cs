using System;

namespace Caso_Balon
{
    public class Balon
    {
        // Atributos privados (encapsulamiento)
        private string _material;
        private int _capacidad;
        private string _color;
        private int _capActual;
        private string _forma;

        // Constructor por defecto
        public Balon()
        {
            _material = "Cuero";
            _capacidad = 5;
            _forma = "Esférica";
            _color = "Sin definir";
            _capActual = 0;
        }

        // Constructor con parámetros
        public Balon(string material, int capacidad, string forma)
        {
            _material = material;
            _capacidad = capacidad > 0 ? capacidad : 1;
            _forma = forma;
            _color = "Sin definir";
            _capActual = 0;
        }

        // Métodos de comportamiento
        public void Inflar()
        {
            if (_capActual + 1 <= _capacidad)
            {
                _capActual++;
            }
        }

        public void Capacidad()
        {
            Console.WriteLine($"Capacidad actual: {_capActual}/{_capacidad}");
        }

        public void CambiarColor(string nuevoColor)
        {
            if (!string.IsNullOrWhiteSpace(nuevoColor))
            {
                _color = nuevoColor;
            }
        }

        // Métodos Getters
        public string GetMaterial() => _material;
        public int GetCapacidad() => _capacidad;
        public string GetColor() => _color;
        public string GetForma() => _forma;
        public int GetCapActual() => _capActual;
    }
}