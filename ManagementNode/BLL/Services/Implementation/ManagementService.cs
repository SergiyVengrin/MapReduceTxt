using BLL.Models;
using BLL.POCOs;
using BLL.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace BLL.Services.Implementation
{
    public sealed class ManagementService : IManagementService
    {
        private readonly IFileInfoService _fileInfoService;
        private readonly IHttpService _httpService;

        private readonly IOptions<NodeConfig> _config;
        private readonly IReadOnlyList<string> _ports;


        public ManagementService(IOptions<NodeConfig> config, IFileInfoService fileInfoService, IHttpService httpService)
        {
            _config = config;
            _ports = _config.Value.Ports;
            _fileInfoService = fileInfoService;
            _httpService = httpService; 
        }


        public async Task SendFileToNodes(FileModel file)
        {
            try
            {
                var files = DivideFile(file);

                foreach (var p in _ports)
                {
                    await _httpService.SendAsync(files.Where(x => x.Port == p).ToList(), p);
                }
            }
            catch { throw; }
        }


        private List<FileModel> DivideFile(FileModel file)
        {
            List<FileModel> _files = new List<FileModel>();

            int startIndex = 0;
            int endIndex = _config.Value.MaxFileSize;

            if (file.Text.Length <= _config.Value.MaxFileSize)
            {
                endIndex = file.Text.Length;

                _files.Add(new FileModel
                {
                    Port = _ports[0],
                    Name = file.Name,
                    Text = file.Text[startIndex..endIndex],
                    Version = (GetPortsCount(_files, _ports[0]) + 1)
                });

                return _files;
            }

            for (int i = 0; i < file.Text.Length / _config.Value.MaxFileSize + 1; i++)
            {
                _files.Add(new FileModel
                {
                    Port = _ports[i % 5],
                    Name = file.Name,
                    Text = file.Text[startIndex..endIndex],
                    Version = (GetPortsCount(_files, _ports[i % 5]) + 1)
                });

                if (endIndex + _config.Value.MaxFileSize <= file.Text.Length)
                {
                    startIndex = endIndex;
                    endIndex += _config.Value.MaxFileSize;
                }
                else
                {
                    startIndex = endIndex;
                    endIndex = file.Text.Length;
                }
            }

            return _files;
        }


        private int GetPortsCount(List<FileModel> files, string port)
        {
            return files.Count(x => x.Port == port);
        }
    }
}
