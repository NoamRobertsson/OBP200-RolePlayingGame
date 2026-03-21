namespace OBP200_RolePlayingGame;

public class Warrior : ClassType
{
    public override (int Maxhp, int Atk, int Def) LevelUpStats { get; protected set; } = (6, 2, 2);

    public override int DmgBuff() => 1;
    
    public override int SpecialAttackDamage(int enemyDef, bool vsBoss, Player player)
    {
        Console.WriteLine("Warrior använder Heavy Strike!");
        player.ApplyDamageToPlayer(2); // självskada
        return Math.Max(2, player.Atk + 3 - enemyDef);
    }
}