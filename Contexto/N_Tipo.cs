//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegimenesEspeciales.Contexto
{
    using System;
    using System.Collections.Generic;
    
    public partial class N_Tipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public N_Tipo()
        {
            this.TiempoServicio = new HashSet<TiempoServicio>();
        }
    
        public int IdTipo { get; set; }
        public string DescripTipo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TiempoServicio> TiempoServicio { get; set; }
    }
}
