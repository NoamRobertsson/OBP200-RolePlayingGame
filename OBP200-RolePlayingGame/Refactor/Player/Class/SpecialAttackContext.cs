namespace OBP200_RolePlayingGame.Refactor;

// Kontext klass som skickas till IClassType för att undvika att hela player viass
public sealed class SpecialAttackContext
{
    public int PlayerAtk { get; init; }
    public int EnemyDef { get; init; }
    public Random Rng { get; init; } = default!;  
    
    public Func<int, bool> TrySpendGold { get; init; } // För mage
    public Action<int> TakeDamage { get; init; } // För warrior
}