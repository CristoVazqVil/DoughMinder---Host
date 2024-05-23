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

        [OperationContract]
        Dictionary<int, string> RecuperarInsumos();

        [OperationContract]
        List<Insumo> RecuperarTodosInsumos();

        [OperationContract]
        Insumo RecuperarInsumo(String codigoInsumo);

        [OperationContract]
        int ModificarInsumo(Insumo insumo, String codigoInsumo);

        [OperationContract]
        int DeshabilitarInsumo(String codigoInsumo);

        [OperationContract]

        Dictionary<string, float> RecuperarInsumosDeReceta(int idReceta);

        [OperationContract]

        int ActualizarCantidadInsumos(List<Insumo> insumos);
    }
}
