namespace Quản_Lý_Thư_Viện.SQL_DL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUPHAT")]
    public partial class PHIEUPHAT
    {
        [Key]
        [StringLength(50)]
        public string MAPHIEUPHAT { get; set; }

        public DateTime? NGAYLAP { get; set; }

        [StringLength(100)]
        public string LYDO { get; set; }

        [StringLength(100)]
        public string HINHTHUC { get; set; }

        [Required]
        [StringLength(50)]
        public string MAPHIEUMUON { get; set; }

        public virtual PHIEUMUON PHIEUMUON { get; set; }
    }
}
