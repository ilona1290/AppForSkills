using AppForSkills.Application.Common.Interfaces;
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

namespace AppForSkills.Application.Discussions.Queries.GetDiscussion
{
    public class GetDiscussionQueryHandler : IRequestHandler<GetDiscussionQuery, DiscussionVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetDiscussionQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DiscussionVm> Handle(GetDiscussionQuery request, CancellationToken cancellationToken)
        {
            var discussion = await _context.Discussions.Where(d => d.Id == request.DiscussionId).FirstOrDefaultAsync(cancellationToken);
            var posts = _context.PostsInDiscussion.Where(d => d.DiscussionId == request.DiscussionId);

            var discussionVm = _mapper.Map<DiscussionVm>(discussion);
            var postDtos = await posts.ProjectTo<PostInDiscussionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            int index;
            int length = postDtos.Count;
            for (int i = length - 1; i > 0; i--)
            {
                if (postDtos[i].ParentPostId != null)
                {
                    index = (int)postDtos[i].ParentPostId - 1;
                    postDtos[index].AnswersToPost.Add(postDtos[i]);
                }
            }

            postDtos = postDtos.Where(p => p.ParentPostId == null).ToList();
            discussionVm.Posts = postDtos;
            return discussionVm;
        }
    }
}
