using Microsoft.AspNetCore.Mvc;
using OrganizadorEventosMVC.Models;
using System.Collections.Generic;

namespace organizadorEventosMVC.Controllers
{
    public class EventoController : Controller
    {
        // Lista de eventos (esto lo sustituiremos por una base de datos más adelante)
        private static List<Evento> eventos = new List<Evento>
        {
            new Evento { Id = 1, Nombre = "Conferencia de Tecnología", Lugar = "Auditorio Principal", Fecha = new DateTime(2024, 12, 15), Descripcion = "Evento sobre las últimas tendencias en tecnología." },
            new Evento { Id = 2, Nombre = "Taller de Diseño Web", Lugar = "Sala de Capacitación", Fecha = new DateTime(2024, 12, 20), Descripcion = "Taller práctico para aprender diseño web." }
        };

        // Acción para mostrar la lista de eventos
        public IActionResult Index()
        {
            return View(eventos);  // Pasa la lista de eventos a la vista
        }

        // Acción para crear un nuevo evento
        public IActionResult Crear()
        {
            return View();  // Retorna la vista de creación
        }

        // Acción para guardar el nuevo evento
        [HttpPost]
        public IActionResult Crear(Evento evento)
        {
            if (ModelState.IsValid)
            {
                eventos.Add(evento);  // Agrega el nuevo evento a la lista
                return RedirectToAction("Index");  // Redirige a la lista de eventos
            }
            return View(evento);  // Si hay errores, vuelve a la vista de creación
        }
    }
}

