using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verbum.Application.Verbum.Repositories;
using Verbum.WebApi.Models.common;

namespace Verbum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class CommonController : BaseController
    {
        private readonly OpenGraphRepository _OpenGraphrepository;

        public CommonController(OpenGraphRepository openGraphRepository) => _OpenGraphrepository = openGraphRepository;

        [Authorize]
        [HttpPost("openGraphScrap")]
        public OpenGraphDto getOpenGraphInfo(UrlString Url) {
            return  _OpenGraphrepository.OpenGraphScrap(Url.Url!);
        }
    }
}
