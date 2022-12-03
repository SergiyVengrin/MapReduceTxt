using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IFileService
    {
        Task SaveFiles(List<FileModel> files);
    }
}
