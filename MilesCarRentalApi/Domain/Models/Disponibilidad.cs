using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Disponibilidad
    {
        public string TipoVehiculo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public int Modelo { get; set; } 
        public string Color { get; set; } = string.Empty;
        public string LocalidadRecogida { get; set; } = string.Empty;
        public string LocalidadDevolucion { get; set; } = string.Empty;
    }
}
