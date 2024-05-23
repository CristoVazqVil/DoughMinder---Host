using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Contratos
{
    [ServiceContract]
    internal interface ISolicitud
    {
        [OperationContract]
        string RegistrarSolicitud(Solicitud solicitud, List<SolicitudProducto> solicitudProductos);

        [OperationContract]
        List<Solicitud> RecuperarSolicitudes();
    }
}
