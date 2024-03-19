namespace Quản_Lý_Thư_Viện.SQL_DL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CTPMs = new HashSet<CTPM>();
        }

        [Key]
        [StringLength(50)]
        public string MASACH { get; set; }

        [StringLength(100)]
        public string TENSACH { get; set; }

        [StringLength(50)]
        public string TACGIA { get; set; }

        [StringLength(50)]
        public string NXB { get; set; }

        public long? GIASACH { get; set; }

        public long? SOLUONG { get; set; }

        [StringLength(100)]
        public string TINHTRANG { get; set; }

        [Required]
        [StringLength(50)]
        public string MALOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPM> CTPMs { get; set; }

        public virtual LOAISACH LOAISACH { get; set; }
    }
}
