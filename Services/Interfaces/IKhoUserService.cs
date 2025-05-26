using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface IKhoUserService
    {
        Task<List<KhoUser>> GetAllAsync();
        Task<KhoUser?> GetByIdAsync(int id);
        Task AddAsync(KhoUser KhoUserkho);
        Task UpdateAsync(KhoUser khoKhoUser);
        Task DeleteAsync(int id);
        Task<List<KhoUser>> SearchAsync(string keyword);
        Task<KhoUser?> LoginAsync(string maDangNhap, int khoId);
    }
}
