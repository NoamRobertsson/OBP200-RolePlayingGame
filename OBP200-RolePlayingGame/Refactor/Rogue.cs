using System.Security.Cryptography;

namespace OBP200_RolePlayingGame;

public class Rogue : ClassType
{
    public override (int Maxhp, int Atk, int Def) LevelUpStats { get; protected set; } = (3, 3, 1);

    public override int DmgBuff(){
        return (Program.Rng.NextDouble() < 0.2) ? 4 : 0; // rogue crit-chans
    }
    
    public override int SpecialAttackDamage(int enemyDef, bool vsBoss, Player player)
    {
        if (Program.Rng.NextDouble() < 0.5) // 50% chans att träffa
        {
            Console.WriteLine("Rogue utför en lyckad Backstab!");
            return Math.Max(4, player.Atk + 6);
        }

        Console.WriteLine("Backstab misslyckades!");
        return 1;
    }
}