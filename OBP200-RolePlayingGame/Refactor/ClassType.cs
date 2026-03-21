namespace OBP200_RolePlayingGame;

public abstract class ClassType
{
    public abstract (int Maxhp, int Atk, int Def) LevelUpStats { get; protected set; }
    
    public abstract int DmgBuff(); // Konstant buff för alla klasser förutom rogue   
    public abstract int SpecialAttackDamage(int enemyDef, Player player);
}