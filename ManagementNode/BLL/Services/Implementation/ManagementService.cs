using BLL.Models;
using BLL.POCOs;
using BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;

namespace BLL.Services.Implementation
{
    public sealed class ManagementService : IManagementService
    {
        private readonly IOptions<NodeConfig> _config;
        private readonly IReadOnlyList<string> _ports = new List<string>() { "7139", "7140", "7141", "7142", "7143" };


        public ManagementService(IOptions<NodeConfig> config)
        {
            _config = config;
        }


        public List<FileModel> ParseFile(FileModel file)
        {
            List<FileModel> files = new List<FileModel>();
            int startIndex = 0;
            int endIndex = _config.Value.MaxFileSize;


            if (file.Text.Length <= MAX_FILE_SIZE)
            {
                endIndex = file.Text.Length;

                files.Add(new FileModel
                {
                    Name = file.Name + "_" + _ports[0],
                    Text = file.Text[startIndex..endIndex]
                });

                return files;
            }


            for (int i = 0; i < file.Text.Length / MAX_FILE_SIZE+1; i++)
            {
                files.Add(new FileModel
                {
                    Name = file.Name + "_" + _ports[i],
                    Text = file.Text[startIndex..endIndex],
                });

                if (endIndex + MAX_FILE_SIZE <= file.Text.Length)
                {
                    startIndex = endIndex;
                    endIndex += MAX_FILE_SIZE;
                }
                else
                {
                    startIndex = endIndex;
                    endIndex = file.Text.Length;
                }
            }

            return files;
        }

        public void SendFilesToNodes(List<FileModel> files)
        {
            throw new NotImplementedException();
        }
    }
}
