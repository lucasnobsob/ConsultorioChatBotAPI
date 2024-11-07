using System.Text.Json.Serialization;

namespace ConsultorioChatBot.API.ViewModels
{
    public class DialogflowRequestViewModel
    {
        [JsonPropertyName("responseId")]
        public string ResponseId { get; set; }

        [JsonPropertyName("queryResult")]
        public QueryResult QueryResult { get; set; }

        [JsonPropertyName("originalDetectIntentRequest")]
        public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; }

        [JsonPropertyName("session")]
        public string Session { get; set; }
    }

    public class QueryResult
    {
        [JsonPropertyName("queryText")]
        public string QueryText { get; set; }

        [JsonPropertyName("parameters")]
        public Dictionary<string, object> Parameters { get; set; }

        [JsonPropertyName("allRequiredParamsPresent")]
        public bool AllRequiredParamsPresent { get; set; }

        [JsonPropertyName("fulfillmentMessages")]
        public List<FulfillmentMessage> FulfillmentMessages { get; set; }

        [JsonPropertyName("outputContexts")]
        public List<OutputContext> OutputContexts { get; set; }

        [JsonPropertyName("intent")]
        public Intent Intent { get; set; }

        [JsonPropertyName("intentDetectionConfidence")]
        public double IntentDetectionConfidence { get; set; }

        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; }
    }

    public class Text
    {
        [JsonPropertyName("text")]
        public List<string> TextItems { get; set; }
    }

    public class OutputContext
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lifespanCount")]
        public int? LifespanCount { get; set; }

        [JsonPropertyName("parameters")]
        public Dictionary<string, object> Parameters { get; set; }
    }

    public class Intent
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }

    public class OriginalDetectIntentRequest
    {
        [JsonPropertyName("payload")]
        public Dictionary<string, object> Payload { get; set; }
    }
}
