using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/posts/{id}")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        /// <summary>
        /// Get photo or video of user skill.
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Photo or video with skill, which user wants to share.</returns>
        [Route("photo-video")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetPhotoOrVideo(int id)
        {
            return "value";
        }

        /// <summary>
        /// Get description about photo or video, which has been posted by user.
        /// </summary>
        /// <param name="id">Id of post, which description we want to get.</param>
        [Route("description")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetDescriptionAboutUserPost(int id)
        {
            return "value";
        }
    }
}
