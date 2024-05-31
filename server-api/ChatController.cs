using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        // This is a simple in-memory store for chat messages
        private static readonly List<string> messages = new List<string>();

        // POST api/chat/send
        [HttpPost("send")]
        public ActionResult SendMessage([FromBody] string message)
        {
            messages.Add(message);
            return Ok("Message received");
        }

        // GET api/chat/receive
        [HttpGet("receive")]
        public ActionResult<IEnumerable<string>> ReceiveMessages()
        {
            return Ok(messages);
        }
    }
}
