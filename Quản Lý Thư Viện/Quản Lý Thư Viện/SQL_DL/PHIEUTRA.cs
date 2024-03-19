namespace Quản_Lý_Thư_Viện.SQL_DL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTRA")]
    public partial class PHIEUTRA
    {
        [Key]
        [StringLength(50)]
        public string MAPHIEUTRA { get; set; }

        public DateTime? NGAYTRA { get; set; }

        [Required]
        [StringLength(50)]
        public string MASACH { get; set; }

        [Required]
        [StringLength(50)]
        public string MAPHIEUMUON { get; set; }

        public virtual CTPM CTPM { get; set; }
    }
}
