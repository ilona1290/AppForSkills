using AppForSkills.Application.Achievements.Queries.GetAchievements;
using AppForSkills.Application.Discussions.GetDiscussions;
using AppForSkills.Application.Discussions.Queries.GetDiscussion;
using AppForSkills.Application.SkillPosts.Commands.DeleteSkillPost;
using AppForSkills.Application.SkillPosts.Commands.EditSkillPost;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPosts;
using AppForSkills.Application.Users.Commands.CreateUser;
using AppForSkills.Application.Users.Commands.UpdateLoginDate;
using AppForSkills.Application.Users.Queries.GetUserAchievements;
using AppForSkills.Application.Users.Queries.GetUserComments;
using AppForSkills.Application.Users.Queries.GetUserDiscussionPosts;
using AppForSkills.Application.Users.Queries.GetUserDiscussions;
using AppForSkills.Application.Users.Queries.GetUserInformation;
using AppForSkills.Application.Users.Queries.GetUserRatings;
using AppForSkills.Application.Users.Queries.GetUserSkills;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : BaseController
    {

        /// <summary>
        /// Create user.
        /// </summary>
        [Route("create-user")]
        [HttpPost]
        [AllowAnonymous]

        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update user login date.
        /// </summary>
        [Route("update-login")]
        [HttpPut]
        [AllowAnonymous]

        public async Task<ActionResult> UpdateLoginDate(UpdateLoginDateCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Returns general information about user.
        /// </summary>
        [HttpGet]
        [Route("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<UserInformationVm>> GetAllInformation(string username)
        {
            var vm = await Mediator.Send(new GetUserInformationQuery() { Username = username });
            return vm;
        }

        /// <summary>
        /// Returns all user posts. 
        /// </summary>
        [Route("{username}/skills")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<SkillPostsVm>> GetAllUserSkillsAsync(string username)
        {
            var vm = await Mediator.Send(new GetUserSkillsQuery() { Username = username });
            return vm;
        }

        /// <summary>
        /// Returns all ratings, which user gave to other users. 
        /// </summary>
        [Route("{username}/ratings")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RatingsVm>> GetAllRatingsWhichUserGaveAsync(string username)
        {
            var vm = await Mediator.Send(new GetUserRatingsQuery() { Username = username });
            return vm;
        }

        /// <summary>
        /// Returns all comments, which user gave. 
        /// </summary>
        [Route("{username}/comments")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<UserCommentsVm>> GetAllCommentsWhichUserGaveAsync(string username)
        {
            var vm = await Mediator.Send(new GetUserCommentsQuery() { Username = username });
            return vm;
        }

        /// <summary>
        /// Returns all user achievements. 
        /// </summary>
        [Route("{username}/achievements")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AchievementsVm>> GetUserAchievementsAsync(string username)
        {
            var vm = await Mediator.Send(new GetUserAchievementsQuery() { Username = username });
            return vm;
        }

        /// <summary>
        /// Returns discussions, in which user participated. 
        /// </summary>
        [Route("{username}/discussions")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DiscussionsVm>> GetDiscussionsWithUserAsync(string username)
        {
            var vm = await Mediator.Send(new GetUserDiscussionsQuery() { Username = username });
            return vm;
        }

        /// <summary>
        /// Returns all discussion posts, which user gave. 
        /// </summary>
        [Route("{username}/discussionPosts")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<UserDiscussionPostsVm>> GetAllDiscussionPostsWhichUserGaveAsync(string username)
        {
            var vm = await Mediator.Send(new GetUserDiscussionPostsQuery() { Username = username });
            return vm;
        }
    }
}
