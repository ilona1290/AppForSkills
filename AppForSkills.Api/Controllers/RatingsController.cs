using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppForSkills.Api.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        /// <summary>
        /// Returns user ranking sorted by chosen element.
        /// </summary>
        /// <param name="element">Choose one of the elements: skillPosts, bestRatings, numberOfGivingRatings, numberOfGivingComments, postsInDiscussions </param>
        [Route("users/orderBy={element}:desc")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetRankingAboutUser(string element)
        {
            return "value";
        }
    }
}
