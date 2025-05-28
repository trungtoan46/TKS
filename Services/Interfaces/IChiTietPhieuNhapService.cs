using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface IChiTietPhieuNhapService
    {
        Task<List<ChiTietPhieuNhap>> GetByPhieuIdAsync(string soPhieu);
        Task AddAsync(ChiTietPhieuNhap chiTiet);
        Task UpdateAsync(ChiTietPhieuNhap chiTiet);
        Task DeleteAsync(int id);
        Task<ChiTietPhieuNhap?> GetByIdAsync(int id);
    }
} 