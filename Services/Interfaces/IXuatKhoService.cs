using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface IXuatKhoService
    {
        Task<List<XuatKho>> GetAllAsync();
        Task<XuatKho?> GetByIdAsync(int id);
        Task AddAsync(XuatKho xuatKho);
        Task UpdateAsync(XuatKho xuatKho);
        Task RemoveAsync(XuatKho xuatKho);
        Task<List<XuatKho>> SearchAsync(string keyword);
    }
}
