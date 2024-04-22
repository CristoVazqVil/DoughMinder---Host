using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Contratos
{
    [ServiceContract]
    internal interface IProveedor
    {
        [OperationContract]
        int GuardarProveedor(Proveedor proveedor);

        [OperationContract]
        List<Proveedor> RecuperarProveedores();

        [OperationContract]
        int ReemplazarProveedor(string RFC);
    }
}
