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
        string RegistrarPedido(Pedido pedido, List<PedidoProducto> pedidoProductos);

        [OperationContract]
        List<Pedido> RecuperarPedidos();

        [OperationContract]
        List<Pedido> RecuperarPedidosNoCancelados();

        [OperationContract]
        Pedido RecuperarPedido(string clave);

        [OperationContract]
        int CancelarPedido(string clave);

        [OperationContract]
        int ModificarPedido(Pedido pedido, List<PedidoProducto> productosAgregados);
    }
}
