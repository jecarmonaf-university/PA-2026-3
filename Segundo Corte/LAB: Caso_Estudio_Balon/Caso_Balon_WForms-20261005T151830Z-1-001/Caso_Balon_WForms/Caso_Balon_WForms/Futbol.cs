namespace Caso_Balon
{
    public class Futbol : Balon
    {
        public Futbol() : base("Sintético", 5, "Esférica") { }

        public Futbol(string material, int capacidad, string forma)
            : base(material, capacidad, forma) { }

        public override string ToString()
        {
            return "--- Balón de Fútbol ---\n" +
                   $"Material: {GetMaterial()}\n" +
                   $"Capacidad máxima: {GetCapacidad()}\n" +
                   $"Forma: {GetForma()}\n" +
                   $"Color: {GetColor()}\n" +
                   $"Capacidad actual: {GetCapActual()}";
        }
    }
}