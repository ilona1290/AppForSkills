using AppForSkills.Application.Achievements.Queries.GetAchievements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/achievements")]
    [Authorize]
    public class AchievementsController : BaseController
    {
        /// <summary>
        /// Returns all achievements.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AchievementsVm>> GetAllAchievements()
        {
            var vm = await Mediator.Send(new GetAchievementsQuery());
            return vm;
        }
    }
}
