using Fayna.AdminPanel.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text.Json;

namespace Fayna.AdminPanel.UploadSticker
{
    internal class Upload
    {
        public async Task<Sticker> UploadStickerFile(string filePath, Guid Id, string Name, string uriString, Guid groupId) 
        {
            HttpClient _httpClient = new HttpClient();
            string responseContent;

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(Path));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File [{filePath}] not found.");
            }

            using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    using (var fs = File.OpenRead(filePath))
                    {
                        using (var streamContent = new StreamContent(fs))
                        {
                            using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                            {
                                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                                // "file" parameter name should be the same as the server side input parameter name
                                form.Add(fileContent, "stickerFile", Path.GetFileName(filePath));
                                HttpResponseMessage response = await httpClient.PostAsync(uriString, form);
                                response.EnsureSuccessStatusCode();
                                responseContent = await response.Content.ReadAsStringAsync();
         
                            }
                        }
                    }
                }
            }

           

            var sticker = new Sticker
            {
                Id = Id,
                Name = Name,
                Path = responseContent,
                StickerGroupId = groupId,
            };

            return sticker;
        }
    }
}
