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
    
    public partial class Contribución
    {
        public int idCotribu { get; set; }
        public int IdInscrip { get; set; }
        public int IdBase { get; set; }
        public string Porcent { get; set; }
        public string Año { get; set; }
    
        public virtual Inscripción Inscripción { get; set; }
        public virtual N_BaseC N_BaseC { get; set; }
    }
}
