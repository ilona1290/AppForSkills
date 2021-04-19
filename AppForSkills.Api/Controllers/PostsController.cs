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
        /// Get photo or video of user skill
        /// </summary>
        [Route("photo-video")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetPhotoOrVideo()
        {
            throw new NotImplementedException();
        }
    }
}
