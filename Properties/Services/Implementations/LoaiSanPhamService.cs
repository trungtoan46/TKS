using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services.Implementations
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
            _context.LoaiSanPhams.Add(lsp);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lsp = _context.LoaiSanPhams.Find(id);
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
