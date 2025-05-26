using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface INhaCungCapService
    {
        Task<List<NhaCungCap>> GetAllAsync();
        Task<NhaCungCap?> GetByIdAsync(int id);
        Task AddAsync(NhaCungCap ncc);
        Task DeleteAsync(int id);
        Task UpdateAsync(NhaCungCap ncc);
        Task<List<NhaCungCap>> Search(string keyword);
    }
}
