using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IFileInfoRepository
    {
        Task Add(Entities.FileInfo nodeInfo);
        Task Delete(Entities.FileInfo nodeInfo);
        Task<Entities.FileInfo> Get(int id);
    }
}
