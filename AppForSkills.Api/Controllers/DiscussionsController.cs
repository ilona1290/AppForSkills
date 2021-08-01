using AppForSkills.Application.Discussions.Commands.CreateDiscussion;
using AppForSkills.Application.Discussions.Commands.CreatePost;
using AppForSkills.Application.Discussions.Commands.DeletePost;
using AppForSkills.Application.Discussions.Commands.EditDiscussion;
using AppForSkills.Application.Discussions.Commands.EditPost;
using AppForSkills.Application.Discussions.GetDiscussions;
using AppForSkills.Application.Discussions.Queries.GetDiscussion;
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

        public void GiveLikePostInDiscussion(int idPost)
        {

        }

        /// <summary>
        /// Reports post in discussion.
        /// </summary>
        [Route("{id}/posts/{idPost}/report")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void ReportPostInDiscussion(int idPost)
        {

        }
    }
}
