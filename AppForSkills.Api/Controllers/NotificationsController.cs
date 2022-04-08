using AppForSkills.Application.Notifications.Queries.Commands.ReadNotifications;
using AppForSkills.Application.Notifications.Queries.GetAllNotifications;
using AppForSkills.Application.Notifications.Queries.GetUnreadNotifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Api.Controllers
{
    [Route("api/notifications")]
    public class NotificationsController : BaseController
    {
        /// <summary>
        /// Returns all notifications for user.
        /// </summary>
        [Route("{username}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<NotificationsVm>> GetAllNotifications(string username)
        {
            var vm = await Mediator.Send(new GetAllNotificationsQuery() { Username = username});
            return vm;
        }

        /// <summary>
        /// Returns unread notifications for user.
        /// </summary>
        [Route("{username}/Unread")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<NotificationsVm>> GetUnreadNotifications(string username)
        {
            var vm = await Mediator.Send(new GetUnreadNotificationsQuery() { Username = username });
            return vm;
        }

        /// <summary>
        /// Read notifications.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> ReadNotifications(ReadNotificationsCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
