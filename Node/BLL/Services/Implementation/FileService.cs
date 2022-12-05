using BLL.Models;
using BLL.POCOs;
using BLL.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace BLL.Services.Implementation
{
    public sealed class FileService : IFileService
    {
        private readonly IOptions<NodeConfig> _options;

        public FileService(IOptions<NodeConfig> options)
        {
            _options = options;
        }


        public async Task SaveFiles(List<FileModel> files)
        {
            try
            {
                foreach (var file in files)
                {
                    string path = _options.Value.FilePath + "\\" + file.Port;
                    Directory.CreateDirectory(path);
                    path += "\\" + file.Name + "_" + file.Version + ".txt";

                    using (StreamWriter sw = File.CreateText(path))
                    {
                        await sw.WriteAsync(file.Text);
                    }
                }
            }
            catch { throw; }
        }
    }
}
