using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Verbum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiVersionNeutral]
    [ApiController]
    public class UploadFilesController : BaseController
    {
        [Authorize]
        [HttpPost("image")]
        public async Task<ActionResult<string>> UploadImage(IFormFile file)
        {
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = Path.GetRandomFileName() + file.FileName;
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
    }
}
