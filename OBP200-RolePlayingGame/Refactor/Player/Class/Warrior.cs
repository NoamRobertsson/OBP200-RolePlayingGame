namespace OBP200_RolePlayingGame.Refactor.Player.Class;

public class Warrior : IClassType
{
    public string Name => "Warrior";
    public double RunAwayChance => 0.25;

    public (int maxHp, int hp, int atk, int def, int potions, int gold) BaseStats { get; } =
        (maxHp: 40, hp: 40, atk: 7, def: 5, potions: 2, gold: 15);
    public (int MaxHp, int Atk, int Def) LevelUpStats { get; } = (MaxHp: 6, Atk: 2, Def: 2);
    private static int SelfDamage => 2;
    public int DmgBuff(Random rng) => 1;

    
    public int SpecialAttackDamage(SpecialAttackContext cxt)
    {
        Console.WriteLine("Warrior använder Heavy Strike!");
        cxt.TakeDamage(SelfDamage); // självskada
        return Math.Max(2, cxt.PlayerAtk + 3 - cxt.EnemyDef);
    }
}