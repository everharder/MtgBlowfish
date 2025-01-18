namespace MtgBlowfish.Internal.Agent;

/// <summary>
/// Service that is accessible by an AI agent
/// </summary>
public interface IAgentService
{
    /// <summary>
    /// Get card's oracle text by its name 
    /// </summary>
    /// <param name="cardName">The name of the card</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The card information as Json</returns>
    Task<string> GetCardTextAsync(string cardName, CancellationToken cancellationToken = default);
}