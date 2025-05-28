using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface INhapKhoService 
    {
        public Task<List<NhapKho>> GetAllAsync();
        public Task<NhapKho?> GetByIdAsync(int id);
        public Task AddAsync (NhapKho nhapKho);
        public Task UpdateAsync(NhapKho nhapKho);
        public Task RemoveAsync(NhapKho nhapKho);
        public Task<List<NhapKho>> SearchAsync(string keyword);
    }
}
