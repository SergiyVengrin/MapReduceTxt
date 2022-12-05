using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IManagementService
    {
        Task SendFileToNodes(FileModel file);
    }
}
