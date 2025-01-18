using MtgBlowfish.Internal.Models;

namespace MtgBlowfish.Internal.Deck;

/// <summary>
/// Service for parsing decklists
/// </summary>
internal interface IDeckListParser
{
    /// <summary>
    /// Parses a mtg deck list
    /// </summary>
    Task<IReadOnlyList<Card>> Parse(string deckList, CancellationToken cancellationToken = default);
}