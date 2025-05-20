using Microsoft.EntityFrameworkCore;

namespace TKS.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Models.NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<Models.SanPham> SanPhams { get; set; }
        public DbSet<Models.LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<Models.DonViTinh> DonViTinhs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Models.SanPham>()
                .HasIndex(sp => new { sp.Loai_San_Pham_ID, sp.Ten_San_Pham, sp.Ma_San_Pham, sp.Don_Vi_Tinh_ID });

            modelBuilder.Entity<Models.DonViTinh>()
                .HasIndex(dvt => new {dvt.TenDonViTinh });

            modelBuilder.Entity<Models.LoaiSanPham>()
                .HasIndex(lsp => new {lsp.Ma_LSP, lsp.Ten_LSP });

            modelBuilder.Entity<Models.NhaCungCap>()
                .HasIndex(ncc => ncc.Ten_NCC);
        }

    }
}
