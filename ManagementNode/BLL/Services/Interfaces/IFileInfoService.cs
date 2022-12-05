using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IFileInfoService
    {
        Task Add(FileInfoModel nodeInfo);
        Task Delete(FileInfoModel nodeInfo);
        Task<FileInfoModel> Get(int id);
    }
}
