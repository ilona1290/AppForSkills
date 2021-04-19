using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        /// <summary>
        /// Returns photo or video with general information of user skill.
        /// </summary>
        /// <param name="id">Post id</param>
        [Route("{id}/photo-video")]
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
        /// Returns comments, which user skill receive.
        /// </summary>
        /// <param name="id">Post id</param>
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
