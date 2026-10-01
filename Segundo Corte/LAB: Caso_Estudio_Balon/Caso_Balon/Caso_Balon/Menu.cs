using System;

namespace Caso_Balon
{
    public class Menu
    {
        private Futbol _balon1;
        private Basket _balon2;
        private FutbolAmericano _balon3;
        private Volley _balon4;

        public void IniciarMenu()
        {
            int opcion;

            do
            {
                Console.WriteLine("\n===== MENÚ BALONES =====");
                Console.WriteLine("1. Ingresar balón de fútbol");
                Console.WriteLine("2. Ingresar balón de baloncesto");
                Console.WriteLine("3. Ingresar balón de fútbol americano");
                Console.WriteLine("4. Ingresar balón de voleibol");
                Console.WriteLine("5. Mostrar balón de fútbol");
                Console.WriteLine("6. Mostrar balón de baloncesto");
                Console.WriteLine("7. Mostrar balón de fútbol americano");
                Console.WriteLine("8. Mostrar balón de voleibol");
                Console.WriteLine("9. Inflar un balón");
                Console.WriteLine("10. Cambiar color de un balón");
                Console.WriteLine("0. Salir");

                opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        IngresarBalon(out _balon1, "Fútbol", (m, c, f) => new Futbol(m, c, f));
                        break;
                    case 2:
                        IngresarBalon(out _balon2, "Baloncesto", (m, c, f) => new Basket(m, c, f));
                        break;
                    case 3:
                        IngresarBalon(out _balon3, "Fútbol Americano", (m, c, f) => new FutbolAmericano(m, c, f));
                        break;
                    case 4:
                        IngresarBalon(out _balon4, "Voleibol", (m, c, f) => new Volley(m, c, f));
                        break;
                    case 5:
                        MostrarBalon(_balon1, "Fútbol");
                        break;
                    case 6:
                        MostrarBalon(_balon2, "Baloncesto");
                        break;
                    case 7:
                        MostrarBalon(_balon3, "Fútbol Americano");
                        break;
                    case 8:
                        MostrarBalon(_balon4, "Voleibol");
                        break;
                    case 9:
                        InflarBalonMenu();
                        break;
                    case 10:
                        CambiarColorMenu();
                        break;
                    case 0:
                        Console.WriteLine("Programa finalizado.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

            } while (opcion != 0);
        }

        // Método genérico para la captura de datos e instanciación
        private void IngresarBalon<T>(out T objetoBalon, string nombreTipo, Func<string, int, string, T> creador) where T : Balon
        {
            Console.WriteLine($"\n--- INGRESAR BALÓN DE {nombreTipo.ToUpper()} ---");

            Console.Write("Material: ");
            string material = Console.ReadLine();

            int capacidad = LeerEntero("Capacidad (número entero positivo): ");

            Console.Write("Forma: ");
            string forma = Console.ReadLine();

            Console.Write("Color: ");
            string color = Console.ReadLine();

            objetoBalon = creador(material, capacidad, forma);
            objetoBalon.CambiarColor(color);

            Console.WriteLine($"\nBalón de {nombreTipo} ingresado correctamente.");
        }

        private void MostrarBalon(Balon balon, string nombreTipo)
        {
            if (balon != null)
                Console.WriteLine($"\n{balon}");
            else
                Console.WriteLine($"\nPrimero debe ingresar el balón de {nombreTipo}.");
        }

        private void InflarBalonMenu()
        {
            Balon balon = SeleccionarBalonExistente("inflar");
            if (balon != null)
            {
                balon.Inflar();
                Console.WriteLine("El balón fue inflado.");
                balon.Capacidad();
            }
        }

        private void CambiarColorMenu()
        {
            Balon balon = SeleccionarBalonExistente("cambiar el color");
            if (balon != null)
            {
                Console.Write("Ingrese el nuevo color: ");
                string nuevoColor = Console.ReadLine();
                balon.CambiarColor(nuevoColor);
                Console.WriteLine("Color cambiado correctamente.");
            }
        }

        private Balon SeleccionarBalonExistente(string accion)
        {
            Console.WriteLine($"\n¿De qué balón desea {accion}?");
            Console.WriteLine("1. Fútbol");
            Console.WriteLine("2. Baloncesto");
            Console.WriteLine("3. Fútbol Americano");
            Console.WriteLine("4. Voleibol");

            int sel = LeerEntero("Selección: ");
            Balon seleccionado = sel switch
            {
                1 => _balon1,
                2 => _balon2,
                3 => _balon3,
                4 => _balon4,
                _ => null
            };

            if (seleccionado == null)
            {
                Console.WriteLine("Balón no disponible o no ha sido ingresado aún.");
            }

            return seleccionado;
        }

        // Método auxiliar para evitar excepciones al leer números
        private int LeerEntero(string mensaje)
        {
            int numero;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out numero) || numero < 0)
            {
                Console.Write("Entrada no válida. Ingrese un entero mayor o igual a 0: ");
            }
            return numero;
        }
    }
}