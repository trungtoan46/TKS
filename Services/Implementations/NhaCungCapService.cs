using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services 
{

    public class NhaCungCapService : INhaCungCapService
    {
        private readonly AppDbContext _context;

        public NhaCungCapService (AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(NhaCungCap ncc)
        {
            _context.NhaCungCaps.Add(ncc);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ncc = _context.NhaCungCaps.Find(id);
            if (ncc != null)
            {
                _context.NhaCungCaps.Remove(ncc);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<NhaCungCap>> GetAllAsync()
        {
            return _context.NhaCungCaps.AsNoTracking().ToListAsync();
        }

        public async Task<NhaCungCap?> GetByIdAsync(int id)
        {
            return await _context.NhaCungCaps.FindAsync(id);

        }

        public async Task<List<NhaCungCap>> Search(string keyword)
        {
            return await _context.NhaCungCaps
                .Where(ncc => ncc.Ma_NCC.Contains(keyword) || ncc.Ten_NCC.Contains(keyword))
                .AsNoTracking().ToListAsync();
                
        }

        public async Task UpdateAsync(NhaCungCap ncc)
        {
            _context.NhaCungCaps.Update(ncc);
            await _context.SaveChangesAsync();
        }
    }
}
