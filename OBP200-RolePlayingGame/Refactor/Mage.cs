namespace OBP200_RolePlayingGame;

public class Mage : ClassType
{

    public override (int Maxhp, int Atk, int Def) LevelUpStats { get; protected set; } = (4, 4, 1);

    public override int DmgBuff() => 2;
    
    public override int SpecialAttackDamage(int enemyDef, bool vsBoss, Player player)
    {
        if (player.Gold >= 3)
        {
            Console.WriteLine("Mage kastar Fireball!");
            player.Gold -= 3;
            return Math.Max(3, player.Atk + 5 - (enemyDef / 2));
        }

        Console.WriteLine("Inte nog med guld för att använda Fireball!");
        return 0;
    }
}