//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class factura
    {
        public int Id { get; set; }
        public System.DateTime fecha { get; set; }
        public int Id_cliente { get; set; }
        public int Id_vendedor { get; set; }
        public int Id_producto { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual producto producto { get; set; }
        public virtual vendedor vendedor { get; set; }
    }
}
