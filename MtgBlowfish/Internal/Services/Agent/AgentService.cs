using System.Text.Json;
using MtgBlowfish.Internal.Models;
using MtgBlowfish.Internal.Services.Oracle;

namespace MtgBlowfish.Internal.Services.Agent;

/// <inheritdoc />
internal class AgentService : IAgentService
{
    internal required IOracleService Oracle { private get; init; } 
    
    /// <inheritdoc />
    public async Task<string> GetCardTextAsync(string name, CancellationToken cancellationToken = default)
    {
        Card card = await Oracle.GetCardAsync(name, cancellationToken);
        return JsonSerializer.Serialize(card, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        });
    }
}