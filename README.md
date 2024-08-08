# THE KING OF THE MONSTERS
***En un mundo devastado por la colisión de titanes ancestrales, la humanidad lucha por sobrevivir mientras monstruos colosales conocidos como kaijus emergen de las profundidades del planeta. "The King Of Monsters" te sumerge en un universo donde la tierra es el campo de batalla de gigantescas criaturas .***
---
## Historia
*Desde las montañas más altas hasta los océanos más profundos, estos monstruos han despertado para reclamar su dominio sobre la Tierra. Los humanos, indefensos ante la magnitud de estos seres, solo pueden observar mientras la naturaleza lucha por equilibrar su propio poder.*
---
## Objetivo del Juego
### El jugador debe tomar el control de uno de estos monstruos legendarios y enfrentarse a otros kaijus en batallas épicas. El objetivo es simple pero desafiante: derrotar a todos los rivales para convertirte en el rey o la reina de los monstruos.*

## Jugabilidad
**Seleccion de Dificultad**:

En "THE KING OF THE MONSTERS" deberas seleccionar la dificultad que mas se adapte a tu estilo de Juego:
- 1. ***Facil***: Un desafio para aquellos que desean tener un desenlace mas corto de la Historia al enfrentarse a solo 3 Rivales.
- 2. ***Normal***: Una dificultad especial para esos jugadores mas experimentado y listos para vencer en 5 batallas en la que cada nivel es mas desafiante.
- 3. ***Dificil***: Solo para aquellos que estas dispuestos a ganar en 7 intensas batallas donde las estadisticas de los rivales son casi imposibles de Vencer.

**Seleccion De Personajes**:

Se te otorgaran dependiendo de la dificultad una cantidad de personajes disponibles para su eleccion donde los no seleccionados sera tus rivales en la travesia para ser el nuevo rey de los Monstruos.

**Menu De Juego**:

En el Menu de Juego se te presentaran 5 opciones las cuales son:
- 1. ***Ir a la Pelea*** : Vas a empezar la lucha con tu proximo rival.
- 2. ***Rival*** : Podras observar las estadisticas de tu proximo Rival y prepararte mejor para enfrentarlo.
- 3. ***Estadisticas*** : Se te presentaran tus estadisticas.
- 4. ***Aumentar Estadisticas*** : Entraras en un menu interactivo donde podras elegir que estadisticas mejorar y la cantidad de Puntos disponibles.
- 5. ***Volver al menu Principal*** : Se te redirigira al Menu principal en caso de querer salir del Juego.

Al finalizar cada ronda aumentara tu nivel y el de tu enemigo, ademas se te otorgaran 30 puntos para mejorar tus estadisticas, en el caso de los enemigos sus estadisticas aumentaran un 80%.

Una vez vencidos todos tus rivales se prensentara un cartel de victoria y luego se te sera redirigido al menu principal donde podras ver tu logro como una marca de tiempo en el historial de ganadores, y luego podras decidir si comenzar otra partida o salir del Juego.

## Requisitos:
*1. Sistema Operativo Windows (para que todo funcione correctamente). Este proyecto no es compatible con linux ya que usa ciertas funciones que no son interpretadas en dicho sistema operativo.*  
*2. Tener instalado .Net versión 8.0 en su PC. Si no lo tiene descargado puede hacerlo desde [aqui](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)*  
*3. Clonar el repositorio actual desde una terminal de VisualStudioCode o desde la Bash de Git con el siguiente comando:*  
``` bash
    git clone https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-Augmait4.git
``` 
*De esta forma se descargará todo el juego en una carpeta con el nombre tl1-proyectofinal2024-Augmait4*  
*Luego debe abrir dicha carpeta con VisualStudioCode, abrir una nueva terminal y ejecutar el siguiente comando:*  
``` bash
    dotnet run
```

## API
La api usada es Godzillapi extraida del siguiente link:
https://www.godzillapi.com.

La Api se la uso para la extraccion de nombres relacionados al Monsterverse y mas informacion relacionada a este, parte de la Documentacion: 
* Get the full list of Monster: 
``` bash
    /api/monsters
```
* Query the API for a specific Monster by name by passing the name in the URL: 
``` bash
    /api/monsters/{name}
```
* Query the API for a specific Monster by first year appeared on screen by passing the year in the URL: 
``` bash
    /api/monsters/{year}
```
* Capitlize the first intial of the monster's name. Examples:

``` bash
    /api/monsters/name/Mechagodzilla
    /api/monsters/name/King_Kong
    /api/monsters/year/1994
```
En el link Encontraran mas informacion y otros ejemplos relacionados a la API.

## Respaldo
Ante la Posible caida de la pagina oficial de la API el juego esta diseñado para funcionar con un respaldo guardado en la carpeta de Backup, donde tiene la informacion y nombre de cada Monstruo, para realizar modificacion a ese repaldo en modo desconecta solo es necesario entrar a la siguiente direccion en la carpeta del juego:
``` bash
    "resources/backup"
```

## Librerias Externas
Para Agregar las Pistas de audio y ser reproducibles en .Net sea necesitado dercargar la libreria externa de System.Windows.Extensions, para hacer esto es necesario ejecutar el siguiente codigo en la terminal de Visual Studio Code:
``` bash
Install-Package System.Windows.Extensions -Version 6.0.0
```
Luego esta libreria nos aportara metodos que nos ayudaran en la reproduccion de audio del tipo _.WAV_, Para obtener mas informacion de la documentacion deberan ingresar al siguiente link que es oficial de la pagina de _.NET_ : https://learn.microsoft.com/en-us/dotnet/api/system.media?view=net-8.0.
