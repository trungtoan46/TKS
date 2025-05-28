using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services.Implementations
{
    public class XuatKhoService : IXuatKhoService
    {
        private readonly AppDbContext _context;

        public XuatKhoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<XuatKho>> GetAllAsync()
        {
            return await _context.XuatKhos
                .OrderByDescending(x => x.Ngay_Xuat_Kho)
                .ToListAsync();
        }

        public async Task<XuatKho?> GetByIdAsync(int id)
        {
            return await _context.XuatKhos.FindAsync(id);
        }

        public async Task AddAsync(XuatKho xuatKho)
        {
            // Kiểm tra số phiếu đã tồn tại
            var existing = await _context.XuatKhos
                .FirstOrDefaultAsync(x => x.So_Phieu_Xuat_Kho == xuatKho.So_Phieu_Xuat_Kho);

            if (existing != null)
            {
                throw new InvalidOperationException("Số phiếu xuất đã tồn tại");
            }

            _context.XuatKhos.Add(xuatKho);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(XuatKho xuatKho)
        {
            _context.XuatKhos.Update(xuatKho);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(XuatKho xuatKho)
        {
            var phieu = await _context.XuatKhos.FindAsync(xuatKho.ID);
            if (phieu != null)
            {
                // Xóa chi tiết trước (nếu có)
                var chiTietList = await _context.XuatKhoRaws
                    .Where(x => x.Xuat_Kho_ID == phieu.ID)
                    .ToListAsync();

                if (chiTietList.Any())
                {
                    _context.XuatKhoRaws.RemoveRange(chiTietList);
                }

                _context.XuatKhos.Remove(phieu);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<XuatKho>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllAsync();

            return await _context.XuatKhos
                .Where(x => x.So_Phieu_Xuat_Kho.Contains(keyword) ||
                           (x.Ghi_Chu != null && x.Ghi_Chu.Contains(keyword)))
                .OrderByDescending(x => x.Ngay_Xuat_Kho)
                .ToListAsync();
        }
    }
}
