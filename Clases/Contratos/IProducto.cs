using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Contratos
{
    [ServiceContract]
    internal interface IProducto
    {

        [OperationContract]
        int GuardarProducto(Producto producto);

        [OperationContract]
        List<Producto> RecuperarProductosSinReceta();

        [OperationContract]
        List<Producto> RecuperarProductosParaPedido();

        [OperationContract]
        Producto RecuperarProducto(String codigoProducto);

        [OperationContract]
        int ModificarProducto(Producto producto, String codigoProducto);

        [OperationContract]
        int DeshabilitarProducto(String codigoProducto);


        [OperationContract]
        List<Producto> RecuperarProductos();
    }
}
