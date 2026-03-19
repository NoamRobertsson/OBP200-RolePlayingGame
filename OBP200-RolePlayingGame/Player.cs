namespace OBP200_RolePlayingGame;

public class Player // Replace array of strings to increases readability and maintainability in program
{
    // Spelarens "databas": alla värden som strängar
    // index: 0 Name, 1 Class, 2 HP, 3 MaxHP, 4 ATK, 5 DEF, 6 GOLD, 7 XP, 8 LEVEL, 9 POTIONS, 10 INVENTORY (semicolon-sep)
    private string Name { get; set; }
    private string Class { get; set; }
    private int HP { get; set; }
    private int MaxHP { get; set; }
    private int ATK { get; set; }
    private int DEF { get; set; }
    private int GOLD { get; set; }
    private int XP { get; set; }
    private int LEVEL { get; set; }
    private int POTIONS { get; set; }
    private List<string> INVENTORY { get; set; } // semicolon-sep
    
}