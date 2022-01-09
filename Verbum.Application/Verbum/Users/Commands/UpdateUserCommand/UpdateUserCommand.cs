using MediatR;
using Microsoft.AspNetCore.Http;

namespace Verbum.Application.Verbum.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommand :IRequest
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       
        public IFormFile? formFile { get; set; } 

    }
}
