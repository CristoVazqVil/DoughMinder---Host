using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Contratos
{
    [ServiceContract]
    internal interface IInsumo
    {
        [OperationContract]
        int GuardarInsumo(Insumo insumo);
    }
}
