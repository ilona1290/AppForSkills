using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/user/{username}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Returns general information about user.
        /// </summary>
        /// <param name="username"></param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetAllInformation(string username)
        {
            return "value";
        }

        /// <summary>
        /// Returns all user posts. 
        /// </summary>
        [Route("skills")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetAllUserSkills(string username)
        {
            return "value";
        }

        /// <summary>
        /// Returns selected user posts. 
        /// </summary>
        [Route("skills/{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetUserSkill(int id)
        {
            return "value";
        }

        /// <summary>
        /// Edits selected user posts. 
        /// </summary>
        [Route("skills/{id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void EditUserSkill(int id)
        {
            
        }

        /// <summary>
        /// Deletes selected user posts. 
        /// </summary>
        [Route("skills/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void DeleteUserSkill(int id)
        {

        }

        /// <summary>
        /// Returns comments of selected user posts. 
        /// </summary>
        [Route("skills/{id}/comments")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetCommentsFromUserSkill(int id)
        {
            return "value";
        }

        /// <summary>
        /// Adds comment of selected user posts. 
        /// </summary>
        [Route("skills/{id}/comments")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void CreateCommentToUserSkill(int id, string comment)
        {
            
        }

        /// <summary>
        /// Edits comment of selected user posts. 
        /// </summary>
        [Route("skills/{id}/comments")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void EditCommentToUserSkill(int id, int idComment, string comment)
        {
            
        }

        /// <summary>
        /// Deletes comment of selected user posts. 
        /// </summary>
        [Route("skills/{id}/comments")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void DeleteCommentFromUserSkill(int id, int idComment)
        {

        }

        /// <summary>
        /// Returns all ratings, which user gave to other users. 
        /// </summary>
        [Route("ratings")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetAllRatingsWhichUserGave(string username)
        {
            return "value";
        }

        /// <summary>
        /// Returns all comments, which user gave to other users. 
        /// </summary>
        [Route("comments")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetAllCommentsWhichUserGave(string username)
        {
            return "value";
        }

        /// <summary>
        /// Returns all user achievements. 
        /// </summary>
        [Route("achievements")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public string GetUserAchievements(string username)
        {
            return "value";
        }

    }
}
