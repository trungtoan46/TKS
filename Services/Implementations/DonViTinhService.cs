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
            try
            {
                // Kiểm tra xem đơn vị tính có đang được sử dụng không
                var sanPhamUsing = await _context.SanPhams
                    .Where(sp => sp.Don_Vi_Tinh_ID == id)
                    .Select(sp => sp.Ten_San_Pham)
                    .ToListAsync();

                if (sanPhamUsing.Any())
                {
                    var productNames = string.Join(", ", sanPhamUsing.Take(3));
                    if (sanPhamUsing.Count > 3)
                        productNames += $" và {sanPhamUsing.Count - 3} sản phẩm khác";

                    throw new InvalidOperationException(
                        $"Không thể xóa đơn vị tính này vì đang được sử dụng bởi các sản phẩm: {productNames}");
                }

                // Tìm entity hiện tại
                var dvt = await _context.DonViTinhs.FindAsync(id);
                if (dvt == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy đơn vị tính với ID {id}");
                }

                // THỰC SỰ XÓA ENTITY
                _context.DonViTinhs.Remove(dvt);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Xử lý lỗi cơ sở dữ liệu
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                throw new InvalidOperationException($"Lỗi khi xóa đơn vị tính: {innerMessage}", ex);
            }
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

                // Cập nhật từng thuộc tính thay vì entity toàn bộ
                existingDvt.Ten_Don_Vi_Tinh = dvt.Ten_Don_Vi_Tinh;
                existingDvt.GhiChu = dvt.GhiChu;
                // Giữ nguyên trạng thái IsActive

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
