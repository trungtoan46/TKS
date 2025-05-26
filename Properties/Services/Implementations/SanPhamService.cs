using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services.Implementations
{
    public class SanPhamService : ISanPhamService
    {
        private readonly AppDbContext _context;

        public SanPhamService (AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SanPham sp)
        {
            _context.SanPhams.Add(sp);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sp = _context.SanPhams.Find(id);
            if (sp != null)
            {
                _context.SanPhams.Remove(sp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SanPham>> FillterAsync(int? dvtId, int? lspId)
        {
            var query = _context.SanPhams
                .Include(x => x.Loai_San_Pham_ID)
                .Include(x => x.Don_Vi_Tinh_ID)
                .AsQueryable();

            if (lspId.HasValue)
            {
                query = query.Where(s => s.Equals(lspId.Value));
            }

            if (dvtId.HasValue)
            {
                query = query.Where(s => s.Equals(dvtId.Value));
            }

            return await query.AsNoTracking().ToListAsync();



        }

        public async Task<List<SanPham>> GetAllAsync()
        {
            return await _context.SanPhams.AsNoTracking().ToListAsync();
        }

        public async Task<SanPham?> GetByIdAsync(int id)
        {
            return await _context.SanPhams.FindAsync(id);
        }

        public Task<List<SanPham>> Search(string keyword)
        {
           return _context.SanPhams
                .Where(sp => sp.Ma_San_Pham.Contains(keyword) || sp.Ten_San_Pham.Contains(keyword))
                .AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(SanPham sp)
        {
            _context.SanPhams.Update(sp);
            await _context.SaveChangesAsync();
        }
    }
}
