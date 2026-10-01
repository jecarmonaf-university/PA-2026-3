using System;
using System.Collections.Generic;
using System.Text;

namespace Caso_Balon
{

    using System;

    public class Menu
    {
        private Futbol ob1;
        private Basket ob2;
        private FutbolAmericano ob3;
        private Volley ob4;

        private bool futbolIngresado = false;
        private bool basketIngresado = false;
        private bool futbolAmericanoIngresado = false;
        private bool volleyIngresado = false;

        public Menu()
        {
        }

        public void IniciarMenu()
        {
            int opcion;

            do
            {
                Console.WriteLine("\n===== MENU BALONES =====");
                Console.WriteLine("1. Ingresar balón de fútbol");
                Console.WriteLine("2. Ingresar balón de baloncesto");
                Console.WriteLine("3. Ingresar balón de fútbol americano");
                Console.WriteLine("4. Ingresar balón de voleibol");
                Console.WriteLine("5. Mostrar balón de fútbol");
                Console.WriteLine("6. Mostrar balón de baloncesto");
                Console.WriteLine("7. Mostrar balón de fútbol americano");
                Console.WriteLine("8. Mostrar balón de voleibol");
                Console.WriteLine("9. Inflar balón de fútbol");
                Console.WriteLine("10. Cambiar color del balón de fútbol");
                Console.WriteLine("0. Salir");

                Console.Write("\nSeleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        IngresarFutbol();
                        break;

                    case 2:
                        IngresarBasket();
                        break;

                    case 3:
                        IngresarFutbolAmericano();
                        break;

                    case 4:
                        IngresarVolley();
                        break;

                    case 5:
                        if (futbolIngresado)
                            Console.WriteLine(ob1);
                        else
                            Console.WriteLine("Primero debe ingresar el balón de fútbol.");
                        break;

                    case 6:
                        if (basketIngresado)
                            Console.WriteLine(ob2);
                        else
                            Console.WriteLine("Primero debe ingresar el balón de baloncesto.");
                        break;

                    case 7:
                        if (futbolAmericanoIngresado)
                            Console.WriteLine(ob3);
                        else
                            Console.WriteLine("Primero debe ingresar el balón de fútbol americano.");
                        break;

                    case 8:
                        if (volleyIngresado)
                            Console.WriteLine(ob4);
                        else
                            Console.WriteLine("Primero debe ingresar el balón de voleibol.");
                        break;

                    case 9:
                        if (futbolIngresado)
                        {
                            ob1.Inflar();
                            Console.WriteLine("El balón de fútbol fue inflado.");
                            ob1.Capacidad();
                        }
                        else
                        {
                            Console.WriteLine("Primero debe ingresar el balón de fútbol.");
                        }
                        break;

                    case 10:
                        if (futbolIngresado)
                        {
                            Console.Write("Ingrese el nuevo color: ");
                            string color = Console.ReadLine();

                            ob1.CambiarColor(color);

                            Console.WriteLine("Color cambiado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Primero debe ingresar el balón de fútbol.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 0);
        }

        private void IngresarFutbol()
        {
            Console.WriteLine("\n--- INGRESAR BALON DE FUTBOL ---");

            Console.Write("Material: ");
            string material = Console.ReadLine();

            Console.Write("Capacidad: ");
            int capacidad = Convert.ToInt32(Console.ReadLine());

            Console.Write("Forma: ");
            string forma = Console.ReadLine();

            Console.Write("Color: ");
            string color = Console.ReadLine();

            ob1 = new Futbol(material, capacidad, forma);
            ob1.CambiarColor(color);

            futbolIngresado = true;

            Console.WriteLine("\nBalón de fútbol ingresado correctamente.");
        }

        private void IngresarBasket()
        {
            Console.WriteLine("\n--- INGRESAR BALON DE BALONCESTO ---");

            Console.Write("Material: ");
            string material = Console.ReadLine();

            Console.Write("Capacidad: ");
            int capacidad = Convert.ToInt32(Console.ReadLine());

            Console.Write("Forma: ");
            string forma = Console.ReadLine();

            Console.Write("Color: ");
            string color = Console.ReadLine();

            ob2 = new Basket(material, capacidad, forma);
            ob2.CambiarColor(color);

            basketIngresado = true;

            Console.WriteLine("\nBalón de baloncesto ingresado correctamente.");
        }

        private void IngresarFutbolAmericano()
        {
            Console.WriteLine("\n--- INGRESAR BALON DE FUTBOL AMERICANO ---");

            Console.Write("Material: ");
            string material = Console.ReadLine();

            Console.Write("Capacidad: ");
            int capacidad = Convert.ToInt32(Console.ReadLine());

            Console.Write("Forma: ");
            string forma = Console.ReadLine();

            Console.Write("Color: ");
            string color = Console.ReadLine();

            ob3 = new FutbolAmericano(material, capacidad, forma);
            ob3.CambiarColor(color);

            futbolAmericanoIngresado = true;

            Console.WriteLine("\nBalón de fútbol americano ingresado correctamente.");
        }

        private void IngresarVolley()
        {
            Console.WriteLine("\n--- INGRESAR BALON DE VOLEIBOL ---");

            Console.Write("Material: ");
            string material = Console.ReadLine();

            Console.Write("Capacidad: ");
            int capacidad = Convert.ToInt32(Console.ReadLine());

            Console.Write("Forma: ");
            string forma = Console.ReadLine();

            Console.Write("Color: ");
            string color = Console.ReadLine();

            ob4 = new Volley(material, capacidad, forma);
            ob4.CambiarColor(color);

            volleyIngresado = true;

            Console.WriteLine("\nBalón de voleibol ingresado correctamente.");
        }
    }
}
