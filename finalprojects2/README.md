# Final Projects S2

Este repositorio contiene la solución para el problema de distribución de químicos de una central de distribución de alcohol. La solución está implementada en C# y tiene como objetivo gestionar la carga de camiones con sacas de alcohol, asegurando que se cumplan los límites de capacidad de los camiones.

## Descripción del Problema

Una central de distribución de químicos distribuye alcohol hacia diferentes almacenes sucursales. Disponen de un muelle de carga donde llegan tanques de alcohol de entre 3000 y 9000 litros, con pesos variables según la producción. La empresa dispone de una flota de camiones con capacidades de carga de entre 18000 y 28000 litros.

Se pretende establecer un protocolo consistente en cargar 20 camiones diarios. Cada camión se quiere cargar como máximo a su límite de capacidad, debiendo partir si con la siguiente saca en la línea de producción se fuera a exceder su capacidad.

## Estructura del Proyecto

El proyecto está organizado de la siguiente manera:

- `finalprojects2.cs`: Archivo principal con la lógica del programa.
- `finalprojects2.sln`: Archivo de solución de Visual Studio.
- `bin/`: Directorio que contiene los archivos compilados.
- `obj/`: Directorio que contiene archivos de construcción intermedios.
- `Documentación Final Project S2.txt`: Documentación del proyecto.
- `Flow Chart Project Final S2.jpg`: Diagrama de flujo del proyecto.
- `Modelo de datos final project s2.png`: Modelo de datos del proyecto.

## Requisitos

Para ejecutar este proyecto, necesitas tener instalado:

- .NET SDK 8.0 o superior

## Cómo Ejecutar

1. Clona este repositorio en tu máquina local:

   ```bash
   git clone https://github.com/willbetancur/finalprojects2.git
   ```
Navega al directorio del proyecto:
bash
Copy code
cd finalprojects2
Construye el proyecto:

bash
Copy code
dotnet build
Ejecuta el proyecto:

bash
Copy code
dotnet run
Descripción del Código
El programa está estructurado en varias funciones para modularizar y simplificar la lógica:

Main: Punto de entrada del programa. Controla el flujo principal, incluyendo el bucle que procesa los 20 camiones.
ObtenerCapacidad: Solicita y valida la capacidad del camión.
CargarCamion: Controla la carga del camión, asegurándose de no exceder la capacidad.
ObtenerPesoSaca: Solicita y valida el peso de las sacas.
El programa usa estructuras secuenciales, de control y de repetición para garantizar un flujo lógico correcto. También se emplean funciones para modularizar el código y facilitar su mantenimiento.

Ejemplo de Ejecución
Al ejecutar el programa, se solicitará al usuario ingresar la capacidad de cada camión y el peso de cada saca. El programa mostrará mensajes indicando si la saca puede ser cargada o si el camión debe ser despachado.

yaml
Copy code
Camión 1:
Ingrese la capacidad del camión (18000 - 28000 litros): 25000
Ingrese el peso de la saca (3000 - 9000 litros): 5000
Saca de 5000 litros cargada. Carga actual: 5000 litros.
Ingrese el peso de la saca (3000 - 9000 litros): 6000
Saca de 6000 litros cargada. Carga actual: 11000 litros.
...
Camión cargado con 25000 litros. Enviando camión.

Camión 2:
...
Contribuciones
Las contribuciones son bienvenidas. Si deseas mejorar este proyecto, por favor realiza un fork del repositorio y crea un pull request con tus cambios.

Licencia
Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.
