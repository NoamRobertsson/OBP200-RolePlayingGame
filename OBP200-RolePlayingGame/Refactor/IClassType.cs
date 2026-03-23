namespace OBP200_RolePlayingGame.Refactor;

public interface IClassType
{
    string Name { get;}
    double RunAwayChance { get; } 
    void ApplyLevelUp(Player player);
    int DmgBuff(Random rng); // Konstant buff för alla klasser förutom rogue   
    int SpecialAttackDamage(int enemyDef,Random rng, Player player);
}