using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface IDonViTinhService
    {
        Task<List<DonViTinh>> GetAllAsync();
        Task<DonViTinh?> GetByIdAsync(int id);
        Task AddAsync(DonViTinh dvt);
        Task UpdateAsync(DonViTinh dvt);
        Task DeleteAsync(int id);
    }
}
