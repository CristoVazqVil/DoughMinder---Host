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
    
    public partial class SolicitudProducto
    {
        public int IdSolicitudProducto { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<int> IdSolicitud { get; set; }
        public string ClaveProducto { get; set; }
        public Nullable<int> IdInsumo { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Solicitud Solicitud { get; set; }
        public virtual Insumo Insumo { get; set; }
    }
}
