//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISCAE.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProfesseurSpecialite
    {
        public int ProfesseurSpecialiteId { get; set; }
        public int ProfesseurId { get; set; }
        public int SpecialiteId { get; set; }
    
        public virtual Professeur Professeur { get; set; }
        public virtual Specialite Specialite { get; set; }
    }
}