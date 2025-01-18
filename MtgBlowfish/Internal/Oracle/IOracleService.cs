using MtgBlowfish.Internal.Models;

namespace MtgBlowfish.Internal.Oracle;

/// <summary>
/// Service for accessing card info 
/// </summary>
public interface IOracleService
{
    /// <summary>
    /// Get a card by its <paramref name="name"/>
    /// </summary>
    Task<Card> GetCardAsync(string name, CancellationToken cancellationToken = default);
}