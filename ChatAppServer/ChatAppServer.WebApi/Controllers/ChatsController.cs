using Azure.Core;
using ChatAppServer.WebApi.Context;
using ChatAppServer.WebApi.DTOs;
using ChatAppServer.WebApi.Hubs;
using ChatAppServer.WebApi.Models;
using GenericFileService.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatAppServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class ChatsController(
        ApplicationDbContext context,
        IHubContext<ChatHub> hubContext) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await context.Users.OrderBy(x => x.Name).ToListAsync();
            return Ok(users);
        }
        [HttpGet]
        public async Task<IActionResult> GetChats(int UserId, int toUserId, CancellationToken cancellationToken)
        {
            List<Chat> chats = await context.Chats
                .Where(p => p.UserId == UserId && p.toUserId == toUserId
            || p.toUserId == UserId && p.UserId == toUserId)
                .OrderBy(p => p.Date)
                .ToListAsync(cancellationToken);

            return Ok(chats);

        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageDTO request, CancellationToken cancellationToken)
        {
            //string? image = FileService.FileSaveToServer(request?.File, "wwwroot/images/");
            Chat chat = new()
            {
                UserId = request.UserId,
                toUserId = request.toUserId,
                Message = request.Message,
                //Image = image,
                Date = DateTime.Now
            };

            await context.AddAsync(chat,cancellationToken);
            await context.SaveChangesAsync(!cancellationToken.IsCancellationRequested);
            
            string connectionId = ChatHub.Users.FirstOrDefault(p => p.Value == chat.toUserId).Key;


            await hubContext.Clients.Client(connectionId).SendAsync("Messages", chat);
            return Ok(chat);
        }

        [HttpPost]
        [Authorize(Roles = "vip")]
        public async Task<IActionResult> SendImage([FromForm]SendImageDTO request, CancellationToken cancellationToken)
        {
            string image = FileService.FileSaveToServer(request.File, "wwwroot/images/");
            Chat chat = new()
            {
                UserId = request.UserId,
                toUserId = request.toUserId,
                Image = image,
                Date = DateTime.Now
            };

            await context.AddAsync(chat, cancellationToken);
            await context.SaveChangesAsync(!cancellationToken.IsCancellationRequested);

            string connectionId = ChatHub.Users.FirstOrDefault(p => p.Value == chat.toUserId).Key;


            await hubContext.Clients.Client(connectionId).SendAsync("Messages", chat);
            return Ok(chat);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead([FromBody]MarkasReadDTO request, CancellationToken cancellationToken)
        {
            var chats = await context.Chats
            .Where(c => c.UserId == request.UserId && c.toUserId == request.toUserId && !c.isRead)
            .ToListAsync();

            if (!chats.Any())
            {
                return NotFound();
            }

            foreach (var chat in chats)
            {
                chat.isRead = true;
            }

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
