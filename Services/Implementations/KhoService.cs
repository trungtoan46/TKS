using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services
{
    public class KhoService : IKhoService
    {
        private readonly AppDbContext _context;
        public KhoService(AppDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(Kho kho)
        {
            var existing = _context.Khos.Where(k => k.Ten_Kho == kho.Ten_Kho)
                .FirstOrDefault();  
            if (existing != null)
            {
                throw new InvalidOperationException("Tên kho đã tồn tại");
            }


            _context.Khos.AddAsync(kho);
            return _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var kho = _context.Khos.Find(id);
            if (kho != null)
            {
                _context.Khos.Remove(kho);
                await _context.SaveChangesAsync();

            }

        }

        public async Task<List<Kho>> GetAllAsync()
        {
            return await _context.Khos.ToListAsync();
        }

        public async Task<Kho?> GetByIdAsync(int id)
        {
            return await _context.Khos.FindAsync(id);
            
        }

        public Task<List<Kho>> SearchAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Kho kho)
        {
             _context.Khos.Update(kho);
             await _context.SaveChangesAsync();
        }
    }
}