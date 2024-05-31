using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.TextAnalytics;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        // This is a simple in-memory store for chat messages
        private static readonly List<string> messages = new List<string>();

        private readonly TextAnalyticsClient _textAnalyticsClient;

        public ChatController(TextAnalyticsClient textAnalyticsClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
        }

        // POST api/chat/send
        [HttpPost("send")]
        public async Task<ActionResult> SendMessage([FromBody] string message)
        {
            var response = await CallAzureOpenAI(message);
            messages.Add(response);
            return Ok("Message received and processed");
        }

        // GET api/chat/receive
        [HttpGet("receive")]
        public ActionResult<IEnumerable<string>> ReceiveMessages()
        {
            return Ok(messages);
        }

        private async Task<string> CallAzureOpenAI(string message)
        {
            // This method should implement the call to Azure OpenAI and return the response
            // Placeholder for Azure OpenAI call
            return $"Response to '{message}' from Azure OpenAI";
        }
    }
}
