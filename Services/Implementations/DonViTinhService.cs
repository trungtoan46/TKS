using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services
{
    public class DonViTinhService : IDonViTinhService
    {
        private readonly AppDbContext _context;

        public DonViTinhService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DonViTinh dvt)
        {
            var existing = _context.DonViTinhs
                .Where(d => d.Ten_Don_Vi_Tinh == dvt.Ten_Don_Vi_Tinh)
                .FirstOrDefault();
            if (existing != null)
            {
                throw new InvalidOperationException("Tên đơn vị đã tồn tại");
            }
            try
            {
                _context.DonViTinhs.Add(dvt);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding DonViTinh: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            

                var dvt = await _context.DonViTinhs.FindAsync(id);
                if (dvt == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy đơn vị tính với ID {id}");
                }

               
                _context.DonViTinhs.Remove(dvt);
                await _context.SaveChangesAsync();
            
            
        }

        public async Task<List<DonViTinh>> GetAllAsync()
        {
            return await _context.DonViTinhs
                .ToListAsync();
        }

        public async Task<DonViTinh?> GetByIdAsync(int id)
        {
            return await _context.DonViTinhs
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(DonViTinh dvt)
        {
            try
            {
                // Tìm entity hiện tại
                var existingDvt = await _context.DonViTinhs.FindAsync(dvt.Id);
                if (existingDvt == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy đơn vị tính với ID {dvt.Id}");
                }

                existingDvt.Ten_Don_Vi_Tinh = dvt.Ten_Don_Vi_Tinh;
                existingDvt.GhiChu = dvt.GhiChu;

                // Lưu thay đổi
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                throw new InvalidOperationException($"Lỗi khi cập nhật đơn vị tính: {innerMessage}", ex);
            }
        }
    }
}
