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
    
    public partial class Empleado
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public Nullable<int> IdPuesto { get; set; }
        public string Telefono { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string RFC { get; set; }
    
        public virtual Puesto Puesto { get; set; }
    }
}
