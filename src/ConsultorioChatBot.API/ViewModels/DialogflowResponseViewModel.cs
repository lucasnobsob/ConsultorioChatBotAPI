using System.Text.Json.Serialization;

namespace ConsultorioChatBot.API.ViewModels
{
    public class DialogflowResponseViewModel
    {
        [JsonPropertyName("fulfillmentMessages")]
        public List<FulfillmentMessage> FulfillmentMessages { get; set; } = new List<FulfillmentMessage>();

        [JsonPropertyName("outputContexts")]
        public List<OutputContext> OutputContexts { get; set; } = new List<OutputContext>();
    }

    public class FulfillmentMessage
    {
        [JsonPropertyName("text")]
        public Text Text { get; set; }
    }

    public class Payload
    {
        [JsonPropertyName("richContent")]
        public IEnumerable<RichContent> RichContent { get; set; } = new List<RichContent>();
    }

    public class RichContent
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("text")]
        public IEnumerable<string> Text { get; set; } = new List<string>();
    }
}
