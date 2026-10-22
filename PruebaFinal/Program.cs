using System;

class Program
{
    private static string userCajero = "cajero1";
    private static string passCajero = "1234";

    private static string[,] matrizRutas = new string[16, 5];
    private static int contadorRutas = 0;

    private static string[,] matrizConductores = new string[16, 2];
    private static int contadorConductores = 0;

    static void Main(string[] args)
    {
        MostrarMenuCajero();
    }

    public static void MostrarMenuCajero()
    {
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("       MENÚ CAJERO (" + userCajero + ")       ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Gestión cuenta cajero");
            Console.WriteLine("2. Gestión de rutas");
            Console.WriteLine("3. Realizar venta");
            Console.WriteLine("4. Salir (Cerrar sesión)");
            Console.Write("Seleccione una opción: ");

            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        MenuGestionCuenta();
                        break;
                    case 2:
                        MenuGestionRutas();
                        break;
                    case 3:
                        RealizarVenta();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo de la sesión de cajero...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido. Presione una tecla para continuar.");
                Console.ReadKey();
            }
        } while (opcion != 4);
    }

    private static void MenuGestionCuenta()
    {
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN CUENTA CAJERO ===");
            Console.WriteLine("Usuario actual: " + userCajero);
            Console.WriteLine("1. Editar usuario");
            Console.WriteLine("2. Editar contraseña");
            Console.WriteLine("3. Salir (Regresa al menú cajero)");
            Console.Write("Seleccione una opción: ");

            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nuevo nombre de usuario: ");
                        string nuevoUsuario = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevoUsuario))
                        {
                            userCajero = nuevoUsuario;
                            Console.WriteLine("Usuario actualizado con éxito");
                        }
                        else
                        {
                            Console.WriteLine("El nombre no puede estar vacío");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Ingrese la nueva contraseña: ");
                        string nuevaPass = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevaPass))
                        {
                            passCajero = nuevaPass;
                            Console.WriteLine("Contraseña actualizada con éxito");
                        }
                        else
                        {
                            Console.WriteLine("La contraseña no puede estar vacía");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        Console.ReadKey();
                        break;
                }
            }
        } while (opcion != 3);
    }

    private static void MenuGestionRutas()
    {
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE RUTAS ===");
            Console.WriteLine("1. Crear ruta");
            Console.WriteLine("2. Editar ruta");
            Console.WriteLine("3. Ver lista de rutas");
            Console.WriteLine("4. Asignar conductor a ruta");
            Console.WriteLine("5. Salir (Regresa al menú cajero)");
            Console.Write("Seleccione una opción: ");

            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        CrearRuta();
                        break;
                    case 2:
                        EditarRuta();
                        break;
                    case 3:
                        VerListaRutas();
                        Console.WriteLine("\nPresione una tecla para continuar");
                        Console.ReadKey();
                        break;
                    case 4:
                        AsignarConductorARuta();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        Console.ReadKey();
                        break;
                }
            }
        } while (opcion != 5);
    }

    private static void CrearRuta()
    {
        Console.Clear();
        Console.WriteLine("=== CREAR RUTA ===");
        if (contadorRutas >= 15)
        {
            Console.WriteLine("Capacidad máxima de rutas alcanzada");
            Console.ReadKey();
            return;
        }

        string id = (contadorRutas + 1).ToString();
        Console.Write("Ingrese el nombre o destino de la ruta: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el horario: ");
        string horario = Console.ReadLine();

        matrizRutas[contadorRutas, 0] = id;
        matrizRutas[contadorRutas, 1] = nombre;
        matrizRutas[contadorRutas, 2] = horario;
        matrizRutas[contadorRutas, 3] = "Sin asignar";

        contadorRutas++;
        Console.WriteLine("Ruta creada exitosamente");
        Console.ReadKey();
    }

    private static void EditarRuta()
    {
        Console.Clear();
        Console.WriteLine("=== EDITAR RUTA ===");
        VerListaRutas();

        if (contadorRutas == 0)
        {
            Console.ReadKey();
            return;
        }

        Console.Write("\nIngrese el ID de la ruta que desea editar: ");
        string idBuscado = Console.ReadLine();
        int index = -1;

        for (int i = 0; i < contadorRutas; i++)
        {
            if (matrizRutas[i, 0] == idBuscado)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            Console.Write("Nuevo nombre (Actual: " + matrizRutas[index, 1] + "): ");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nombre)) matrizRutas[index, 1] = nombre;

            Console.Write("Nuevo horario (Actual: " + matrizRutas[index, 2] + "): ");
            string horario = Console.ReadLine();
            if (!string.IsNullOrEmpty(horario)) matrizRutas[index, 2] = horario;
            Console.WriteLine("Ruta actualizada con éxito");
        }
        else
        {
            Console.WriteLine("Ruta no encontrada");
        }
        Console.ReadKey();
    }

    private static void VerListaRutas()
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE RUTAS ===");
        if (contadorRutas == 0)
        {
            Console.WriteLine("No hay rutas registradas");
            return;
        }

        for (int i = 0; i < contadorRutas; i++)
        {
            Console.WriteLine("ID: " + matrizRutas[i, 0] + " | Ruta: " + matrizRutas[i, 1] + " | Horario: " + matrizRutas[i, 2] + " | Conductor: " + matrizRutas[i, 4]);
        }
    }

    private static void AsignarConductorARuta()
    {
        Console.Clear();
        Console.WriteLine("=== ASIGNAR CONDUCTOR A RUTA ===");

        if (contadorConductores == 0)
        {
            Console.WriteLine("El administrador no ha creado conductores en el sistema.");
            Console.ReadKey();
            return;
        }

        VerListaRutas();
        if (contadorRutas == 0)
        {
            Console.ReadKey();
            return;
        }

        Console.Write("\nIngrese el ID de la ruta: ");
        string idRuta = Console.ReadLine();
        int indexRuta = -1;

        for (int i = 0; i < contadorRutas; i++)
        {
            if (matrizRutas[i, 0] == idRuta)
            {
                indexRuta = i;
                break;
            }
        }

        if (indexRuta != -1)
        {
            Console.WriteLine("\nConductores disponibles:");
            for (int i = 0; i < contadorConductores; i++)
            {
                Console.WriteLine("ID: " + matrizConductores[i, 0] + " - Nombre: " + matrizConductores[i, 1]);
            }

            Console.Write("Ingrese el ID del conductor a asignar: ");
            string idConductor = Console.ReadLine();
            int indexConductor = -1;

            for (int i = 0; i < contadorConductores; i++)
            {
                if (matrizConductores[i, 0] == idConductor)
                {
                    indexConductor = i;
                    break;
                }
            }

            if (indexConductor != -1)
            {
                matrizRutas[indexRuta, 4] = matrizConductores[indexConductor, 1];
                Console.WriteLine("Conductor asignado a la ruta exitosamente");
            }
            else
            {
                Console.WriteLine("Conductor no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Ruta no encontrada");
        }
        Console.ReadKey();
    }
    private static void RealizarVenta()
    {
        Console.Clear();
        Console.WriteLine("=== REALIZAR VENTA ===");


    }
}