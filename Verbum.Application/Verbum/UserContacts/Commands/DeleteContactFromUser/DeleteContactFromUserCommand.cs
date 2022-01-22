using MediatR;
    
namespace Verbum.Application.Verbum.UserContacts.Commands.DeleteContactFromUser
{
    public class DeleteContactFromUserCommand :IRequest
    {
        public Guid contactId { get; set; }
      
    }
}
