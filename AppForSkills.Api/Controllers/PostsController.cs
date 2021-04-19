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
        /// Return photo or video of user skill.
        /// </summary>
        /// <param name="id">Post id</param>
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
        /// Return description about photo or video, which has been posted by user.
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

        /// <summary>
        /// Return comments to photo or video, which has been posted by user.
        /// </summary>
        /// <param name="id">Id of post, which comments we want to get.</param>
        [Route("comments")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public List<string> GetCommentsToUserPost(int id)
        {
            return new List<string> { "value1", "value2" };
        }
    }
}
