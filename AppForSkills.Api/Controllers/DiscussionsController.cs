using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/discussions")]
    [ApiController]
    public class DiscussionsController : ControllerBase
    {
        /// <summary>
        /// Returns all discussions.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetAllDiscussions()
        {
            return "value";
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

        public string GetDiscussion(int id)
        {
            return "value";
        }

        /// <summary>
        /// Begins single discussion.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void BeginDiscussion()
        {
            
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


    }
}
