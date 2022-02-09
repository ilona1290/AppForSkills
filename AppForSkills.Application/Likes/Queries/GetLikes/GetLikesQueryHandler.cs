using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Exceptions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Application.Likes.Queries.GetLikes
{
    public class GetLikesQueryHandler : IRequestHandler<GetLikesQuery, LikesVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetLikesQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LikesVm> Handle(GetLikesQuery request, CancellationToken cancellationToken)
        {
            if(request.CommentId != null)
            {
                var likes = _context.Likes.Where(l => l.CommentId == request.CommentId);
                var likesDtos = await likes.ProjectTo<LikeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                var likesVm = new LikesVm
                {
                    Likes = likesDtos
                };
                return likesVm;
            }
            else if(request.DiscussionId != null)
            {
                var likes = _context.Likes.Where(l => l.DiscussionId == request.DiscussionId);
                var likesDtos = await likes.ProjectTo<LikeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                var likesVm = new LikesVm
                {
                    Likes = likesDtos
                };
                return likesVm;
            }
            else if(request.PostInDiscussionId != null)
            {
                var likes = _context.Likes.Where(l => l.PostInDiscussionId == request.PostInDiscussionId);
                var likesDtos = await likes.ProjectTo<LikeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                var likesVm = new LikesVm
                {
                    Likes = likesDtos
                };
                return likesVm;
            }
            else
            {
                throw new WrongIDException("You gaved wrong Id, give another Id.");
            }
        }
    }
}

