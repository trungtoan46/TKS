using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services
{
    public class NhapKhoService : INhapKhoService
    {
        private readonly AppDbContext _context;

        public NhapKhoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NhapKho>> GetAllAsync()
        {
            return await _context.NhapKhos
                .OrderByDescending(x => x.Ngay_Nhap_Kho)
                .ToListAsync();
        }

        public async Task<NhapKho?> GetByIdAsync(int id)
        {
            return await _context.NhapKhos.FindAsync(id);
        }

        public async Task AddAsync(NhapKho nhapKho)
        {
            // Kiểm tra số phiếu đã tồn tại
            var existing = await _context.NhapKhos
                .FirstOrDefaultAsync(x => x.So_Phieu_Nhap_Kho == nhapKho.So_Phieu_Nhap_Kho);

            if (existing != null)
            {
                throw new InvalidOperationException("Số phiếu nhập đã tồn tại");
            }

            _context.NhapKhos.Add(nhapKho);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NhapKho nhapKho)
        {
            _context.NhapKhos.Update(nhapKho);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(NhapKho nhapKho)
        {
            var phieu = await _context.NhapKhos.FindAsync(nhapKho.Id);
            if (phieu != null)
            {
                // Xóa chi tiết trước (nếu có)
                var chiTietList = await _context.NhapKhoRaws
                    .Where(x => x.Nhap_Kho_ID == phieu.Id)
                    .ToListAsync();

                if (chiTietList.Any())
                {
                    _context.NhapKhoRaws.RemoveRange(chiTietList);
                }

                _context.NhapKhos.Remove(phieu);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NhapKho>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllAsync();

            return await _context.NhapKhos
                .Where(x => x.So_Phieu_Nhap_Kho.Contains(keyword) ||
                           (x.Ghi_Chu != null && x.Ghi_Chu.Contains(keyword)))
                .OrderByDescending(x => x.Ngay_Nhap_Kho)
                .ToListAsync();
        }

        Task<List<NhapKho>> INhapKhoService.SearchAsync(string keyword)
        {
            return _context.NhapKhos
                .Where(sp => sp.NCC_ID.ToString().Contains(keyword) || sp.Kho_ID.ToString().Contains(keyword)
                            || sp.So_Phieu_Nhap_Kho.Contains(keyword))
                .AsNoTracking().ToListAsync();
        }
    }
}
