using AppForSkills.Application.Discussions.Commands.CreateDiscussion;
using AppForSkills.Application.Discussions.Commands.CreatePost;
using AppForSkills.Application.Discussions.Commands.DeleteDiscussion;
using AppForSkills.Application.Discussions.Commands.DeletePost;
using AppForSkills.Application.Discussions.Commands.EditDiscussion;
using AppForSkills.Application.Discussions.Commands.EditPost;
using AppForSkills.Application.Discussions.Commands.ReportPost;
using AppForSkills.Application.Discussions.GetDiscussions;
using AppForSkills.Application.Discussions.Queries.GetDiscussion;
using AppForSkills.Application.Likes.Commands.GiveLike;
using AppForSkills.Application.Likes.Commands.Unlike;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/discussions")]
    [ApiController]
    public class DiscussionsController : BaseController
    {
        /// <summary>
        /// Returns all discussions.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DiscussionsVm>> GetAllDiscussions()
        {
            var vm = await Mediator.Send(new GetDiscussionsQuery());
            return vm;
        }

        /// <summary>
        /// Returns single discussion.
        /// </summary>
        [Route("{id}/posts")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DiscussionVm>> GetDiscussion(int id)
        {
            var vm = await Mediator.Send(new GetDiscussionQuery() { DiscussionId = id });
            return vm;
        }

        /// <summary>
        /// Begins single discussion.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> BeginDiscussion(CreateDiscussionCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Edits first post in discussion.
        /// </summary>
        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> EditDiscussion(EditDiscussionCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Deletes discussion.
        /// </summary>
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteDiscussion(int id)
        {
            var result = await Mediator.Send(new DeleteDiscussionCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Adds post to discussion.
        /// </summary>
        [Route("{id}/posts")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> AddPostToDiscussion(CreatePostCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Edits post in discussion.
        /// </summary>
        [Route("{id}/posts/{idPost}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> EditPostInDiscussion(EditPostCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Deletes post in discussion.
        /// </summary>
        [Route("{id}/posts/{idPost}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeletePostInDiscussion(int idPost)
        {
            var result = await Mediator.Send(new DeletePostCommand() { PostId = idPost });
            return Ok(result);
        }

        /// <summary>
        /// Gives like to post in discussion.
        /// </summary>
        [Route("{id}/posts/{idPost}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> LikeToPostAsync(int idPost)
        {
            await Mediator.Send(new GiveLikeCommand() { PostInDiscussionId = idPost, User = "" });
            return Ok();
        }

        /// <summary>
        /// Deletes like.
        /// </summary>
        [Route("{id}/posts/{idPost}/unlike")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteLike(int idLike)
        {
            await Mediator.Send(new UnlikeCommand() { LikeId = idLike });
            return Ok();
        }

        /// <summary>
        /// Reports post in discussion.
        /// </summary>
        [Route("{id}/posts/{idPost}/report")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> ReportPostInDiscussion(int idPost)
        {
            await Mediator.Send(new ReportPostCommand() { PostId = idPost });
            return Ok();
        }
    }
}
