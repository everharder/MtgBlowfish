using MtgBlowfish.Internal.Game;

namespace MtgBlowfish.Internal.Models;

/// <summary>
/// A game of Magic the Gathering
/// </summary>
internal class Game
{
    /// <summary>
    /// The current turn
    /// </summary>
    public int Turn { get; set; } = 0;
    
    /// <summary>
    /// The current phase
    /// </summary>
    public PhaseType CurrentPhase { get; set; }
    
    /// <summary>
    /// The player whose turn it is
    /// </summary>
    public required Player ActivePlayer { get; set; }
    
    /// <summary>
    /// The players
    /// </summary>
    public required IReadOnlyList<Player> InitialPlayers { get; set; }
    
    /// <summary>
    /// The players
    /// </summary>
    public required IList<Player> Players { get; set; }
    
    /// <summary>
    /// The winning player
    /// </summary>
    public Player? Winner { get; set; }

    /// <summary>
    /// Get the next player in turn order
    /// </summary>
    public Player GetNextPlayer()
        => GetNextPlayer(ActivePlayer);
    
    /// <summary>
    /// Get the next player in turn order of <paramref name="current"/>
    /// </summary>
    public Player GetNextPlayer(Player current)
    {
        int index = Players.IndexOf(current);
        return Players[(index + 1) % Players.Count];
    }
}
