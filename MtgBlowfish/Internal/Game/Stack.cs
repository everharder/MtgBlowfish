namespace MtgBlowfish.Internal.Game;

internal record Stack
{
    public Stack<string> Effects { get; } = new();
    public bool IsEmpty => Effects.Count == 0;
}