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
        [HttpPost("archive")]
        [RequestSizeLimit(900_000_000)]
        public async Task<ActionResult<string>> UploadFilesAndAddToArchive()
        {
            var files = this.Request.Form.Files;
            var archiveFilePath = await _filesRepository.ToArchive(files, UserId);

            return Ok(archiveFilePath);
        }


        [Authorize]
        [HttpDelete("{fileDbPath}")]
        public ActionResult DeleteFile(string fileDbPath) {
            
            var result = _filesRepository.Delete(fileDbPath);

            return Ok(result);
        }

        [HttpPost("sticker/{groupName}")]
        public async Task<ActionResult<string>> UploadSticker(IFormFile stickerFile, string groupName) 
        {
            var path = await _filesRepository.UploadSticker(stickerFile, groupName);

            return Ok(path);
        }

        //[HttpPost("quasarUpload")]
        //public async Task<ActionResult> QuasarFilesUpload() 
        //{
        //   var files = this.Request.Form.Files;
        //   foreach (var file in files)
        //   {
        //      if (file == null || file.Length == 0)
        //         continue;
              
        //        var fileName = file.FileName;
        //        var fileSize = file.Length;
                    
        //   }
        //    return Ok();
        //}

    }
}
