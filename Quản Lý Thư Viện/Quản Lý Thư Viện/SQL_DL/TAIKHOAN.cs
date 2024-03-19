namespace Quản_Lý_Thư_Viện.SQL_DL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [StringLength(100)]
        public string TENDN { get; set; }

        [Key]
        [StringLength(50)]
        public string MADG { get; set; }

        [StringLength(100)]
        public string MK { get; set; }

        [StringLength(100)]
        public string QUYEN { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }
    }
}
