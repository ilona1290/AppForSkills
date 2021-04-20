using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        /// <summary>
        /// Returns user ranking sorted by the number of inserted skill posts .
        /// </summary>
        [Route("most-posts-of-skills")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetRankingOfTheMostPostingSkillsUsers()
        {
            return "value";
        }

        /// <summary>
        /// Returns user ranking sorted by best average ratings.
        /// </summary>
        [Route("best-rating")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetRankingOfTheBestAverageRatings()
        {
            return "value";
        }

        /// <summary>
        /// Returns users ranking sorted by the number of comments to skill posts.
        /// </summary>
        [Route("most-comments-to-skills")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetRankingOfTheMostCommentingUsers()
        {
            return "value";
        }

        /// <summary>
        /// Returns users ranking sorted by the number of ratings to skill posts.
        /// </summary>
        [Route("most-ratings-to-skills")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetRankingOfTheMostEvaluativeUsers()
        {
            return "value";
        }

        /// <summary>
        /// Returns users ranking sorted by the most posts in discussions.
        /// </summary>
        [Route("most-posts-in-discussing")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetRankingOfTheMostActiveUsersInDiscussions()
        {
            return "value";
        }
    }
}
