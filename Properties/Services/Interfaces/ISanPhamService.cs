using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface ISanPhamService
    {
        Task<List<SanPham>> GetAllAsync();
        Task<SanPham?> GetByIdAsync(int id);
        Task AddAsync(SanPham sp);
        Task DeleteAsync(int id);
        Task UpdateAsync(SanPham sp);
        Task<List<SanPham>> Search(string keyword);

        Task<List<SanPham>> FillterAsync(int? dvtId, int? lspId);

    }
}
