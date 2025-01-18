using MtgBlowfish.Internal.Models;

namespace MtgBlowfish.Internal.Game.Interaction;

internal class AgentQuery : IQuery
{
    public Task<string?> QueryAsync(Models.Game game, Player player, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}