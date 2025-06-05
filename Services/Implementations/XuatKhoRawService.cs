using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services.Implementations
{
    public class XuatKhoRawService : IXuatKhoRawService
    {
        private readonly AppDbContext _context;

        public XuatKhoRawService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<XuatKhoRaw>> GetByPhieuIdAsync(int xuatKhoId)
        {
            return await _context.XuatKhoRaws
                .Where(x => x.Xuat_Kho_ID == xuatKhoId)
                .ToListAsync();
        }

        public async Task<XuatKhoRaw?> GetByIdAsync(int id)
        {
            return await _context.XuatKhoRaws.FindAsync(id);
        }

        public async Task AddAsync(XuatKhoRaw chiTiet)
        {
            _context.XuatKhoRaws.Add(chiTiet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(XuatKhoRaw chiTiet)
        {
            _context.XuatKhoRaws.Update(chiTiet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var chiTiet = await _context.XuatKhoRaws.FindAsync(id);
            if (chiTiet != null)
            {
                _context.XuatKhoRaws.Remove(chiTiet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByProductAsync(int xuatKhoId, int sanPhamId)
        {
            return await _context.XuatKhoRaws
                .AnyAsync(x => x.Xuat_Kho_ID == xuatKhoId && x.San_Pham_ID == sanPhamId);
        }

        public Task<List<XuatKhoRaw>> GetAllAsync()
        {
            return _context.XuatKhoRaws.ToListAsync();
        }
    }
} 