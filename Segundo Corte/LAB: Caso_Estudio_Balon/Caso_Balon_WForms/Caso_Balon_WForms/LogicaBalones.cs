using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso_Balon_WForms
{
    public class Balon
    {
        private string _material;
        private int _capacidad;
        private string _color;
        private int _capActual;
        private string _forma;

        public Balon(string material, int capacidad, string forma)
        {
            _material = material;
            _capacidad = capacidad > 0 ? capacidad : 1;
            _forma = forma;
            _color = "Sin definir";
            _capActual = 0;
        }

        public void Inflar()
        {
            if (_capActual + 1 <= _capacidad) _capActual++;
        }

        public void CambiarColor(string nuevoColor)
        {
            if (!string.IsNullOrWhiteSpace(nuevoColor)) _color = nuevoColor;
        }

        public string GetMaterial() => _material;
        public int GetCapacidad() => _capacidad;
        public string GetColor() => _color;
        public string GetForma() => _forma;
        public int GetCapActual() => _capActual;

        public virtual string Detalles()
        {
            return $"Material: {_material} \nForma: {_forma} \nColor: {_color} \nInflado: {_capActual}/{_capacidad}";
        }
    }

    public class Futbol : Balon
    {
        public Futbol(string m, int c, string f) : base(m, c, f) { }
        public override string Detalles() => "--- FÚTBOL ---\n" + base.Detalles();
    }

    public class Basket : Balon
    {
        public Basket(string m, int c, string f) : base(m, c, f) { }
        public override string Detalles() => "--- BALONCESTO ---\n" + base.Detalles();
    }

    public class FutbolAmericano : Balon
    {
        public FutbolAmericano(string m, int c, string f) : base(m, c, f) { }
        public override string Detalles() => "--- FÚTBOL AMERICANO ---\n" + base.Detalles();
    }

    public class Volley : Balon
    {
        public Volley(string m, int c, string f) : base(m, c, f) { }
        public override string Detalles() => "--- VOLEIBOL ---\n" + base.Detalles();
    }
}
