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
    
    public partial class DPersonales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DPersonales()
        {
            this.Inscripción = new HashSet<Inscripción>();
            this.Salario = new HashSet<Salario>();
            this.TiempoServicio = new HashSet<TiempoServicio>();
        }
    
        public string CI { get; set; }
        public string Nombre { get; set; }
        public string Nombre2 { get; set; }
        public string Apll { get; set; }
        public string Apll2 { get; set; }
        public string Dirección { get; set; }
        public string NoCasa { get; set; }
        public string Calle1 { get; set; }
        public string Calle2 { get; set; }
        public string IdMun { get; set; }
        public string IdSexo { get; set; }
        public int IdEstado { get; set; }
        public int IdRégimen { get; set; }
        public Nullable<int> IdNotific { get; set; }
        public bool CiError { get; set; }
        public Nullable<System.DateTime> FCap { get; set; }
    
        public virtual Municipios Municipios { get; set; }
        public virtual NEstado NEstado { get; set; }
        public virtual NRégimen NRégimen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inscripción> Inscripción { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salario> Salario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TiempoServicio> TiempoServicio { get; set; }
        public virtual Cooperativas Cooperativas { get; set; }

        public string First_Name()
        {
            string nombre = string.Empty;
            nombre += this.Nombre.Trim();
            nombre += string.IsNullOrEmpty(this.Nombre2) ? " " + this.Nombre2.Trim() : "";
            return nombre;
        }
        public string Last_Name()
        {
            string apellidos = string.Empty;
            apellidos += this.Apll.Trim();
            apellidos += string.IsNullOrEmpty(this.Apll2) ? " " + this.Apll2.Trim() : "";
            return apellidos;
        }

    }
}
