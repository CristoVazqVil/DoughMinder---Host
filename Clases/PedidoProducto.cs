//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clases
{
    using System;
    using System.Collections.Generic;
    
    public partial class PedidoProducto
    {
        public int IdPedidoProducto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<int> IdPedido { get; set; }
        public string ClaveProducto { get; set; }
    
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
