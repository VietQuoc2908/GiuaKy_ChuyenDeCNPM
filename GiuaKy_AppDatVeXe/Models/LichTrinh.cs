//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiuaKy_AppDatVeXe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LichTrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichTrinh()
        {
            this.Ves = new HashSet<Ve>();
        }
    
        public int MaLT { get; set; }
        public string BienSo { get; set; }
        public string GioDi { get; set; }
        public Nullable<System.DateTime> NgayDi { get; set; }
        public string DiemDi { get; set; }
        public string DiemDen { get; set; }
        public decimal GiaTien { get; set; }
        public int TrangThai { get; set; }
    
        public virtual Xe Xe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
