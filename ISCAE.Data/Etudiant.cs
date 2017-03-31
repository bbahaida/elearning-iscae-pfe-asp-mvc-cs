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
    
    public partial class Etudiant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Etudiant()
        {
            this.DocumentNonOfficiels = new HashSet<DocumentNonOfficiel>();
            this.Questions = new HashSet<Question>();
            this.Reponses = new HashSet<Repons>();
        }
    
        public int EtudiantId { get; set; }
        public string Nom { get; set; }
        public string Matricule { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public byte isActive { get; set; }
        public byte Niveau { get; set; }
        public int SpecialiteId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentNonOfficiel> DocumentNonOfficiels { get; set; }
        public virtual Specialite Specialite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repons> Reponses { get; set; }
    }
}
