//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciSistem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tBolum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tBolum()
        {
            this.tOgrenci = new HashSet<tOgrenci>();
        }
    
        public string bolumID { get; set; }
        public string bolumAd { get; set; }
        public string fakulteID { get; set; }
    
        public virtual tFakulte tFakulte { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tOgrenci> tOgrenci { get; set; }
    }
}