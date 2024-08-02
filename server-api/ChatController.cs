using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.TextAnalytics;
using Azure.AI.Language.Conversations;
using Microsoft.EntityFrameworkCore;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatContext _context;
        private readonly TextAnalyticsClient _textAnalyticsClient;
        private readonly ConversationsClient _conversationsClient;

        public ChatController(ChatContext context, TextAnalyticsClient textAnalyticsClient, ConversationsClient conversationsClient)
        {
            _context = context;
            _textAnalyticsClient = textAnalyticsClient;
            _conversationsClient = conversationsClient;
        }

        // POST api/chat/send
        [HttpPost("send")]
        public async Task<ActionResult> SendMessage([FromBody] string message)
        {
            var response = await CallAzureOpenAI(message);
            var chatMessage = new ChatMessage
            {
                Message = response,
                Timestamp = DateTime.UtcNow
            };
            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();
            return Ok("Message received and processed");
        }

        // GET api/chat/receive
        [HttpGet("receive")]
        public async Task<ActionResult<IEnumerable<string>>> ReceiveMessages()
        {
            var messages = await _context.ChatMessages.ToListAsync();
            return Ok(messages);
        }

        private async Task<string> CallAzureOpenAI(string message)
        {
            var options = new ConversationAnalysisClientOptions();
            var client = new ConversationAnalysisClient(new Uri("Your Azure OpenAI Endpoint"), new AzureKeyCredential("Your Azure OpenAI Key"), options);
            var result = await client.AnalyzeConversationAsync(new ConversationAnalysisOptions(message));
            return result.Value.ToString();
        }
    }
}
