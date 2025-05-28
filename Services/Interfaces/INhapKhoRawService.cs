using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface INhapKhoRawService
    {
        Task<List<NhapKhoRaw>> GetByPhieuIdAsync(int nhapKhoId);
        Task<NhapKhoRaw?> GetByIdAsync(int id);
        Task AddAsync(NhapKhoRaw chiTiet);
        Task UpdateAsync(NhapKhoRaw chiTiet);
        Task DeleteAsync(int id);
        Task<bool> ExistsByProductAsync(int nhapKhoId, int sanPhamId);
    }
} 