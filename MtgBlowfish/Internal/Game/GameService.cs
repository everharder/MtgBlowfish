using MtgBlowfish.Internal.Exceptions;
using MtgBlowfish.Internal.Game.Phases;
using MtgBlowfish.Internal.Models;

namespace MtgBlowfish.Internal.Game;

/// <inheritdoc />
internal class GameService : IGameService
{
    internal required IPhaseExecutor PhaseExecutor { private get; init; }
    
    /// <inheritdoc />
    public async Task<Models.Game> RunGameAsync(
        IReadOnlyList<Player> players,
        CancellationToken cancellationToken = default)
    {
        if (players.Count < 2)
        {
            throw new ArgumentException(nameof(players));
        }
        
        Models.Game game = new()
        {
            Players = players.ToList(),
            InitialPlayers = players,
            ActivePlayer = players.First(),
        };

        // main game loop
        while (game.Winner is null)
        {
            try
            {
                game.Turn++;
                Console.WriteLine($"Start {game.ActivePlayer.Name}'s turn (Turn {game.Turn})");
                
                PhaseType? nextPhase = PhaseType.Untap;
                do
                {
                    await PhaseExecutor.ExecuteAsync(nextPhase.Value, game, cancellationToken);
                    nextPhase = nextPhase.Value.GetNextPhase();
                } while (nextPhase != null);
            
                // pass turn
                game.ActivePlayer = game.GetNextPlayer();
            }
            catch (PlayerKoException e)
            {
                game.Players.Remove(e.Player);
                if (game.Players.Count == 1)
                {
                    game.Winner = game.Players[0];
                }
            }
        }

        return game;
    }
}