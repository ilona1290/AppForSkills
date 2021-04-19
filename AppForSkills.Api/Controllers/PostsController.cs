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
        /// Returns all user skills.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetAllSkills()
        {
            return "value";
        }
        /// <summary>
        /// Returns photo or video with general information of user skill.
        /// </summary>
        /// <param name="id">Post id</param>
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetSkillWithGeneralInformation(int id)
        {
            return "value";
        }

        /// <summary>
        /// Adds skill.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void AddSkill()
        {
            
        }

        /// <summary>
        /// Returns comments, which user skill receive.
        /// </summary>
        /// <param name="id">Post id</param>
        [Route("{id}/comments")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public List<string> GetCommentsToUserSkill(int id)
        {
            return new List<string> { "value1", "value2" };
        }

        /// <summary>
        /// Adds comment to user skill.
        /// </summary>
        /// <param name="id">Post id</param>
        /// <param name="value">Post id</param>
        [Route("{id}/comments")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void AddCommentToUserSkill(int id, [FromBody] string value)
        {
        }
    }
}
