using TKS.Data;
using TKS.Models;
using TKS.Services.Interfaces;

namespace TKS.Services.Implementations
{
    public class XuatNhapKhoService : IXuatNhapKhoService
    {
        private readonly AppDbContext _context;
        public XuatNhapKhoService(AppDbContext context)
        {
            _context = context;
        }
        async Task IXuatNhapKhoService.Update(XNK_Nhap_Kho xNK_Nhap_Kho)
        {
            var existing = _context.NhapKhos
                .Where(x => x.So_Phieu_Nhap_Kho == xNK_Nhap_Kho.So_Phieu_Nhap_Kho)
                .FirstOrDefault();

            if (existing != null)
            {
                throw new InvalidOperationException("");
            }
            _context.XNK_Nhap_Khos.Update(xNK_Nhap_Kho);
            await _context.SaveChangesAsync();
        }
    }
}
