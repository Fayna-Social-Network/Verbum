using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.Repositories;

namespace Verbum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiVersionNeutral]
    [ApiController]
    public class UploadFilesController : BaseController
    {
        private readonly FilesRepository _filesRepository;

        public UploadFilesController(FilesRepository filesRepository) => _filesRepository = filesRepository;

        [Authorize]
        [HttpPost("{type}")]
        public async Task<ActionResult<string>> UploadFile(IFormFile file, string type)
        {
            var path = await _filesRepository.Upload(file, type, UserId);

          return Ok(path);
        }


        [Authorize]
        [HttpPost("many/{type}")]
        [RequestSizeLimit(900_000_000)]
        public async Task<ActionResult<List<string>>> AddFiles(IFormFileCollection uploads, string type)
        {
            var files = await _filesRepository.Uploads(uploads, type, UserId);

            return Ok(files);
        }


        [Authorize]
        [HttpDelete("{fileDbPath}")]
        public ActionResult DeleteFile(string fileDbPath) {
            
            var result = _filesRepository.Delete(fileDbPath);

            return Ok(result);
        }

       
       

    }
}
