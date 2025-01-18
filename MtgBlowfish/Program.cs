using Autofac;
using MtgBlowfish.Internal.Game;
using MtgBlowfish.Internal.Models;

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
        
        IPlayerFactory playerFactory = container.Resolve<IPlayerFactory>();
        Player player1 = await playerFactory.CreateAsync(
            name: "Player 1",
            deckList: await File.ReadAllTextAsync(PlayerDeckFileName), 
            type: PlayerType.Human);
        
        Player player2 = await playerFactory.CreateAsync(
            name: "Player 2",
            deckList: await File.ReadAllTextAsync(AgentDeckFileName), 
            type: PlayerType.Human);

        IGameService game = container.Resolve<IGameService>();
        
        Game result = await game.RunGameAsync([player1, player2]);
        
        Console.WriteLine("Game over!");
        Console.WriteLine($"Player '{result.Winner?.Name}' wins!");
    }
}