namespace OBP200_RolePlayingGame;

public class Player // Replace array of strings to increases readability and maintainability in program
{
    // Spelarens "databas": alla värden som strängar
    // index: 0 Name, 1 Class, 2 HP, 3 MaxHP, 4 ATK, 5 DEF, 6 GOLD, 7 XP, 8 LEVEL, 9 POTIONS, 10 INVENTORY (semicolon-sep)
    private string Name { get; set; }
    private string Class { get; set; }
    private int Hp { get; set; }
    private int MaxHp { get; set; }
    private int Atk { get; set; }
    private int Def { get; set; }
    private int Gold { get; set; }
    private int Xp { get; set; }
    private int Level { get; set; }
    private int Potions { get; set; }
    private List<string> Inventory { get; set; } // semicolon-sep
    
    public Player(string name, string playerClass, int hp, int maxHp, int atk, int def, int gold, int xp, int level, int potions, List<string> inventory)
    {
        Name = name;
        Class = playerClass;
        Hp = hp;
        MaxHp = maxHp;
        Atk = atk;
        Def = def;
        Gold = gold;
        Xp = xp;
        Level = level;
        Potions = potions;
        Inventory = inventory;
    }
    
}