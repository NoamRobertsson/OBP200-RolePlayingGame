namespace OBP200_RolePlayingGame;

public abstract class ClassType
{
    public abstract (int Maxhp, int Atk, int Def) LevelUpStats { get; protected set; }
    public virtual double FlightChance { get; protected set; } = 0.25; // För Rogue, 20% chans att fly från strid
    
    public abstract int DmgBuff(); // Konstant buff för alla klasser förutom rogue   
    public abstract int SpecialAttackDamage(int enemyDef, Player player);
}