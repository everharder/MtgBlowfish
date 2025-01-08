using MtgBlowfish.Internal.Models;
using MtgBlowfish.Internal.Services.Deck;

namespace MtgBlowfish.Internal.Services.Game;

/// <inheritdoc />
internal class GameService : IGameService
{
    internal required IDeckListParser DeckListParser { private get; init; }
    internal required Random Random { private get; init; }
    
    private Models.Game? _game;
    
    private Models.Game Game
        => _game ?? throw new InvalidOperationException("Game has not started yet");
    
    /// <inheritdoc />
    public async Task StartGameAsync(
        string playerDeckList,
        string agentDeckList,
        CancellationToken cancellationToken = default)
    {
        _game = new Models.Game()
        {
            Human = await CreatePlayer(playerDeckList, cancellationToken),
            Agent = await CreatePlayer(agentDeckList, cancellationToken),
        };
    }

    private async Task<Player> CreatePlayer(string deckList, CancellationToken cancellationToken)
    {
        IReadOnlyList<Card> deck = await DeckListParser.Parse(deckList, cancellationToken);
        (IReadOnlyList<Card> hand, IReadOnlyList<Card> library) = Draw(Shuffle(deck), n: 7);
        return new Player
        {
            LifeTotal = 20,
            Library = library,
            Hand = hand,
        };
    }
    
    private (IReadOnlyList<Card> drawn, IReadOnlyList<Card> updatedCards) Draw(IReadOnlyList<Card> cards, int n = 1)
    {
        List<Card> drawn = new();
        foreach (int _ in Enumerable.Range(0, n))
        {
            (Card card, IReadOnlyList<Card> updatedCards) = DrawSingle(cards);
            cards = updatedCards;
            drawn.Add(card);
        }   
        return (drawn, cards);
    }
    
    private (Card drawn, IReadOnlyList<Card> updatedCards) DrawSingle(IReadOnlyList<Card> cards)
    {
        if (cards.Count == 0)
        {
            throw new InvalidOperationException("no cards to draw");
        }

        Card drawn = cards.First();
        IReadOnlyList<Card> updatedCards = cards.Skip(1).ToList();
        return (drawn, updatedCards);
    }

    private IReadOnlyList<Card> Shuffle(IReadOnlyList<Card> cards)
    {
        Card[] c = cards.ToArray();
        Random.Shuffle(c);
        return c;
    }
}