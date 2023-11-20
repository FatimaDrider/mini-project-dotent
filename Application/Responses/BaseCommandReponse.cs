namespace Application.Responses;

public class BaseCommandReponse
{
    public int Id { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    public List<string> Errors { get; set; }
}