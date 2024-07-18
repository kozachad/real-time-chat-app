namespace ChatAppServer.WebApi.DTOs
{
    public sealed record SendMessageDTO(
        int UserId,
        int toUserId,
        string Message,
        IFormFile? File);

}
