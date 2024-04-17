using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Contratos
{
    [ServiceContract]
    internal interface IReceta
    {
        [OperationContract]
        int GuardarReceta(Receta receta, Dictionary<int, float> listaInsumos);

        [OperationContract]
        Dictionary<int, string> RecuperarRecetas();

        [OperationContract]
        List<Receta> RecuperarRecetasCompletas();
    }
}
