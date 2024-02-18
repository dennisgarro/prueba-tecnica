using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int? Id { get; set; }
        public int Id_LocalidadRecogida { get; set; }
        public int Id_LocalidadDevolucion { get; set; }
        public int Id_TipoVehiculo { get; set; }
        public string? Marca { get; set; }
        public int Modelo { get; set; }
        public string? Color { get; set; }
    }
}
