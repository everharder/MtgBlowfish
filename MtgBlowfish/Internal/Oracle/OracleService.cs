using Scryfall.API;

namespace MtgBlowfish.Internal.Oracle;

/// <inheritdoc />
internal class OracleService : IOracleService
{
    /// <inheritdoc />
    public async Task<Models.Card> GetCardAsync(string name, CancellationToken cancellationToken = default)
    {
        using ScryfallClient scryfall = new();
        var card = await scryfall.Cards.GetNamedWithHttpMessagesAsync(
            exact: name,
            cancellationToken: cancellationToken);
        return new(card.Body);
    }
}