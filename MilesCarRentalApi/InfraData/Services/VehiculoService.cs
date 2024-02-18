using Domain.InterFaces;
using Domain.Models;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraData.Services
{
    public class VehiculoService(ConnectionContext connectionContext) : IVehiculo
    {
        public async  Task<Success> SetVehiculo(Vehiculo vehiculo)
        {
            Success rpta = new Success();
            rpta.Estado = "";
            rpta.Respuesta = "";
            try
            {
                connectionContext.Vehiculo.Add(vehiculo);
                await connectionContext.SaveChangesAsync();
                rpta.Estado = "Éxito";
                rpta.Respuesta = "Tipo de vehiculo agregado correctamente";
            }
            catch (Exception ex)
            {

                rpta.Estado = "Error";
                rpta.Respuesta = "Error al agregar Tipo de vehiculo: " + ex.Message;
            }
            return rpta;
        }

        public async  Task<List<Disponibilidad>> VehiculosDisponibles(string localidadRecogida, string LocalidadDevolucion)
        {  
           List<Disponibilidad> result = await connectionContext.VehiculosDisponibles.FromSqlRaw("EXECUTE dbo.PA_VehiculosDisponibles {0},{1}", localidadRecogida, LocalidadDevolucion).ToListAsync();
            return result;
        }
    }
}
