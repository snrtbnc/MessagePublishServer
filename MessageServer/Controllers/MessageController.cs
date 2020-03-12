using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class MessageController: ControllerBase
    {
        private readonly IMessageService messageService_;

        public MessageController(IMessageService messageService)
        {
            messageService_ = messageService;
        }
        [HttpGet("all/{message}")]
        public ActionResult<string> PublishMessagetoAll(string message)
        {
            messageService_.PublishtoAll(message).GetAwaiter().GetResult();
            return Ok();
        }

        [HttpGet("{groupId}/{message}")]
        public ActionResult<string> PublishMessagetoGroup(string groupId, string message)
        {
            messageService_.PublishtoGroup(groupId, message);
            return Ok();
        }

        [HttpGet("{groupId}/{personalId}/{message}")]
        public ActionResult<string> PublishMessagetoAll(string personalId, string groupId, string message)
        {
            messageService_.PublishtoPersonal(personalId,groupId, message);
            return Ok();
        }
    }
}
