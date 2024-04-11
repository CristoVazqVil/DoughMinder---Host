using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Contratos
{
    [ServiceContract]
    internal interface IMovimiento
    {
        [OperationContract]
        int RegistrarMovimiento(Movimiento movimiento);
    }
}
