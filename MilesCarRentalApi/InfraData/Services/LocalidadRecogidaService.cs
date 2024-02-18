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
    public class LocalidadRecogidaService(ConnectionContext connectionContext) : ILocalidadRecogida
    {
        public async Task<Success> SetLocalidadRecogida(LocalidadRecogida localidadRecogida)
        {
            Success rpta = new Success();
            rpta.Estado = "";
            rpta.Respuesta = "";
            try
            {
                connectionContext.LocalidadRecogida.Add(localidadRecogida);
                await connectionContext.SaveChangesAsync();
                rpta.Estado = "Éxito";
                rpta.Respuesta = "Localidad de recogida agregada correctamente";
            }
            catch (Exception ex)
            {

                rpta.Estado = "Error";
                rpta.Respuesta = "Error al agregar la localidad de recogida: " + ex.Message;
            }
            return rpta;
        }
    }
}
