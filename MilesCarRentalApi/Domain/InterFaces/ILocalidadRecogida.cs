using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterFaces
{
    public interface ILocalidadRecogida
    {
        Task<Success> SetLocalidadRecogida(LocalidadRecogida localidadRecogida);
    }
}
