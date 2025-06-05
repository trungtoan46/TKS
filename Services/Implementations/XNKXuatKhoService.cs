using Microsoft.EntityFrameworkCore;
using TKS.Components.Pages;
using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services.Implementations
{
    public class XNKXuatKhoService : IXNKXuatKho
    {
        private readonly AppDbContext _context;

        public XNKXuatKhoService (AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(XNK_Xuat_Kho phieuXuat)
        {
            _context.xNK_Xuat_Khos.Add(phieuXuat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string soPhieu)
        {
            var item = await _context.xNK_Xuat_Khos.FindAsync(soPhieu);
            _context.xNK_Xuat_Khos.Remove(item);
            await _context.SaveChangesAsync();
        }

        public Task<List<XNK_Xuat_Kho>> GetAllAsync()
        {
            return _context.xNK_Xuat_Khos.ToListAsync();
        }

        public async Task<XNK_Xuat_Kho?> GetByIdAsync(string soPhieu)
        {
            return await _context.xNK_Xuat_Khos.FindAsync(soPhieu);
        }

        public async Task UpdateAsync(XNK_Xuat_Kho phieuXuat)
        {
            _context.xNK_Xuat_Khos.Update(phieuXuat);
            await _context.SaveChangesAsync();
        }
    }
}
