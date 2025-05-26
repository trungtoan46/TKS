using TKS.Models;

namespace TKS.Services.Interfaces
{
    public interface INhapKhoService 
    {
        public Task<List<NhapKho>> GetAllAsync();
        
        public Task AddAsync (NhapKho nhapKho);
        public Task RemoveAsync (NhapKho nhapKho);
    }
}
