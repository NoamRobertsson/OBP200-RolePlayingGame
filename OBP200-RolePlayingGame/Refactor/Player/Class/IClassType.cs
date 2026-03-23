namespace OBP200_RolePlayingGame.Refactor.Player.Class;

public interface IClassType
{
    static string Name { get;}
    double RunAwayChance { get; } 
    static (int maxHp, int  hp, int atk, int def, int potions, int gold) BaseStats { get; }
    (int MaxHp, int Atk, int Def) LevelUpStats { get; }
    int DmgBuff(Random rng); // Konstant buff för alla klasser förutom rogue   
    int SpecialAttackDamage(SpecialAttackContext context);
}