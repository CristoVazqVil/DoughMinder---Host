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
