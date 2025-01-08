namespace MtgBlowfish.Internal.Models;

/// <summary>
/// Gameplay relevant properties of a mtg card
/// </summary>
public record Card(
    string Name, 
    string ManaCost, 
    string TypeLine, 
    string OracleText,
    string Power,
    string Toughness, 
    string Loyalty)
{
    internal Card(Scryfall.API.Models.Card card)
        : this(card.Name, card.ManaCost, card.TypeLine, card.OracleText, card.Power, card.Toughness, card.Loyalty)
    {
    }
}