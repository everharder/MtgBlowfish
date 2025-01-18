using MtgBlowfish.Internal.Models;

namespace MtgBlowfish.Internal.Game.Interaction;

internal interface IQuery
{
    Task<string?> QueryAsync(Models.Game game, Player player, CancellationToken cancellationToken = default);
}