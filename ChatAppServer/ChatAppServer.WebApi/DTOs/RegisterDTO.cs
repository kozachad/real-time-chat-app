namespace ChatAppServer.WebApi.DTOs
{
    public sealed record RegisterDTO(
        string Name,
        string Password,
        string Role
        //IFormFile File
        );
}
