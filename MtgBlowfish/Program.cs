using Autofac;
using MtgBlowfish.Internal.Services.Game;

namespace MtgBlowfish;

public static class Program
{
    private const string PlayerDeckFileName = "PlayerDeck.txt";
    private const string AgentDeckFileName = "AgentDeck.txt";
    
    public static async Task Main(string[] args)
    {
        ContainerBuilder builder = new();
        builder.RegisterModule<Module>();
        IContainer container = builder.Build();

        IGameService game = container.Resolve<IGameService>();
        await game.StartGameAsync(
            playerDeckList: await File.ReadAllTextAsync(PlayerDeckFileName),
            agentDeckList: await File.ReadAllTextAsync(AgentDeckFileName));
    }
}