namespace MtgBlowfish.Internal.Game;

public enum PhaseType
{
    Untap = 0,
    Upkeep,
    Draw,
    PreCombatMain,
    BeginCombat,
    DeclareAttackers,
    DeclareBlockers,
    CombatDamage,
    EndCombat,
    PostCombatMain,
    End,
    Cleanup
}

/// <summary>
/// Extensions for <see cref="PhaseType"/>
/// </summary>
internal static class PhaseTypeExtensions
{
    /// <summary>
    /// Whether the given <paramref name="phase"/> allows the player to react when the stack is empty
    /// </summary>
    internal static bool AllowsPlayerReactionOnEmptyStack(this PhaseType phase)
        => phase is not PhaseType.Untap and not PhaseType.Cleanup;
    
    /// <summary>
    /// Get the next phase that follows after <param name="phase"></param>
    /// </summary>
    internal static PhaseType? GetNextPhase(this PhaseType phase) 
        => phase switch
        {
            PhaseType.Untap => PhaseType.Upkeep,
            PhaseType.Upkeep => PhaseType.Draw,
            PhaseType.Draw => PhaseType.PreCombatMain,
            PhaseType.PreCombatMain => PhaseType.BeginCombat,
            PhaseType.BeginCombat => PhaseType.DeclareAttackers,
            PhaseType.DeclareAttackers => PhaseType.DeclareBlockers,
            PhaseType.DeclareBlockers => PhaseType.CombatDamage,
            PhaseType.CombatDamage => PhaseType.EndCombat,
            PhaseType.EndCombat => PhaseType.PostCombatMain,
            PhaseType.PostCombatMain => PhaseType.End,
            PhaseType.End => PhaseType.Cleanup,
            PhaseType.Cleanup => null,
            _ => throw new ArgumentOutOfRangeException(nameof(phase), phase, null)
        };
}