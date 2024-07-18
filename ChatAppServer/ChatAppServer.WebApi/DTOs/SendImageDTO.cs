namespace ChatAppServer.WebApi.DTOs
{
    public sealed record SendImageDTO(
        int UserId,
        int toUserId,
        IFormFile File);
}
