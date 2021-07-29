using AppForSkills.Application.SkillPosts.Commands.CreateRating;
using AppForSkills.Application.SkillPosts.Commands.CreateSkillPost;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPosts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : BaseController
    {
        /// <summary>
        /// Returns all user skills.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<SkillPostsVm>> GetAllSkillsAsync()
        {
            var vm = await Mediator.Send(new GetSkillPostsQuery());
            return vm;
        }

        /// <summary>
        /// Returns a photo or a video with general information of user skill.
        /// </summary>
        /// <param name="id">Post id</param>
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<SkillPostVm>> GetSkillWithGeneralInformation(int id)
        {
            var vm = await Mediator.Send(new GetSkillPostDetailQuery() { SkillPostId = id });
            return vm;
        }

        /// <summary>
        /// Adds a skill.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> AddSkill(CreateSkillPostCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Adds a rating to user skill.
        /// </summary>
        [Route("{id}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> AddRating(CreateRatingCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Edits a rating.
        /// </summary>
        /// <param name="idRating">Id Of rating, which user wants to edit</param>
        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void EditRating(int idRating)
        {

        }

        /// <summary>
        /// Deletes a rating.
        /// </summary>
        /// <param name="idRating">Id of rating, which user wants to remove</param>
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void DeleteRating(int idRating)
        {

        }

        /// <summary>
        /// Adds comment to user skill.
        /// </summary>
        /// <param name="id">Post id</param>
        /// <param name="commentText">Post id</param>
        [Route("{id}/comments")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void AddCommentToUserSkill(int id, [FromBody] string commentText)
        {
        }

        /// <summary>
        /// Edits comment to user skill.
        /// </summary>
        /// <param name="idComment">Id of comment, which user wants to edit</param>
        /// <param name="commentText">New text of comment</param>
        [Route("{id}/comments/{idComment}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void EditCommentToUserSkill(int idComment, [FromBody] string commentText)
        {
        }

        /// <summary>
        /// Deletes comment from user skill.
        /// </summary>
        /// <param name="idComment">Id of comment, which user wants to remove</param>
        [Route("{id}/comments/{idComment}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void DeleteCommentFromUserSkill(int idComment)
        {
        }
    }
}
