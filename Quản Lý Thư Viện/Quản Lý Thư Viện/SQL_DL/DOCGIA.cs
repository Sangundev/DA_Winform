namespace Quản_Lý_Thư_Viện.SQL_DL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCGIA")]
    public partial class DOCGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCGIA()
        {
            PHIEUMUONs = new HashSet<PHIEUMUON>();
        }

        [Key]
        [StringLength(50)]
        public string MADG { get; set; }

        [StringLength(100)]
        public string TENDG { get; set; }

        [StringLength(10)]
        public string GIOITINH { get; set; }

        public DateTime? NAMSINH { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON> PHIEUMUONs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
