using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface IXNKXuatKho
    {
        Task<List<XNK_Xuat_Kho>> GetAllAsync();
        Task<XNK_Xuat_Kho?> GetByIdAsync(string soPhieu);
        Task AddAsync(XNK_Xuat_Kho phieuXuat);
        Task UpdateAsync(XNK_Xuat_Kho phieuXuat);
        Task DeleteAsync(string soPhieu);
    }
}
