using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRTest
{
    public static class Signal
    {
        public static async Task InitializeSignalr()
        {
            HubConnection connection = new HubConnectionBuilder()
                    .WithUrl(new Uri("http://127.0.0.1:5000/chathub"))
                    .WithAutomaticReconnect()
                    .Build();

            await connection.StartAsync();

            connection.On("helloClient", () =>
                         Console.WriteLine("Hub said hello to the client"));

        }

    }
}

