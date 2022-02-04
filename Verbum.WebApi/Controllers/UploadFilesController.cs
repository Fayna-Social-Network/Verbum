using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Verbum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiVersionNeutral]
    [ApiController]
    public class UploadFilesController : BaseController
    {
        [Authorize]
        [HttpPost("{type}")]
        public async Task<ActionResult<string>> UploadFile(IFormFile file, string type)
        {
           
            var folder = Path.Combine("Resources", UserId.ToString());
            var folderName = Path.Combine(folder, type);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = GetFileName(type, file);
            var dbPath = Path.Combine(folderName, fileName);
            var fullPath = Path.Combine(pathToSave, fileName);

            if (!System.IO.Directory.Exists(pathToSave))//create path 
            {
                Directory.CreateDirectory(pathToSave);
            }

           
            if (file != null)
            {

                using (var stream = System.IO.File.Create(fullPath))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok(dbPath);  
            }
            throw new Exception();
        }


        [Authorize]
        [HttpPost("many/{type}")]
        public async Task<ActionResult<List<string>>> AddFiles(IFormFileCollection uploads, string type)
        {
            List<string> files = new List<string>();       

            var folder = Path.Combine("Resources", UserId.ToString());
            var folderName = Path.Combine(folder, type);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            foreach (var uploadedFile in uploads)
            {
                var fileName = Path.GetRandomFileName() + uploadedFile.FileName;
                var dbPath = Path.Combine(folderName, fileName);
                var fullPath = Path.Combine(pathToSave, fileName);

                
               
                using (var stream = System.IO.File.Create(fullPath))
                {
                    await uploadedFile.CopyToAsync(stream);
                }
                files.Add(dbPath);
            }
            

            return Ok(files);
        }


        [Authorize]
        [HttpDelete("{fileDbPath}")]
        public ActionResult DeleteFile(string fileDbPath) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileDbPath);
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                return Ok(fileInf.FullName);
            }

            return BadRequest(fileDbPath);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetFileName(string type, IFormFile file) {
            var fileName = Path.GetRandomFileName() + file.FileName;
            if (type == "audiomessage")
            {
                return fileName + ".wav";
            }
            return fileName;
        }

    }
}
