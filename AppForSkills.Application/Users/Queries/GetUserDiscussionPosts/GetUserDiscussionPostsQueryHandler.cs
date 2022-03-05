using AppForSkills.Application.Common.Interfaces;
using AppForSkills.Application.Discussions.Queries.GetDiscussion;
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

namespace AppForSkills.Application.Users.Queries.GetUserDiscussionPosts
{
    public class GetUserDiscussionPostsQueryHandler : IRequestHandler<GetUserDiscussionPostsQuery, UserDiscussionPostsVm>
    {
        private readonly IAppForSkillsDbContext _context;
        private readonly IMapper _mapper;
        public GetUserDiscussionPostsQueryHandler(IAppForSkillsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDiscussionPostsVm> Handle(GetUserDiscussionPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = _context.PostsInDiscussion.Where(c => c.StatusId == 1 && c.CreatedBy == request.Username).Include(r => r.Likes)
                .OrderByDescending(s => s.Created);

            var postsDtos = await posts.ProjectTo<UserDiscussionPostDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach (var post in postsDtos)
            {
                if (post.ParentPostId != null)
                {
                    var parentPost = await _context.PostsInDiscussion.Where(s => s.Id == post.ParentPostId)
                        .FirstOrDefaultAsync(cancellationToken);
                    var parentPostVm = _mapper.Map<PostInDiscussionDto>(parentPost);
                    post.ParentPost = parentPostVm;
                }
            }

            var postsVm = new UserDiscussionPostsVm
            {
                DiscussionPosts = postsDtos
            };

            return postsVm;
        }
    }
}
