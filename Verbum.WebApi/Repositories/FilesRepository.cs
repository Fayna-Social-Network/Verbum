namespace Verbum.WebApi.Repositories
{
    public class FilesRepository
    {
        public async Task<string> UploadAvatar(IFormFile file)
        {
            var folderName = Path.Combine("Resources", "Avatars");
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
                return dbPath;
            }
            throw new Exception();
        }
    }
}

