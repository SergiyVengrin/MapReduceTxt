using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IManagementService
    {
        void SendFilesToNodes(List<FileModel> files);
        List<FileModel> ParseFile(FileModel file);
    }
}
