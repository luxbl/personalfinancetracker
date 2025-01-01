using Microsoft.AspNetCore.SignalR;

public class FinanceHub : Hub
{
    public async Task SendUpdate(string message)
    {
        await Clients.All.SendAsync("ReceiveUpdate", message);
    }
}
