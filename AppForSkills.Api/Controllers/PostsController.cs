﻿using Microsoft.AspNetCore.Http;
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
        /// Returns a photo or a video with general information of user skill.
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
        /// Adds a skill.
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
        /// Adds a rating to user skill.
        /// </summary>
        [Route("{id}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void AddRating()
        {

        }

        /// <summary>
        /// Edits a rating.
        /// </summary>
        /// <param name="idRating">Id Of rating, which user wants to edit</param>
        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void EditRating(int idRating)
        {

        }

        /// <summary>
        /// Deletes a rating.
        /// </summary>
        /// <param name="idRating">Id of rating, which user wants to remove</param>
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void DeleteRating(int idRating)
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

        public List<string> GetCommentFromUserSkill(int id)
        {
            return new List<string> { "value1", "value2" };
        }

        /// <summary>
        /// Adds comment to user skill.
        /// </summary>
        /// <param name="id">Post id</param>
        /// <param name="commentText">Post id</param>
        [Route("{id}/comments")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void AddCommentToUserSkill(int id, [FromBody] string commentText)
        {
        }

        /// <summary>
        /// Edits comment to user skill.
        /// </summary>
        /// <param name="idcomment">Id of comment, which user wants to edit</param>
        /// <param name="commentText">New text of comment</param>
        [Route("{id}/comments")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public void EditCommentToUserSkill(int idcomment, [FromBody] string commentText)
        {
        }

        /// <summary>
        /// Deletes comment from user skill.
        /// </summary>
        /// <param name="idComment">Id of comment, which user wants to remove</param>
        [Route("{id}/comments")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public void DeleteCommentFromUserSkill(int idComment)
        {
        }
    }
}