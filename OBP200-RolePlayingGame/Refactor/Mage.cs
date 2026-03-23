namespace OBP200_RolePlayingGame.Refactor;

public class Mage : IClassType
{

    public string Name { get; } = "Mage";
    public double RunAwayChance { get; } = 0.35;
    public (int MaxHp, int Atk, int Def) LevelUpStats { get; } = (MaxHp: 4, Atk: 4, Def: 1);
    public int DmgBuff(Random rng) => 2;
    private int SpecialAttackCost => 3;
    
    
    public int SpecialAttackDamage(SpecialAttackContext cxt)
    {
        if (cxt.TrySpendGold(SpecialAttackCost))
        {
            Console.WriteLine("Mage kastar Fireball!");
            return Math.Max(3, cxt.PlayerAtk + 5 - (cxt.EnemyDef / 2));
        }

        Console.WriteLine("Inte nog med guld för att använda Fireball!");
        return 0;
    }
}