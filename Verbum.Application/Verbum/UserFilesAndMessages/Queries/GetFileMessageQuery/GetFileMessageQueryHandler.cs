﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.UserFilesAndMessages.Queries.GetFileMessageQuery
{
    public class GetFileMessageQueryHandler :IRequestHandler<GetFileMessageQuery, FileMessageVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFileMessageQueryHandler(IVerbumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FileMessageVm> Handle(GetFileMessageQuery request, CancellationToken cancellationToken) {
            
            var query = await _dbContext.fileMessages.SingleAsync(f => f.MessageId == request.MessageId);

            if (query == null)
            {
                throw new NotFoundException(nameof(FileMessage), request.MessageId);
            }

            return _mapper.Map<FileMessageVm>(query);

        }  
    }
}
