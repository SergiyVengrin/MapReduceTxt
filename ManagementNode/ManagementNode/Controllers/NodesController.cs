using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using ManagementNode.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementNode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly IFileInfoService _fileInfoService;
        private readonly IManagementService _managementService;
        private readonly IMapper _mapper;

        public NodesController(IFileInfoService fileInfoService, IManagementService managementService, IMapper mapper)
        {
            _fileInfoService = fileInfoService;
            _managementService = managementService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult ParseFile(FileDto file) // TEST ACTION
        {
            var files = _managementService.ParseFile(_mapper.Map<FileModel>(file));

            return Ok(files);
        }


        [HttpPost]
        public IActionResult AddFileInfo(FileInfoDto fileInfoDto)
        {
            _fileInfoService.Add(_mapper.Map<FileInfoModel>(fileInfoDto));

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileInfo(int id)
        {
            try
            {
                var nodeInfo = await _fileInfoService.Get(id);
                return Ok(_mapper.Map<FileInfoDto>(await _fileInfoService.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
