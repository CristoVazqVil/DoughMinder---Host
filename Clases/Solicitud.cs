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
    
    public partial class Solicitud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitud()
        {
            this.SolicitudProducto = new HashSet<SolicitudProducto>();
        }
    
        public int IdSolicitud { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> CostoTotal { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public string Clave { get; set; }
    
        public virtual Proveedor Proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudProducto> SolicitudProducto { get; set; }
    }
}
