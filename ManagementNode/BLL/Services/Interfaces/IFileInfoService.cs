
using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IFileInfoService
    {
        Task Add(Models.FileInfoModel nodeInfo);
        Task Delete(Models.FileInfoModel nodeInfo);
        Task<Models.FileInfoModel> Get(int id);
    }
}
