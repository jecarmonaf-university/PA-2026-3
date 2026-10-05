namespace Caso_Balon
{
    public class Volley : Balon
    {
        public Volley() : base("Cuero Sintético", 6, "Esférica") { }

        public Volley(string material, int capacidad, string forma)
            : base(material, capacidad, forma) { }

        public override string ToString()
        {
            return "--- Balón de Voleibol ---\n" +
                   $"Material: {GetMaterial()}\n" +
                   $"Capacidad máxima: {GetCapacidad()}\n" +
                   $"Forma: {GetForma()}\n" +
                   $"Color: {GetColor()}\n" +
                   $"Capacidad actual: {GetCapActual()}";
        }
    }
}