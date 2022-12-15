using Microsoft.AspNetCore.Http;
using System.IO.Compression;

namespace Verbum.Application.Verbum.Repositories
{
    public class FilesRepository
    {
        public async Task<string> Upload(IFormFile file, string type, Guid UserId) {
            
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
                return dbPath;
            }
            throw new Exception();
        }

        public async Task<string> ToArchive(IFormFileCollection uploads, Guid UserId) {
           
            var folder = Path.Combine("Resources", UserId.ToString());
            var folderName = Path.Combine(folder, "user_files");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!System.IO.Directory.Exists(pathToSave))//create path 
            {
                Directory.CreateDirectory(pathToSave);
            }

            var fileName = Path.GetRandomFileName() + ".zip";
            var dbPath = Path.Combine(folderName, fileName);
            var fullPath = Path.Combine(pathToSave, fileName);

            using (FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                using (var zipArchive = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {
                    foreach (var file in uploads)
                    {
                        var entry = zipArchive.CreateEntry(file.FileName, CompressionLevel.Fastest);
                        
                        using (var entryStream = entry.Open())
                        {
                            file.CopyTo(entryStream);
                        }
                    }
                }
            }


            //foreach (var uploadedFile in uploads)
            //{
            //    var fileName = Path.GetRandomFileName() + uploadedFile.FileName;
            //    var dbPath = Path.Combine(folderName, fileName);
            //    var fullPath = Path.Combine(pathToSave, fileName);



            //    using (var stream = System.IO.File.Create(fullPath))
            //    {
            //        await uploadedFile.CopyToAsync(stream);
            //    }
            //    files.Add(dbPath);
            //}


            return "djh";
        }

        public string Delete(string Dbpath) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), Dbpath);
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                return fileInf.FullName;
            }
            return "File not found";
        }

        public string GetFileName(string type, IFormFile file)
        {
            var fileName = Path.GetRandomFileName() + file.FileName;
            if (type == "audiomessage")
            {
                return fileName + ".wav";
            }
            return fileName;
        }

        public async Task<string> UploadSticker(IFormFile stickerFile, string groupName) 
        {
            var folder = Path.Combine("Resources", "stickers");
            var folderName = Path.Combine(folder, groupName);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = GetFileName(groupName, stickerFile);
            var dbPath = Path.Combine(folderName, fileName);
            var fullPath = Path.Combine(pathToSave, fileName);

            if (!System.IO.Directory.Exists(pathToSave))//create path 
            {
                Directory.CreateDirectory(pathToSave);
            }


            if (stickerFile != null)
            {

                using (var stream = System.IO.File.Create(fullPath))
                {
                    await stickerFile.CopyToAsync(stream);
                }
                return dbPath;
            }
            throw new Exception();
        } 
    }
}
