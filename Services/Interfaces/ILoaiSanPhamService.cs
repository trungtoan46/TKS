using TKS.Models;

namespace TKS.Services.Interfaces.Lsp
{
    public interface ILoaiSanPhamService
    {
        Task<List<LoaiSanPham>> GetAllAsync();
        Task<LoaiSanPham?> GetByIdAsync(int id);

        Task<List<LoaiSanPham>> SearchAsync(string keyword);


        Task AddAsync(LoaiSanPham lsp);
        Task UpdateAsync(LoaiSanPham lsp);
        Task DeleteAsync(int id);



    }
}
