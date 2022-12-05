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
            try
            {
                await _fileRepository.Add(_mapper.Map<DAL.Entities.FileInfo>(nodeInfo));
            }
            catch { throw; }
        }

        public async Task Delete(FileInfoModel nodeInfo)
        {
            try
            {
                await _fileRepository.Delete(_mapper.Map<DAL.Entities.FileInfo>(nodeInfo));
            }
            catch { throw; }
        }

        public async Task<FileInfoModel> Get(int id)
        {
            try
            {
                var nodeInfo = await _fileRepository.Get(id);
                return _mapper.Map<Models.FileInfoModel>(nodeInfo);
            }
            catch { throw; }
        }


    }
}
