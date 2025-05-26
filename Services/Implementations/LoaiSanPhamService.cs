using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services
{
    public class LoaiSanPhamService : ILoaiSanPhamService
    {
        private readonly AppDbContext _context;
        public LoaiSanPhamService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LoaiSanPham lsp)
        {
            var existingName = _context.LoaiSanPhams
                .Where(t =>  t.Ten_LSP == lsp.Ten_LSP )
                .FirstOrDefault();
            if (existingName != null)
            {
                throw new InvalidOperationException("Tên loại sản phẩm đã tồn tại");
            }
            var existingCode = _context.LoaiSanPhams
                .Where(t => t.Ma_LSP == lsp.Ma_LSP)
                .FirstOrDefault();
            if (existingCode != null)
            {
                throw new InvalidOperationException("Mã loại sản phẩm đã tồn tại");
            }

            _context.LoaiSanPhams.Add(lsp);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {

            var isLspUsed = await _context.SanPhams
                    .Where(sp => sp.Loai_San_Pham_ID == id)
                    .Select(sp => sp.Ten_San_Pham)
                    .ToListAsync();
            if (isLspUsed.Any())
            {
                var productNames = string.Join(", ", isLspUsed.Take(3));
                if (isLspUsed.Count > 3)
                    productNames += $" và {isLspUsed.Count - 3} sản phẩm khác";

                throw new InvalidOperationException(
                    $"Không thể xóa loại sản phẩm này vì đang được sử dụng bởi các sản phẩm: {productNames}");
            }

            var lsp = await _context.LoaiSanPhams.FindAsync(id);
            if (lsp != null)
            {
                _context.LoaiSanPhams.Remove(lsp);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<LoaiSanPham>> GetAllAsync()
        {
            return await _context.LoaiSanPhams.ToListAsync();
        }



        public async Task<LoaiSanPham?> GetByIdAsync(int id)
        {
            return await _context.LoaiSanPhams.FindAsync(id);
        }

        public async Task<List<LoaiSanPham>> SearchAsync(string keyword)
        {
            return await _context.LoaiSanPhams
                .Where(lsp => lsp.Ma_LSP.Contains(keyword) || lsp.Ten_LSP.Contains(keyword))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(LoaiSanPham lsp)
        {
             _context.LoaiSanPhams.Update(lsp);
            await _context.SaveChangesAsync();
        }
    }
}
