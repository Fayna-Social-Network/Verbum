using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Application.Common.Exceptions;
using Verbum.Domain;


#nullable disable
namespace Verbum.Application.Verbum.Users.Queries.GetCurrentUserQuery
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, CurrentUserVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCurrentUserQueryHandler(IVerbumDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CurrentUserVm> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken) {
            var query = await _dbContext.Users
                .Include(c => c.ContactGroups)
                .Include(st => st.stickersGroups)
                .Include(bl => bl.UserBlackLists)
                .Include(g => g.groups)
                .FirstOrDefaultAsync(u => u.NickName == request.NickName, cancellationToken);


            if (query == null) {
                throw new NotFoundException(nameof(VerbumUser), request.NickName);
            }

            foreach(var group in query.stickersGroups) {  
                var stickers = await _dbContext.Stickers.Where(s => s.StickerGroupId == group.Id)
                    .ToListAsync();

                group.Stickers = stickers;
              
            }

           
            return _mapper.Map<CurrentUserVm>(query);
        }
    }
}
