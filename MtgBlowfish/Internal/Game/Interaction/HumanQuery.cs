using MtgBlowfish.Internal.Models;

namespace MtgBlowfish.Internal.Game.Interaction;

/// <inheritdoc />
internal class HumanQuery : IQuery
{
    /// <inheritdoc />
    public Task<string?> QueryAsync(Models.Game game, Player player, CancellationToken cancellationToken = default)
    {
        string query = $"[{game.CurrentPhase}] <{player.Name}>: ";
        Console.Write(query);
        string? action = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(action))
        {
            action = null;
        }

        if (action is null)
        {
            Console.WriteLine($"Passed priority.");
        }
        
        return Task.FromResult(action);
    }
}