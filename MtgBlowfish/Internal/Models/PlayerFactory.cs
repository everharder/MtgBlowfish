using MtgBlowfish.Internal.Deck;

namespace MtgBlowfish.Internal.Models;

internal class PlayerFactory : IPlayerFactory
{
    internal required IDeckListParser DeckListParser { private get; init; }
    internal required Random Random { private get; init; }


    public async Task<Player> CreateAsync(
        string name,
        string deckList,
        PlayerType type,
        CancellationToken cancellationToken = default)
    {
        IReadOnlyList<Card> deck = await DeckListParser.Parse(deckList, cancellationToken);
        return new Player(
            name: name,
            type: type,
            startingLifeTotal: 20,
            startingDeck: Shuffle(deck));
    }
    
        
    private IReadOnlyList<Card> Shuffle(IReadOnlyList<Card> deck)
    {
        Card[] d = deck.ToArray();
        Random.Shuffle(d);
        return d;
    }
}