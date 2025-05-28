using Microsoft.EntityFrameworkCore;
using TKS.Models;

namespace TKS.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<DonViTinh> DonViTinhs { get; set; }

        public DbSet<Kho> Khos { get; set; }
        public DbSet<KhoUser> KhoUsers { get; set; }
        public DbSet<NhapKho> NhapKhos { get; set; }
        public DbSet<NhapKhoRaw> NhapKhoRaws { get; set; }
        public DbSet<XNK_Nhap_Kho> XNK_Nhap_Khos { get; set; }
        public DbSet<XuatKho> XuatKhos { get; set; }
        public DbSet<XuatKhoRaw> XuatKhoRaws { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<SanPham>()
                .HasIndex(sp => new { sp.Loai_San_Pham_ID, sp.Ten_San_Pham, sp.Ma_San_Pham, sp.Don_Vi_Tinh_ID })
                .IsUnique();

            modelBuilder.Entity<SanPham>()
                .HasOne(sp => sp.donViTinh)
                .WithMany()
                .HasForeignKey(sp => sp.Don_Vi_Tinh_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();

            modelBuilder.Entity<SanPham>()
                .HasOne(sp => sp.loaiSanPham)
                .WithMany()
                .HasForeignKey(sp => sp.Loai_San_Pham_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();


            modelBuilder.Entity<DonViTinh>()
                .HasIndex(dvt => dvt.Ten_Don_Vi_Tinh)
                .IsUnique();
            
            modelBuilder.Entity<LoaiSanPham>()
                .HasIndex(lsp => new { lsp.Ma_LSP, lsp.Ten_LSP })
                .IsUnique();

            modelBuilder.Entity<NhaCungCap>()
                .HasIndex(ncc => ncc.Ten_NCC)
                .IsUnique();


            modelBuilder.Entity<Kho>()
                .HasIndex(kho => kho.Ten_Kho)
                .IsUnique();

            modelBuilder.Entity<NhapKho>()
                .HasIndex(phieu => phieu.So_Phieu_Nhap_Kho)
                .IsUnique();
        }

    }
}
