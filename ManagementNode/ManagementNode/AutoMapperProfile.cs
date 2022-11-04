using AutoMapper;
using BLL.Models;
using ManagementNode.Models;
using FileInfo = DAL.Entities.FileInfo;

namespace ManagementNode
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FileInfo, FileInfoModel>().ReverseMap();
            CreateMap<FileDto, FileModel>().ReverseMap();
            CreateMap<FileInfoModel, FileInfoDto>().ReverseMap();
        }
    }
}
