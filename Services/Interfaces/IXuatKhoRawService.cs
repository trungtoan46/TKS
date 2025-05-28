using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface IXuatKhoRawService
    {
        Task<List<XuatKhoRaw>> GetByPhieuIdAsync(int xuatKhoId);
        Task<XuatKhoRaw?> GetByIdAsync(int id);
        Task AddAsync(XuatKhoRaw chiTiet);
        Task UpdateAsync(XuatKhoRaw chiTiet);
        Task DeleteAsync(int id);
        Task<bool> ExistsByProductAsync(int xuatKhoId, int sanPhamId);
    }
} 