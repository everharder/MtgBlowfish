namespace MtgBlowfish.Internal.Game.Behaviors;

/// <summary>
/// Something that happens during a game
/// </summary>
internal interface IBehavior
{
    /// <summary>
    /// Whether the behavior can be executed
    /// </summary>
    Task<bool> CanExecuteAsync(Models.Game game, CancellationToken cancellationToken = default);

    /// <summary>
    /// Execute the behavior
    /// </summary>
    Task ExecuteAsync(Models.Game game, CancellationToken cancellationToken = default);
}