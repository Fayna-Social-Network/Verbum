using AutoMapper;
using MediatR;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;

namespace Verbum.Application.Verbum.Message.Queries.GetCorrespondence
{
    public class GetCorrespondenceQueryHandler :IRequestHandler<GetCorrespondenceQuery, CorrespondenceVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCorrespondenceQueryHandler(IVerbumDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CorrespondenceVm> Handle(GetCorrespondenceQuery request, CancellationToken cancellationToken)
        {

            var toMe = await _dbContext.Messages
                .Where(m => m.UserId == request.Owner && m.Seller == request.WithWho)
                 .ProjectTo<CorrespondenceLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            var toYou = await _dbContext.Messages
                .Where(m => m.UserId == request.WithWho && m.Seller == request.Owner)
                 .ProjectTo<CorrespondenceLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var correspondence = toMe.Concat(toYou).OrderBy(m => m.Timestamp)
                               .ToList();

            return new CorrespondenceVm { Correspondences = correspondence };
        }
    }
}
