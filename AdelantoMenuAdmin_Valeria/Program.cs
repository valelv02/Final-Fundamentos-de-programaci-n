using System;

namespace TrabajoFinal
{
    internal class Program
    {
        static string adminU = "admin", adminP = "1234";
        static string[] cId = new string[15], cNom = new string[15], cDir = new string[15], cTel = new string[15], cU = new string[15], cP = new string[15];
        static int totalC = 0;
        static string[] kId = new string[15], kNom = new string[15];
        static int totalK = 0;

        static void Main(string[] args)
        {
            cId[0] = "101"; cNom[0] = "Paloma Pulido"; cDir[0] = "Calle 10"; cTel[0] = "300123"; cU[0] = "cajero1"; cP[0] = "1234"; totalC = 1;

            bool activo = true;
            while (activo)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE RUTAS Y TIQUETES ===");
                int intentos = 0;
                bool ok = false;
                string rol = "";

                while (intentos < 3 && !ok)
                {
                    Console.Write("\nUsuario: "); string u = Console.ReadLine().ToLower();
                    Console.Write("Contraseña: "); string p = Console.ReadLine();
                    Console.Write("Rol (Admin/Cajero): "); string r = Console.ReadLine().ToLower();

                    if ((r == "admin" || r == "administrador") && u == adminU.ToLower() && p == adminP) { ok = true; rol = "Admin"; }
                    else if (r == "cajero" && totalC > 0)
                    {
                        for (int i = 0; i < totalC; i++)
                            if (cU[i].ToLower() == u && cP[i] == p) { ok = true; rol = "Cajero"; break; }
                    }

                    if (!ok) { intentos++; Console.WriteLine($"Error. Intentos: {intentos}/3"); }
                }

                if (!ok) { Console.WriteLine("\n[BLOQUEADO] Contacte a soporte."); Console.ReadKey(); activo = false; }
                else
                {
                    Console.WriteLine($"\nBienvenido {rol}. Presione una tecla..."); Console.ReadKey();
                    if (rol == "Admin") MenuAdmin();
                    else Console.WriteLine("\n[Lado de Paloma en construcción]");
                }
            }
        }

        static void MenuAdmin()
        {
            int op = -1;
            while (op != 6)
            {
                Console.Clear();
                Console.WriteLine("=== ADMIN ===\n1. Clave Admin  2. Crear Cajero  3. Ver Cajeros  4. Crear Conductor  5. Ver Conductores  6. Salir");
                op = int.Parse(Console.ReadLine());

                if (op == 1) { Console.Write("Nueva pass: "); adminP = Console.ReadLine(); }
                else if (op == 2 && totalC < 15)
                {
                    Console.Write("ID: "); string id = Console.ReadLine();
                    Console.Write("Nombre: "); string nom = Console.ReadLine();
                    Console.Write("Dirección: "); string dir = Console.ReadLine();
                    Console.Write("Celular: "); string tel = Console.ReadLine();
                    Console.Write("Usuario: "); string user = Console.ReadLine();
                    Console.Write("Contraseña: "); string pass1 = Console.ReadLine();
                    Console.Write("Confirme Contraseña: "); string pass2 = Console.ReadLine();

                    if (pass1 == pass2)
                    {
                        cId[totalC] = id; cNom[totalC] = nom; cDir[totalC] = dir; cTel[totalC] = tel; cU[totalC] = user; cP[totalC] = pass1;
                        totalC++;
                        Console.WriteLine("\n¡Cajero guardado con éxito!");
                    }
                    else { Console.WriteLine("\n[ERROR] Las contraseñas no coinciden. No se guardó."); }
                    Console.ReadKey();
                }
                else if (op == 3)
                {
                    for (int i = 0; i < totalC; i++) Console.WriteLine($"{i + 1}. ID:{cId[i]} | {cNom[i]} | User:{cU[i]}");
                    Console.ReadKey();
                }
                else if (op == 4 && totalK < 15)
                {
                    Console.Write("ID Conductor: "); kId[totalK] = Console.ReadLine();
                    Console.Write("Nombre: "); kNom[totalK] = Console.ReadLine();
                    totalK++;
                    Console.WriteLine("\n¡Conductor guardado!"); Console.ReadKey();
                }
                else if (op == 5)
                {
                    for (int i = 0; i < totalK; i++) Console.WriteLine($"{i + 1}. ID:{kId[i]} | {kNom[i]}");
                    Console.ReadKey();
                }
            }
        }
    }

    // PENDIENTE: Agregar opción para Editar Cajeros
    // PENDIENTE: Agregar opción para Editar Conductores
    // PENDIENTE: Agregar opción para Asignar Rutas a Conductor en la Matriz [15, 5]
}