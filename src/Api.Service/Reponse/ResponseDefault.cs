using Newtonsoft.Json;

namespace Api.Service.Response;

public class ResponseDefault<T>
{
    [JsonProperty("isOk")]
    public bool IsOk { get; set; }
    [JsonProperty("message")]
    public string? Message { get; set; }    
    public T? Data { get; set; }    
    public IEnumerable<T>? List { get; set; }    
}