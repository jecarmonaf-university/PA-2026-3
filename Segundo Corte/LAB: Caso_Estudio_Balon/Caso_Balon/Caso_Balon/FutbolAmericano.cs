namespace Caso_Balon
{
    public class FutbolAmericano : Balon
    {
        public FutbolAmericano() : base("Cuero", 10, "Esferoide Prolado") { }

        public FutbolAmericano(string material, int capacidad, string forma)
            : base(material, capacidad, forma) { }

        public override string ToString()
        {
            return "--- Balón de Fútbol Americano ---\n" +
                   $"Material: {GetMaterial()}\n" +
                   $"Capacidad máxima: {GetCapacidad()}\n" +
                   $"Forma: {GetForma()}\n" +
                   $"Color: {GetColor()}\n" +
                   $"Capacidad actual: {GetCapActual()}";
        }
    }
}