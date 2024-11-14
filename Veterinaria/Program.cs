using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    public class Program
    {
        private static Random rnd = new Random();
        private static Queue<Mascota> cola = new Queue<Mascota>();
        private static ArbolMascotas arbol = new ArbolMascotas();


        static void Main(string[] args)
        {
            CargarDatosIniciales();
            ProcesarCola();
            MostrarMenu();
        }
        private static void CargarDatosIniciales()
        {
            // Simulamos cargar algunos datos de ejemplo
            string[] razas = { "BULDOG", "LABRADOR", "PASTOR", "GOLDEN", "DACHSHUND", "GALGO", "COOKER", "SAN BERNARDO" };
            string[] sexos = { "Macho", "Hembra" };

            // Cargar 20 mascotas de ejemplo
            for (int i = 0; i < 20; i++)
            {
                Mascota mascota = new Mascota
                {
                    CodigoMascota = rnd.Next(121, 901),
                    CodigoCliente = rnd.Next(10, 901),
                    Cliente = $"Cliente {i + 1}",
                    AliasMascota = $"Mascota {i + 1}",
                    Peso = rnd.Next(1, 41),
                    Edad = rnd.Next(1, 16),
                    Raza = razas[rnd.Next(razas.Length)],
                    Sexo = sexos[rnd.Next(sexos.Length)]
                };
                cola.Enqueue(mascota);
            }
        }

        private static void ProcesarCola()
        {
            while (cola.Count > 0)
            {
                arbol.Insertar(cola.Dequeue());
            }
        }

        private static void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== VETERINARIA RAMOS S.A. ===");
                Console.WriteLine("1. Agregar nueva mascota");
                Console.WriteLine("2. Buscar mascota");
                Console.WriteLine("3. Eliminar mascota");
                Console.WriteLine("4. Mostrar reporte ordenado");
                Console.WriteLine("5. Mostrar estadísticas");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        AgregarMascota();
                        break;
                    case "2":
                        BuscarMascota();
                        break;
                    case "3":
                        EliminarMascota();
                        break;
                    case "4":
                        MostrarReporte();
                        break;
                    case "5":
                       // MostrarEstadisticas();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void AgregarMascota()
        {
            Console.WriteLine("=== AGREGAR NUEVA MASCOTA ===");

            Mascota mascota = new Mascota();

            Console.Write("Código de mascota (121-900): ");
            mascota.CodigoMascota = int.Parse(Console.ReadLine());

            Console.Write("Código de cliente (10-900): ");
            mascota.CodigoCliente = int.Parse(Console.ReadLine());

            Console.Write("Nombre del cliente: ");
            mascota.Cliente = Console.ReadLine();

            Console.Write("Alias de la mascota: ");
            mascota.AliasMascota = Console.ReadLine();

            Console.Write("Peso (1-40 kg): ");
            mascota.Peso = double.Parse(Console.ReadLine());

            Console.Write("Edad (1-15 años): ");
            mascota.Edad = int.Parse(Console.ReadLine());

            Console.Write("Raza (BULDOG/LABRADOR/PASTOR/GOLDEN/DACHSHUND/GALGO/COOKER/SAN BERNARDO): ");
            mascota.Raza = Console.ReadLine().ToUpper();

            Console.Write("Sexo (Macho/Hembra): ");
            mascota.Sexo = Console.ReadLine();

            arbol.Insertar(mascota);
            Console.WriteLine("\nMascota agregada exitosamente!");
        }

        private static void BuscarMascota()
        {
            Console.Write("Ingrese el código de mascota a buscar: ");
            int codigo = int.Parse(Console.ReadLine());

            Mascota mascota = arbol.Buscar(codigo);
            if (mascota != null)
            {
                Console.WriteLine("\nMascota encontrada:");
                Console.WriteLine(mascota);
            }
            else
            {
                Console.WriteLine("\nMascota no encontrada.");
            }
        }

        private static void EliminarMascota()
        {
            Console.Write("Ingrese el código de mascota a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());

            Mascota mascota = arbol.Buscar(codigo);
            if (mascota != null)
            {
                arbol.Eliminar(codigo);
                Console.WriteLine("\nMascota eliminada exitosamente!");
            }
            else
            {
                Console.WriteLine("\nMascota no encontrada.");
            }
        }

        private static void MostrarReporte()
        {
            Console.WriteLine("=== REPORTE DE MASCOTAS ===");
            Console.WriteLine("\nCÓDIGO CLIENTE NOMBRE                          ALIAS          PESO     EDAD   RAZA            SEXO");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            arbol.InOrder();
        }

    }
}
