using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Quản_Lý_Thư_Viện.SQL_DL
{
    public partial class QLTVDB : DbContext
    {
        public QLTVDB()
            : base("name=QLTVDB")
        {
        }

        public virtual DbSet<CTPM> CTPMs { get; set; }
        public virtual DbSet<DOCGIA> DOCGIAs { get; set; }
        public virtual DbSet<LOAISACH> LOAISACHes { get; set; }
        public virtual DbSet<PHIEUMUON> PHIEUMUONs { get; set; }
        public virtual DbSet<PHIEUPHAT> PHIEUPHATs { get; set; }
        public virtual DbSet<PHIEUTRA> PHIEUTRAs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTPM>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<CTPM>()
                .Property(e => e.MAPHIEUMUON)
                .IsUnicode(false);

            modelBuilder.Entity<CTPM>()
                .HasMany(e => e.PHIEUTRAs)
                .WithRequired(e => e.CTPM)
                .HasForeignKey(e => new { e.MASACH, e.MAPHIEUMUON })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.MADG)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .HasMany(e => e.PHIEUMUONs)
                .WithRequired(e => e.DOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCGIA>()
                .HasOptional(e => e.TAIKHOAN)
                .WithRequired(e => e.DOCGIA);

            modelBuilder.Entity<LOAISACH>()
                .Property(e => e.MALOAI)
                .IsUnicode(false);

            modelBuilder.Entity<LOAISACH>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.LOAISACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.MAPHIEUMUON)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.MADG)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUON>()
                .HasMany(e => e.CTPMs)
                .WithRequired(e => e.PHIEUMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUON>()
                .HasMany(e => e.PHIEUPHATs)
                .WithRequired(e => e.PHIEUMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUPHAT>()
                .Property(e => e.MAPHIEUPHAT)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUPHAT>()
                .Property(e => e.MAPHIEUMUON)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUTRA>()
                .Property(e => e.MAPHIEUTRA)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUTRA>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUTRA>()
                .Property(e => e.MAPHIEUMUON)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.TACGIA)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.NXB)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MALOAI)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CTPMs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MADG)
                .IsUnicode(false);
        }
    }
}
