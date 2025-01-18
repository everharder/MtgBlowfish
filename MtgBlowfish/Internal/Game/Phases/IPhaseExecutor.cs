namespace MtgBlowfish.Internal.Game.Phases;

internal interface IPhaseExecutor
{
    Task ExecuteAsync(PhaseType phase, Models.Game game, CancellationToken cancellationToken = default);
}