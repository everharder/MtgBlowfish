using MtgBlowfish.Internal.Models;

namespace MtgBlowfish.Internal.Game;

/// <summary>
/// Service for mtg gameplay
/// </summary>
internal interface IGameService
{
    /// <summary>
    /// Start a new mtg game 
    /// </summary>
    Task<Models.Game> RunGameAsync(
        IReadOnlyList<Player> players,
        CancellationToken cancellationToken = default);
}