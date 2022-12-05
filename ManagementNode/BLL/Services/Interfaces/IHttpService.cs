using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IHttpService
    {
        Task SendAsync(List<FileModel> files, string port);
    }
}
