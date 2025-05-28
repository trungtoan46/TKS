using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface IXNKNhapKhoService
    {
        Task<List<XNK_Nhap_Kho>> GetAllAsync();
        Task<XNK_Nhap_Kho?> GetByIdAsync(string soPhieu);
        Task AddAsync(XNK_Nhap_Kho phieuNhap);
        Task UpdateAsync(XNK_Nhap_Kho phieuNhap);
        Task DeleteAsync(string soPhieu);
        Task<List<XNK_Nhap_Kho>> SearchAsync(string keyword);
    }
} 