namespace OBP200_RolePlayingGame.Refactor;

public interface IClassType
{
    string Name { get;}
    double RunAwayChance { get; } 
    (int MaxHp, int Atk, int Def) LevelUpStats { get; }
    int DmgBuff(Random rng); // Konstant buff för alla klasser förutom rogue   
    int SpecialAttackDamage(SpecialAttackContext context);
}