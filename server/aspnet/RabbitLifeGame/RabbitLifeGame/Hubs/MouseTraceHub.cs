using Microsoft.AspNetCore.SignalR;

namespace RabbitLifeGame.Hubs;

public class MouseTraceHub : Hub
{
	public async Task MouseMoveCommand(Request request)
	{
		var ret = new Response { X = request.X, Y = request.Y };
		await Clients.All.SendAsync("MouseMoveMessage", ret);
	}

	private class Response
	{
		public int X { get; set; }
		public int Y { get; set; }
	}

	public class Request
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
