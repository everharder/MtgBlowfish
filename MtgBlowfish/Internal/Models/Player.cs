using MtgBlowfish.Internal.Exceptions;
using Scryfall.API.Models;

namespace MtgBlowfish.Internal.Models;

/// <summary>
/// A MTG player
/// </summary>
internal record Player
{
    /// <summary>
    /// The name of the player
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// The current life total
    /// </summary>
    public int LifeTotal { get; set; }
    
    /// <summary>
    /// Whether the player is human or AI
    /// </summary>
    public PlayerType Type { get; }
    
    /// <summary>
    /// The cards in library
    /// </summary>
    public IReadOnlyList<Card> Library { get; private set; }

    /// <summary>
    /// The cards in hand
    /// </summary>
    public IReadOnlyList<Card> Hand { get; private set; } = [];
    
    /// <summary>
    /// The cards in graveyard
    /// </summary>
    public IReadOnlyList<Card> Graveyard { get; private set; } = [];
    
    /// <summary>
    /// The cards in exile
    /// </summary>
    public IReadOnlyList<Card> Exile { get; private set; } = [];

    /// <summary>
    /// Create a new player
    /// </summary>
    public Player(string name, PlayerType type, int startingLifeTotal, IReadOnlyList<Card> startingDeck)
    {
        Name = name;
        Type = type;
        LifeTotal = startingLifeTotal;
        Library = startingDeck;
        Draw(n: 7);
    }

    /// <summary>
    /// Draw <paramref name="n"/> cards from library
    /// </summary>
    public void Draw(int n = 1)
    {
        foreach (int _ in Enumerable.Range(0, n))
        {
            if (Library.Count == 0)
            {
                throw new PlayerKoException(this);
            }

            Card card = Library.First();
            Library = Library.Skip(1).ToList();
            Hand =
            [
                ..Hand,
                card,
            ];
        }
    }
}