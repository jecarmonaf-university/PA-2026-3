namespace Caso_Balon
{
    public class Basket : Balon
    {
        public Basket() : base("Caucho", 8, "Esférica") { }

        public Basket(string material, int capacidad, string forma)
            : base(material, capacidad, forma) { }

        public override string ToString()
        {
            return "--- Balón de Baloncesto ---\n" +
                   $"Material: {GetMaterial()}\n" +
                   $"Capacidad máxima: {GetCapacidad()}\n" +
                   $"Forma: {GetForma()}\n" +
                   $"Color: {GetColor()}\n" +
                   $"Capacidad actual: {GetCapActual()}";
        }
    }
}