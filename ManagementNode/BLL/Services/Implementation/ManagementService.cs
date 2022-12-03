using BLL.Models;
using BLL.POCOs;
using BLL.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace BLL.Services.Implementation
{
    public sealed class ManagementService : IManagementService
    {
        private readonly IFileInfoService _fileInfoService;
        private readonly IOptions<NodeConfig> _config;
        private readonly IReadOnlyList<string> _ports;

        private List<FileModel> _files = new List<FileModel>();


        public ManagementService(IOptions<NodeConfig> config, IFileInfoService fileInfoService)
        {
            _config = config;
            _ports = _config.Value.Ports;
            _fileInfoService = fileInfoService;
        }


        public List<FileModel> ParseFile(FileModel file)
        {
            int startIndex = 0;
            int endIndex = _config.Value.MaxFileSize;

            if (file.Text.Length <= _config.Value.MaxFileSize)
            {
                endIndex = file.Text.Length;

                _files.Add(new FileModel
                {
                    Port = _ports[0],
                    Name = file.Name + "_" + _ports[0] + "_" + (GetPortsCount(_ports[0]) + 1),
                    Text = file.Text[startIndex..endIndex]
                });

                return _files;
            }

            for (int i = 0; i < file.Text.Length / _config.Value.MaxFileSize + 1; i++)
            {
                _files.Add(new FileModel
                {
                    Port = _ports[i%5],
                    Name = file.Name + "_" + _ports[i % 5] + "_" + (GetPortsCount(_ports[i % 5]) + 1),
                    Text = file.Text[startIndex..endIndex],
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


        public void SendFilesToNodes(List<FileModel> files)
        {
            throw new NotImplementedException();
        }


        private int GetPortsCount(string port)
        {
            return _files.Count(x => x.Port == port);
        }
    }
}
