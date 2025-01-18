using MtgBlowfish.Internal.Game.Interaction;
using MtgBlowfish.Internal.Models;

namespace MtgBlowfish.Internal.Game.Phases;

internal class PhaseExecutor : IPhaseExecutor
{
    private Stack<string> Stack { get; } = new();
    
    internal required Func<PlayerType, IQuery> QueryFactory { private get; init; }
    internal required IActionResolver ActionResolver { private get; init; }
    
    /// <summary>
    /// Execute the phase
    /// </summary>
    public virtual async Task ExecuteAsync(PhaseType phase, Models.Game game, CancellationToken cancellationToken = default)
    {
        game.CurrentPhase = phase;
        if (!phase.AllowsPlayerReactionOnEmptyStack())
        {
            return;
        }

        int passedCount = 0;
        Player player = game.ActivePlayer;

        do
        {
            // a player can pass priority or take an action
            string? action;
            do
            {
                IQuery query = QueryFactory(player.Type);
                action = await query.QueryAsync(game, player, cancellationToken);
                if (action is not null)
                {
                    passedCount = 0;
                    Stack.Push(action);
                }
            } while (action != null);

            // no action -> passed priority
            passedCount++;

            // other player needs to pass still
            if (passedCount < game.Players.Count)
            {
                player = game.GetNextPlayer(player);
                continue;
            }

            // all players passed -> resolve stack
            if (Stack.TryPop(out string? actionToResolve))
            {
                await ActionResolver.ResolveAsync(game, actionToResolve, cancellationToken);
                passedCount = 0;
            }
        } while (passedCount < game.Players.Count || Stack.Count > 0);
    }
}