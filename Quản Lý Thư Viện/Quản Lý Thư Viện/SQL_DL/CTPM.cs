namespace Quản_Lý_Thư_Viện.SQL_DL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPM")]
    public partial class CTPM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CTPM()
        {
            PHIEUTRAs = new HashSet<PHIEUTRA>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MASACH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MAPHIEUMUON { get; set; }

        public virtual PHIEUMUON PHIEUMUON { get; set; }

        public virtual SACH SACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRA> PHIEUTRAs { get; set; }
    }
}
