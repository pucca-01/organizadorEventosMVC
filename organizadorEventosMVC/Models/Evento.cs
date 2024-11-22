using System;

namespace OrganizadorEventosMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;  // Valor por defecto
        public string Lugar { get; set; } = string.Empty;   // Valor por defecto
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;  // Valor por defecto
    }
}

