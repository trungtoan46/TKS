using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface IKhoService
    {
        Task<List<Kho>> GetAllAsync();
        Task<Kho?> GetByIdAsync(int id);
        Task AddAsync(Kho dvt);
        Task UpdateAsync(Kho dvt);
        Task DeleteAsync(int id);
    }
}
