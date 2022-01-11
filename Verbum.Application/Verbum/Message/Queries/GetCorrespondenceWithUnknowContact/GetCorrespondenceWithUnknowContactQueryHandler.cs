using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Verbum.Application.Verbum.Message.Queries.GetCorrespondence;

namespace Verbum.Application.Verbum.Message.Queries.GetCorrespondenceWithUnknowContact
{
    public class GetCorrespondenceWithUnknowContactQueryHandler : IRequestHandler<GetCorrespondenceWithUnknowContactQuery, CorrespondenceVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCorrespondenceWithUnknowContactQueryHandler(IVerbumDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);


        public async Task<CorrespondenceVm> Handle(GetCorrespondenceWithUnknowContactQuery request,
                    CancellationToken cancellationToken) {


            var userMessages = await _dbContext.Messages.Where(m => m.UserId == request.UserId)
                .ProjectTo<CorrespondenceLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            var userContacts = await _dbContext.UserContacts.Where(u => u.UserId == request.UserId).ToListAsync();

            foreach (var contact in userContacts) {
                userMessages.RemoveAll(m => m.Seller == contact.Contact);
            }

            return new CorrespondenceVm { Correspondences = userMessages };
        }

    }
}
