namespace MtgBlowfish.Internal.Game.Behaviors;

/// <inheritdoc />
internal class DrawCardInDrawPhaseBehavior : IBehavior
{
    /// <inheritdoc />
    public Task<bool> CanExecuteAsync(Models.Game game, CancellationToken cancellationToken = default)
        => Task.FromResult(game.CurrentPhase == PhaseType.Draw);

    /// <inheritdoc />
    public Task ExecuteAsync(Models.Game game, CancellationToken cancellationToken = default)
    {
        game.ActivePlayer.Draw();
        return Task.CompletedTask;
    }
}