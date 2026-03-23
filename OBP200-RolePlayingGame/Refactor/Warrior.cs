namespace OBP200_RolePlayingGame.Refactor;

public class Warrior : IClassType
{
    public string Name { get; } = "Warrior";
    public double RunAwayChance { get; } = 0.2;
    public (int MaxHp, int Atk, int Def) LevelUpStats { get; } = (MaxHp: 6, Atk: 2, Def: 2);
    private int SelfDamage => 2;
    public int DmgBuff(Random rng) => 1;

    
    public int SpecialAttackDamage(SpecialAttackContext cxt)
    {
        Console.WriteLine("Warrior använder Heavy Strike!");
        cxt.TakeDamage(SelfDamage); // självskada
        return Math.Max(2, cxt.PlayerAtk + 3 - cxt.EnemyDef);
    }
}