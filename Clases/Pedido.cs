//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clases
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.PedidoProducto = new HashSet<PedidoProducto>();
        }
    
        public int IdPedido { get; set; }
        public string TipoEntrega { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> CostoTotal { get; set; }
        public string Direccion { get; set; }
        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoProducto> PedidoProducto { get; set; }
    }
}
