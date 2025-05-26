using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services
{
    public class KhoUserService : IKhoUserService
    {
        private readonly AppDbContext _context;
        public KhoUserService(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(KhoUser khoUser)
        {
            var existingCode = _context.KhoUsers
                .Where(k => k.Ma_Dang_Nhap == khoUser.Ma_Dang_Nhap)
                .FirstOrDefault();
            if (existingCode != null)
            {
                throw new InvalidOperationException();
            }
             _context.KhoUsers.AddAsync(khoUser);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = _context.KhoUsers.Find(id);
             _context.KhoUsers.Remove(item);
            await _context.SaveChangesAsync();
        }

        public Task<List<KhoUser>> GetAllAsync()
        {
            return _context.KhoUsers.ToListAsync();
        }

        public Task<KhoUser?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<KhoUser>> SearchAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(KhoUser KhoUser)
        {
            _context.KhoUsers.Update(KhoUser);
            await _context.SaveChangesAsync();
        }

        public async Task<KhoUser?> LoginAsync(string maDangNhap, int khoId)
        {
            return await _context.KhoUsers
                .FirstOrDefaultAsync(k => k.Ma_Dang_Nhap == maDangNhap && k.Kho_Id == khoId);
        }
    }
}
