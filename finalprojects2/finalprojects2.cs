namespace DistribucionQuimicos
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numCamiones = 20;
            int camionesDespachados = 0;
            int camionesRechazados = 0;
            int totalLitros = 0;

            for (int i = 0; i < numCamiones; i++)
            {
                if (camionesDespachados == numCamiones)
                {
                    Console.WriteLine("Se han despachado 20 camiones. Proceso de carga completado.");
                    break;
                }

                Console.WriteLine($"Camión {i + 1}:");

                int capacidad = ObtenerCapacidad();
                if (capacidad == -1)
                {
                    camionesRechazados++;
                    Console.WriteLine("Camión rechazado por capacidad inadecuada.");
                    Console.WriteLine();
                    continue;
                }

                int litrosCargados = CargarCamion(capacidad);
                totalLitros += litrosCargados;
                camionesDespachados++;

                Console.WriteLine();
            }

            Console.WriteLine($"Camiones despachados: {camionesDespachados}");
            Console.WriteLine($"Camiones rechazados: {camionesRechazados}");
            Console.WriteLine($"Total de litros transportados: {totalLitros}");
        }

        static int ObtenerCapacidad()
        {
            int capacidad;
            while (true)
            {
                Console.Write("Ingrese la capacidad del camión (18000 - 28000 litros): ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out capacidad))
                {
                    if (capacidad >= 18000 && capacidad <= 28000)
                    {
                        return capacidad;
                    }
                    else
                    {
                        Console.WriteLine("Error: La capacidad del camión debe ser entre 18000 y 28000 litros.");
                        return -1;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese un número válido.");
                }
            }
        }

        static int CargarCamion(int capacidad)
        {
            int cargaActual = 0;

            while (cargaActual < capacidad)
            {
                int pesoSaca = ObtenerPesoSaca();

                if (cargaActual + pesoSaca <= capacidad)
                {
                    cargaActual += pesoSaca;
                    Console.WriteLine($"Saca de {pesoSaca} litros cargada. Carga actual: {cargaActual} litros.");
                }
                else if (capacidad - cargaActual < 3000)
                {
                    Console.WriteLine($"No se puede cargar más. Capacidad restante insuficiente ({capacidad - cargaActual} litros). Despachando camión.");
                    break;
                }
                else
                {
                    Console.WriteLine($"No se puede cargar la saca de {pesoSaca} litros. Capacidad excedida.");
                    break;
                }
            }

            Console.WriteLine($"Camión cargado con {cargaActual} litros. Enviando camión.");
            return cargaActual;
        }

        static int ObtenerPesoSaca()
        {
            int peso;
            while (true)
            {
                Console.Write("Ingrese el peso de la saca (3000 - 9000 litros): ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out peso))
                {
                    if (peso >= 3000 && peso <= 9000)
                    {
                        return peso;
                    }
                    else
                    {
                        Console.WriteLine("Error: El peso de la saca debe ser entre 3000 y 9000 litros.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese un número válido.");
                }
            }
        }
    }
}