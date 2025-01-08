namespace MtgBlowfish.Internal.Services.Game;

/// <summary>
/// Service for mtg gameplay
/// </summary>
internal interface IGameService
{
    /// <summary>
    /// Start a new mtg game 
    /// </summary>
    Task StartGameAsync(
        string playerDeckList,
        string agentDeckList,
        CancellationToken cancellationToken = default);
}