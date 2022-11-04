using BLL.Models;
using BLL.Services.Interfaces;
using System.Text;

namespace BLL.Services.Implementation
{
    public sealed class ManagementService : IManagementService
    {
        private const int MAX_FILE_SIZE = 5;
        private string[] ports = new string[] { "7139", "7140", "7141", "7142", "7143" };


        public List<FileModel> ParseFile(FileModel file)
        {
            List<FileModel> files = new List<FileModel>();
            int startIndex = 0;
            int endIndex = MAX_FILE_SIZE;


            if (file.Text.Length <= MAX_FILE_SIZE)
            {
                endIndex = file.Text.Length;

                files.Add(new FileModel
                {
                    Name = file.Name + "_" + ports[0],
                    Text = file.Text[startIndex..endIndex]
                });

                return files;
            }


            for (int i = 0; i < file.Text.Length / MAX_FILE_SIZE+1; i++)
            {
                files.Add(new FileModel
                {
                    Name = file.Name + "_" + ports[i],
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
