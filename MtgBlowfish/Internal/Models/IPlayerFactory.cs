namespace MtgBlowfish.Internal.Models;

internal interface IPlayerFactory
{
    Task<Player> CreateAsync(
        string name,
        string deckList,
        PlayerType type,
        CancellationToken cancellationToken = default);
}