using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using AutoMapper;

namespace BLL.Services.Implementation
{
    public sealed class FileInfoService : IFileInfoService
    {
        private readonly IFileInfoRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileInfoService(IFileInfoRepository fileInfoRepository, IMapper mapper)
        {
            _fileRepository = fileInfoRepository;
            _mapper = mapper;
        }


        public async Task Add(FileInfoModel nodeInfo)
        {
            await _fileRepository.Add(_mapper.Map<DAL.Entities.FileInfo>(nodeInfo));
        }

        public async Task Delete(FileInfoModel nodeInfo)
        {
            await _fileRepository.Delete(_mapper.Map<DAL.Entities.FileInfo>(nodeInfo));
        }

        public async Task<FileInfoModel> Get(int id)
        {
            var nodeInfo = await _fileRepository.Get(id);
            if(nodeInfo is null)
            {
                throw new Exception("NodeInfo is null");
            }

            return _mapper.Map<Models.FileInfoModel>(nodeInfo);
        }
    }
}
