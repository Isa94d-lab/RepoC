using demopoo;
using demopoo.Equipo;

internal class Program
{
    static List<Club> clubes = new List<Club>();

    private static void Main(string[] args)
    {
        bool continuar = true;
        string titulo = "Sistema de gestión de la Libertadores";
        string[] opcionesMenu = {
            "1. Registrar Club",
            "2. Registrar Jugador",
            "3. Listar Clubes",
            "4. Listar Jugadores",
            "5. Salir"
        };

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Sistema de gestión de la Conmebol Libertadores.");
            int opcion = Utilidades.LeerCaracter(titulo, opcionesMenu);

            switch (opcion)
            {
                case 1:
                    RegistrarClub();
                    break;
                case 2:
                    RegistrarJugador();
                    break;
                case 3:
                    ListarClubes();
                    break;
                case 4:
                    ListarJugadores();
                    break;
                case 5:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    PresionarEnter();
                    break;
            }
        }
    }

    static void RegistrarClub()
    {
        Console.Clear();
        Console.WriteLine("== Registro de Club ==");

        Club club = new Club();
        Guid g = Guid.NewGuid();

        Console.WriteLine($"ID generado: {g}");
        club.Id = g.ToString();
        PresionarEnter();

        Console.Write("Nombre del club: ");
        string? nombre = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("Nombre inválido.");
            PresionarEnter();
            return;
        }
        club.Nombre = nombre.ToUpper();
        PresionarEnter();

        clubes.Add(club);

        Console.WriteLine("Club registrado correctamente.");
        PresionarEnter();
    }

    static void RegistrarJugador()
    {
        Console.Clear();
        Console.WriteLine("== Registro de Jugador ==");

        if (clubes.Count == 0)
        {
            Console.WriteLine("No hay clubes registrados. Debe registrar un club primero.");
            PresionarEnter();
            return;
        }

        Console.WriteLine("Clubes disponibles:");
        foreach (var club in clubes)
        {
            Console.WriteLine($"ID: {club.Id}, Nombre: {club.Nombre}");
        }
        PresionarEnter();

        Console.Write("\nIngrese el nombre del club al que pertenece el jugador: ");
        string? clubNombre = Console.ReadLine()?.ToUpper();
        var clubSeleccionado = clubes.FirstOrDefault(c => c.Nombre == clubNombre);

        if (clubSeleccionado == null)
        {
            Console.WriteLine("Nombre de club no encontrado.");
            PresionarEnter();
            return;
        }
        PresionarEnter();

        Console.Write("ID del jugador: ");
        string id = Console.ReadLine() ?? string.Empty;
        PresionarEnter();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? string.Empty;
        PresionarEnter();

        Console.Write("Apellido: ");
        string apellido = Console.ReadLine() ?? string.Empty;
        PresionarEnter();

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine() ?? string.Empty;
        PresionarEnter();

        Console.Write("Correo: ");
        string correo = Console.ReadLine() ?? string.Empty;
        PresionarEnter();

        Console.Write("Dirección: ");
        string direccion = Console.ReadLine() ?? string.Empty;
        PresionarEnter();

        Console.Write("Posición: ");
        string posicion = Console.ReadLine() ?? string.Empty;
        PresionarEnter();

        Console.Write("Número: ");
        int numero;
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Número inválido. Intente de nuevo: ");
        }
        PresionarEnter();
 

        Player nuevoJugador = new Player(id, nombre, apellido, telefono, correo, direccion, posicion, numero);
        clubSeleccionado.Jugadores.Add(nuevoJugador);

        Console.WriteLine($"Jugador {nombre} {apellido} agregado al club {clubSeleccionado.Nombre}.");
        PresionarEnter();
    }

    static void ListarClubes()
    {
        Console.Clear();
        Console.WriteLine("== Clubes Registrados ==");

        if (clubes.Count == 0)
        {
            Console.WriteLine("No hay clubes registrados.");
        }
        else
        {
            foreach (var club in clubes)
            {
                Console.WriteLine($"ID: {club.Id}, Nombre: {club.Nombre}");
            }
        }

        PresionarEnter();
    }

    static void ListarJugadores()
    {
        Console.Clear();
        Console.WriteLine("== Jugadores Registrados ==");

        if (clubes.Count == 0)
        {
            Console.WriteLine("No hay clubes registrados.");
        }
        else
        {
            foreach (var club in clubes)
            {
                Console.WriteLine($"\nClub: {club.Nombre}");
                if (club.Jugadores.Count == 0)
                {
                    Console.WriteLine("  No hay jugadores registrados.");
                }
                else
                {
                    foreach (var jugador in club.Jugadores)
                    {
                        Console.WriteLine($"  - {jugador.Nombre} {jugador.Apellido} (#{jugador.Number}, {jugador.Position})");
                    }
                }
            }
        }

        PresionarEnter();
    }

    static void PresionarEnter()
    {
        Console.WriteLine("Presiona ENTER para continuar ->");
        Console.ReadKey();
    }
}
