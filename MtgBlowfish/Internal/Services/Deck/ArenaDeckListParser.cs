using MtgBlowfish.Internal.Models;
using MtgBlowfish.Internal.Services.Oracle;

namespace MtgBlowfish.Internal.Services.Deck;

/// <summary>
/// Parses a MTG arena decklist
/// (see https://mtgarena-support.wizards.com/hc/en-us/articles/360049857771-Importing-a-Deck)  
/// </summary>
internal class ArenaDeckListParser : IDeckListParser
{
    internal required IOracleService Oracle { private get; init; }
    
    public async Task<IReadOnlyList<Card>> Parse(string deckList, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(deckList))
        {
            throw new ArgumentNullException(nameof(deckList));
        }
        
        IReadOnlyList<string> lines = deckList.Split("\n")
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();
        if (!lines[0].StartsWith("deck", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidDataException("Arena deck list must start with 'deck' line.");
        } 
        
        List<Card> cards = new();
        foreach (var line in lines.Skip(1))
        {
            if (line.StartsWith("sideboard", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            string[] parts = line.Split(' ', 2);
            int quantity = int.Parse(parts[0]);
            string name = parts[1];
            
            var card = await Oracle.GetCardAsync(name, cancellationToken);
            // add card N times
            cards.AddRange(Enumerable.Range(0, quantity).Select(_ => card));
        }
        return cards;
    }
}