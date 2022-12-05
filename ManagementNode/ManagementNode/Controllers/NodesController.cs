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
        public async Task<IActionResult> SaveFile(FileDto file)
        {
            try
            {
                await _managementService.SendFileToNodes(_mapper.Map<FileModel>(file));
                return Ok();
            }
            catch (Exception ex)    
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult AddFileInfo(FileInfoDto fileInfoDto)
        {
            try
            {
                _fileInfoService.Add(_mapper.Map<FileInfoModel>(fileInfoDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileInfo(int id)
        {
            try
            {
                return Ok(_mapper.Map<FileInfoDto>(await _fileInfoService.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
