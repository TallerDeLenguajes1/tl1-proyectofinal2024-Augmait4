using System;
using Interfaz;
using menuSeleccionable;
using Musica;
using MonstersApi;
//Agrego esta linea para aceptar caracteres Especiales//
Console.OutputEncoding = System.Text.Encoding.UTF8;
//Oculto Cursor para una mejor Experiencia Visula//
Console.CursorVisible = false;
//Hago una llamada asincronica a la api//
await consumiendoApi.Get();
//Incio Music que se reproducira en bucle durante todo el juego//
Music.Inicio();
//Muestro Animacion Inicial del Juego //
Cartel.TituloJuego(7);
//Desarrollo de Juego Mediantes Menus//
menuu.menu();
