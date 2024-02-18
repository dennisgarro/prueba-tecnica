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
    public class LocalidadDevolucionService(ConnectionContext connectionContext) : ILocalidadDevolucion
    {
        public async Task<Success> SetLocalidadDevolucion(LocalidadDevolucion localidadDevolucion)
        {

            Success rpta = new Success();
            rpta.Estado = "";
            rpta.Respuesta = "";
            try
            {
                connectionContext.LocalidadDevolucion.Add(localidadDevolucion);
                await connectionContext.SaveChangesAsync();
                rpta.Estado = "Éxito";
                rpta.Respuesta = "Localidad de devolución agregada correctamente";
            }
            catch (Exception ex)
            {

                rpta.Estado = "Error";
                rpta.Respuesta = "Error al agregar la localidad de devolución: " + ex.Message;
            }
            return rpta;

        }
    }
}
