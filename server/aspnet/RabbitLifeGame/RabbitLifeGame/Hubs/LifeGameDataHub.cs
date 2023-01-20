using Microsoft.AspNetCore.SignalR;

namespace RabbitLifeGame.Hubs;

public class LifeGameDataHub : Hub
{
    public async Task GetDataCommand(int x, int y, int width, int height)
    {
        await Clients.Caller.SendAsync("IntervalMessage", ret);
    }
}
