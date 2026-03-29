namespace OBP200_RolePlayingGame.Refactor.Player.Class;
public class Rogue : IClassType
{
    public string Name { get; } = "Rogue";
    public double RunAwayChance { get; } = 0.5;
    public(int maxHp, int hp, int atk, int def, int potions, int gold) BaseStats { get; } =
        (maxHp: 32, hp: 32, atk: 8, def: 3, potions: 3, gold: 20);
    public (int MaxHp, int Atk, int Def) LevelUpStats { get; } = (MaxHp: 5, Atk: 3, Def: 1);

    public int DmgBuff(Random rng){
        return (rng.NextDouble() < 0.2) ? 4 : 0; // rogue crit-chans
    }
    
    public int SpecialAttackDamage(SpecialAttackContext cxt)
    {
        if (cxt.Rng.NextDouble() < 0.5) // 50% chans att ignorera enemyDef
        {
            Console.WriteLine("Rogue utför en lyckad Backstab!");
            return Math.Max(4, cxt.PlayerAtk + 6);
        }

        Console.WriteLine("Backstab misslyckades!");
        return 1;
    }
}