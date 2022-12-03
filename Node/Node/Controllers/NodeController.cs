using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Node.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly IFileService _fileService;

        public NodeController(IFileService fileService)
        {
            _fileService = fileService;
        }


        [HttpPost]
        public async Task<IActionResult> SaveFiles(List<FileModel> files)
        {
            try
            {
                await _fileService.SaveFiles(files);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }
    }
}
