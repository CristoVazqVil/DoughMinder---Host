using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Contratos
{
    [ServiceContract]
    internal interface IPedido
    {
        [OperationContract]
        int RegistrarPedido(Pedido pedido, List<PedidoProducto> pedidoProductos);
    }
}
