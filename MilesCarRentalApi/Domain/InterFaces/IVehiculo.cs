using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterFaces
{
    public interface IVehiculo
    {
        Task<Success> SetVehiculo(Vehiculo vehiculo);
        Task<List<Disponibilidad>> VehiculosDisponibles(string localidadRecogida,string LocalidadDevolucion);
    }
}
