using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.TextAnalytics;
using Azure.AI.Language.Conversations; // Added for Azure OpenAI SDK

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        // This is a simple in-memory store for chat messages
        private static readonly List<string> messages = new List<string>();

        private readonly TextAnalyticsClient _textAnalyticsClient;
        private readonly ConversationsClient _conversationsClient; // Added for Azure OpenAI SDK

        public ChatController(TextAnalyticsClient textAnalyticsClient, ConversationsClient conversationsClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
            _conversationsClient = conversationsClient; // Added for Azure OpenAI SDK
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
            // Implementing the actual call to Azure OpenAI using the Azure OpenAI SDK
            var options = new ConversationAnalysisClientOptions();
            var client = new ConversationAnalysisClient(new Uri("Your Azure OpenAI Endpoint"), new AzureKeyCredential("Your Azure OpenAI Key"), options);
            var result = await client.AnalyzeConversationAsync(new ConversationAnalysisOptions(message));
            return result.Value.ToString();
        }
    }
}
