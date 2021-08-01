using AppForSkills.Application.SkillPosts.Commands.CreateComment;
using AppForSkills.Application.SkillPosts.Commands.CreateRating;
using AppForSkills.Application.SkillPosts.Commands.CreateSkillPost;
using AppForSkills.Application.SkillPosts.Commands.DeleteComment;
using AppForSkills.Application.SkillPosts.Commands.DeleteRating;
using AppForSkills.Application.SkillPosts.Commands.EditComment;
using AppForSkills.Application.SkillPosts.Commands.EditRating;
using AppForSkills.Application.SkillPosts.Queries.GetRatingsToSkillPost;
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
        /// Returns all ratings to skill.
        /// </summary>
        [Route("{id}/ratings")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RatingsPostVm>> GetAllRatingsAsync(int id)
        {
            var vm = await Mediator.Send(new GetRatingsToSkillPostQuery() { SkillId = id});
            return vm;
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
        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> EditRating(EditRatingCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
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

        public async Task<ActionResult> DeleteRating(int idRating)
        {
            var result = await Mediator.Send(new DeleteRatingCommand() { RatingId = idRating });
            return Ok(result);
        }

        /// <summary>
        /// Adds comment to user skill.
        /// </summary>
        [Route("{id}/comments")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> AddCommentToUserSkill(CreateCommentCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Edits comment to user skill.
        /// </summary>
        [Route("{id}/comments/{idComment}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> EditCommentToUserSkill(EditCommentCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
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

        public async Task<ActionResult> DeleteCommentFromUserSkill(int idComment)
        {
            var result = await Mediator.Send(new DeleteCommentCommand() { CommentId = idComment });
            return Ok(result);
        }
    }
}
