using HtmlAgilityPack;
using Verbum.Application.Common.Exceptions;

namespace Verbum.Application.Verbum.Repositories
{
    public class OpenGraphRepository
    {
        public OpenGraphDto OpenGraphScrap(string url) {
            Uri uri = new Uri(url);
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(uri);
            string titleField, descField, imageField, urlField, siteField;
           

            var title = htmlDoc.DocumentNode.SelectSingleNode("//head/meta[@property='og:title']");
            if (title != null)
            {
                titleField = title.Attributes["content"].Value;
            }
            else {
                titleField = "";
            }

            var description = htmlDoc.DocumentNode.SelectSingleNode("//head/meta[@property='og:description']");
            if (description != null) {
                descField = description.Attributes["content"].Value;
            }
            else {
                descField = "";
            }

            var image = htmlDoc.DocumentNode.SelectSingleNode("//head/meta[@property='og:image']");
            if (image != null)
            {
                imageField = image.Attributes["content"].Value;
            }
            else {
                imageField = "";
            }

            var urlTag = htmlDoc.DocumentNode.SelectSingleNode("//head/meta[@property='og:url']");
            if (urlTag != null)
            {
                urlField = urlTag.Attributes["content"].Value;
            }
            else {
                urlField = ""; 
            }

            var site = htmlDoc.DocumentNode.SelectSingleNode("//head/meta[@property='og:site_name']");
            if (site != null)
            {
                siteField = site.Attributes["content"].Value;
            }
            else {
                siteField = "";
            }
                   

                var openGraphInfo = new OpenGraphDto
                {
                    title = titleField,
                    description = descField,
                    image = imageField,
                    urlTag = urlField,
                    site = siteField
                };

                return openGraphInfo;
           
        }
    }


    public class OpenGraphDto { 
        public string? title { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public string? urlTag { get; set; }
        public string? site { get; set; }
    }
}
