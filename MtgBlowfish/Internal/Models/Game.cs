namespace MtgBlowfish.Internal.Models;

/// <summary>
/// A game of Magic the Gathering
/// </summary>
internal record Game
{
    /// <summary>
    /// The current turn
    /// </summary>
    public int Turn { get; init; } = 0;
    
    /// <summary>
    /// The human player
    /// </summary>
    public required Player Human { get; init; }
    
    /// <summary>
    /// The AI agent
    /// </summary>
    public required Player Agent { get; init; }
}
