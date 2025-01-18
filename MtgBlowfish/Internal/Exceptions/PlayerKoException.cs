using MtgBlowfish.Internal.Models;

namespace MtgBlowfish.Internal.Exceptions;

internal class PlayerKoException : Exception
{
    public Player Player { get; }
    
    public PlayerKoException(Player player)
    {
        Player = player;
    }
}