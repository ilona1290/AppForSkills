using AppForSkills.Application.Discussions.Commands.CreateDiscussion;
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
        /// Adds post to discussion.
        /// </summary>
        [Route("{id}/posts")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void AddPostToDiscussion()
        {

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

        public void EditPostInDiscussion(int idPost)
        {

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

        public void DeletePostInDiscussion(int idPost)
        {

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
