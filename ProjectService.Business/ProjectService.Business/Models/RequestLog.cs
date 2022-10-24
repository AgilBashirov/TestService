using MongoDB.Bson.Serialization.Attributes;

namespace ProjectService.Business.Models;

public class RequestLog
{
    [BsonId] public Guid Id { get; set; }
    public string RequestUrl { get; set; }
    public string RequestHeaders { get; set; }
    public int ResponseStatusCode { get; set; }
    public string ResponseBody { get; set; }
    public string ResponseHeaders { get; set; }
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    public string? RequestIP { get; set; }
}