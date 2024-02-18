using Domain.InterFaces;
using Domain.Models;
using InfraData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraData.Services
{
    public class TipoVehiculoService(ConnectionContext connectionContext) : ITipoVehiculo
    {
        public async  Task<Success> SetTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            Success rpta = new Success();
            rpta.Estado = "";
            rpta.Respuesta = "";
            try
            {
                connectionContext.TipoVehiculo.Add(tipoVehiculo);
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
    }
}
