using Scryfall.API.Models;

namespace MtgBlowfish.Internal.Models;

/// <summary>
/// A MTG player
/// </summary>
internal record Player
{
    /// <summary>
    /// The current life total
    /// </summary>
    public required int LifeTotal { get; set; }
    
    /// <summary>
    /// The cards in library
    /// </summary>
    public required IReadOnlyList<Card> Library { get; init; }

    /// <summary>
    /// The cards in hand
    /// </summary>
    public IReadOnlyList<Card> Hand { get; init; } = [];
    
    /// <summary>
    /// The cards in graveyard
    /// </summary>
    public IReadOnlyList<Card> Graveyard { get; init; } = [];
    
    /// <summary>
    /// The cards in exile
    /// </summary>
    public IReadOnlyList<Card> Exile { get; init; } = [];
}