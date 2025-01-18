namespace MtgBlowfish.Internal.Game.Interaction;

internal interface IActionResolver
{
    Task ResolveAsync(Models.Game game, string action, CancellationToken cancellationToken = default);
}