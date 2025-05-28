using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services.Implementations
{
    public class NhapKhoRawService : INhapKhoRawService
    {
        private readonly AppDbContext _context;

        public NhapKhoRawService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NhapKhoRaw>> GetByPhieuIdAsync(int nhapKhoId)
        {
            return await _context.NhapKhoRaws
                .Where(x => x.Nhap_Kho_ID == nhapKhoId)
                .ToListAsync();
        }

        public async Task<NhapKhoRaw?> GetByIdAsync(int id)
        {
            return await _context.NhapKhoRaws.FindAsync(id);
        }

        public async Task AddAsync(NhapKhoRaw chiTiet)
        {
            _context.NhapKhoRaws.Add(chiTiet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NhapKhoRaw chiTiet)
        {
            _context.NhapKhoRaws.Update(chiTiet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var chiTiet = await _context.NhapKhoRaws.FindAsync(id);
            if (chiTiet != null)
            {
                _context.NhapKhoRaws.Remove(chiTiet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByProductAsync(int nhapKhoId, int sanPhamId)
        {
            return await _context.NhapKhoRaws
                .AnyAsync(x => x.Nhap_Kho_ID == nhapKhoId && x.San_Pham_ID == sanPhamId);
        }
    }
} 