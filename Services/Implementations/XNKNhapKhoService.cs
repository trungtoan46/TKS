using Microsoft.EntityFrameworkCore;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services.Implementations
{
    public class XNKNhapKhoService : IXNKNhapKhoService
    {
        private readonly AppDbContext _context;

        public XNKNhapKhoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<XNK_Nhap_Kho>> GetAllAsync()
        {
            return await _context.XNK_Nhap_Khos.OrderByDescending(x => x.Ngay_Nhap_Kho).ToListAsync();
        }

        public async Task<XNK_Nhap_Kho?> GetByIdAsync(string soPhieu)
        {
            return await _context.XNK_Nhap_Khos.FindAsync(soPhieu);
        }

        public async Task AddAsync(XNK_Nhap_Kho phieuNhap)
        {
            _context.XNK_Nhap_Khos.Add(phieuNhap);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(XNK_Nhap_Kho phieuNhap)
        {
            _context.XNK_Nhap_Khos.Update(phieuNhap);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string soPhieu)
        {
            var phieuNhap = await _context.XNK_Nhap_Khos.FindAsync(soPhieu);
            if (phieuNhap != null)
            {
                _context.XNK_Nhap_Khos.Remove(phieuNhap);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<XNK_Nhap_Kho>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllAsync();

            return await _context.XNK_Nhap_Khos
                .Where(x => x.So_Phieu_Nhap_Kho.Contains(keyword) ||
                           x.NCC.Contains(keyword) ||
                           x.Kho.Contains(keyword))
                .OrderByDescending(x => x.Ngay_Nhap_Kho)
                .ToListAsync();
        }
    }
} 