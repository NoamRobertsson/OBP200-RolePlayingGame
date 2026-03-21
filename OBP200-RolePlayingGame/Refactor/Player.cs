namespace OBP200_RolePlayingGame;

public class Player // Replace array of strings to increases readability and maintainability in program
{
    // Spelarens "databas": alla värden som strängar
    // index: 0 Name, 1 Class, 2 HP, 3 MaxHP, 4 ATK, 5 DEF, 6 GOLD, 7 XP, 8 LEVEL, 9 POTIONS, 10 INVENTORY (semicolon-sep)
    private string Name { get; set; }
    private ClassType Class { get; set; }
    private int Hp { get; set; }
    private int MaxHp { get; set; }
    public int Atk { get; private set; }
    private int Def { get; set; }
    public int Gold { get; set; }
    private int Xp { get; set; }
    private int Level { get; set; }
    private Inventory Inventory { get; set; } // semicolon-sep
    
    public Player(string name, ClassType playerClass, int hp, int maxHp, int atk, int def, int gold, int xp, int level, int potions, Inventory inventory)
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
        Inventory = inventory;
    }

    public void HealPlayer(int amount)
    {
        Inventory.Remove(ItemID.Potion);
        Hp += amount;
        if (Hp > MaxHp) Hp = MaxHp;
    }
        public int UseClassSpecial(int enemyDef, bool vsBoss)
    {
        //Hämta klassens SpecialAttackDamage
        int specialDmg = Class.SpecialAttackDamage(enemyDef, this);& "C:\Users\noamr\RiderProjects\OBP200-RolePlayingGame\OBP200-RolePlayingGame\bin\Debug\net10.0\OBP200-RolePlayingGame.exe"
        
        // Dämpa skada mot bossen
        if (vsBoss)
        {
            specialDmg = (int)Math.Round(specialDmg * 0.8);
        }

        return Math.Max(0, specialDmg);
    }
    
    public void ApplyDamageToPlayer(int dmg)
    {
        HP -= Math.Max(0, dmg); // Apply damage without negatives to prevent healing
        HP = Math.Max(0, HP); // set to 0 if HP goes negative and player is dead
    }

    public int CalculatePlayerDamage(int enemyDef)
    {

        // Beräkna grundskada
        int baseDmg = Math.Max(1, Atk - (enemyDef / 2));
        int roll = Program.Rng.Next(0, 3); // liten variation
        
        //lägg till klass-buff
        baseDmg += Class.

        return Math.Max(1, baseDmg + roll);
    }

    public void UsePotion()
    {
        // Ta bort en dryck från inventory och meddela om det inte finns några kvar
        var potionIsRemoved = Inventory.Remove(ItemID.Potion);
        // Helning av spelaren
        if (!potionIsRemoved)
        {
            Console.WriteLine("Du har inga drycker kvar.");
        }
        else
        {
            int previousHp = Hp;
            int heal = 12;
            HealPlayer(heal);
            Console.WriteLine($"Du dricker en dryck och återfår {Hp - previousHp} HP.");
        }
        
    }

    public bool TryRunAway()
    {
        // Flyktschans baserad på karaktärsklass
        double chance = 0.25;
        if (Class == "Rogue") chance = 0.5;
        if (cls == "Mage") chance = 0.35;
        return Rng.NextDouble() < chance;
    }

    public static bool IsPlayerDead()
    {
        return ParseInt(Player[2], 0) <= 0;
    }

    public static void AddPlayerXp(int amount)
    {
        int xp = ParseInt(Player[7], 0) + Math.Max(0, amount);
        Player[7] = xp.ToString();
        MaybeLevelUp();
    }

    public static void AddPlayerGold(int amount)
    {
        int gold = ParseInt(Player[6], 0) + Math.Max(0, amount);
        Player[6] = gold.ToString();
    }

    public static void TryBuy(int cost, Action apply, string successMsg)
    {
        int gold = ParseInt(Player[6], 0);
        if (gold >= cost)
        {
            Player[6] = (gold - cost).ToString();
            apply();
            Console.WriteLine(successMsg);
        }
        else
        {
            Console.WriteLine("Du har inte råd.");
        }
    }

    private static void MaybeLevelUp()
    {
        // Nivåtrösklar
        int xp = ParseInt(Player[7], 0);
        int lvl = ParseInt(Player[8], 1);
        int nextThreshold = lvl == 1 ? 10 : (lvl == 2 ? 25 : (lvl == 3 ? 45 : lvl * 20));

        if (xp >= nextThreshold)
        {
            Player[8] = (lvl + 1).ToString();

            // Uppgradering baserad på karaktärsklass
            string cls = Player[1] ?? "Warrior";
            int maxhp = ParseInt(Player[3], 1);
            int atk = ParseInt(Player[4], 1);
            int def = ParseInt(Player[5], 0);

            switch (cls)
            {
                case "Warrior":
                    maxhp += 6; atk += 2; def += 2;
                    break;
                case "Mage":
                    maxhp += 4; atk += 4; def += 1;
                    break;
                case "Rogue":
                    maxhp += 5; atk += 3; def += 1;
                    break;
                default:
                    maxhp += 4; atk += 3; def += 1;
                    break;
            }

            Player[3] = maxhp.ToString();
            Player[4] = atk.ToString();
            Player[5] = def.ToString();
            Player[2] = maxhp.ToString(); // full heal vid level up

            Console.WriteLine($"Du når nivå {lvl + 1}! Värden ökade och HP återställd.");
        }
    }

    public static void MaybeDropLoot(string enemyName)
    {
        // Enkel loot-regel
        if (Rng.NextDouble() < 0.35)
        {
            string item = "Minor Gem";
            if (enemyName.Contains("Urdraken")) item = "Dragon Scale";

            var inv = (Player[10] ?? "").Trim();
            if (string.IsNullOrEmpty(inv)) Player[10] = item;
            else Player[10] = inv + ";" + item;

            Console.WriteLine($"Föremål hittat: {item} (lagt i din väska)");
        }
    }

    public static bool DoTreasure()
    {
        Console.WriteLine("Du hittar en gammal kista...");
        if (Rng.NextDouble() < 0.5)
        {
            int gold = Rng.Next(8, 15);
            AddPlayerGold(gold);
            Console.WriteLine($"Kistan innehåller {gold} guld!");
        }
        else
        {
            var items = new[] { "Iron Dagger", "Oak Staff", "Leather Vest", "Healing Herb" };
            string found = items[Rng.Next(items.Length)];
            var inv = (Player[10] ?? "").Trim();
            Player[10] = string.IsNullOrEmpty(inv) ? found : (inv + ";" + found);
            Console.WriteLine($"Du plockar upp: {found}");
        }
        return true;
    }

    public static void SellMinorGems()
    {
        var inv = (Player[10] ?? "");
        if (string.IsNullOrWhiteSpace(inv))
        {
            Console.WriteLine("Du har inga föremål att sälja.");
            return;
        }

        var items = inv.Split(';').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        int count = items.Count(x => x == "Minor Gem");
        if (count == 0)
        {
            Console.WriteLine("Inga 'Minor Gem' i väskan.");
            return;
        }

        items = items.Where(x => x != "Minor Gem").ToList();
        Player[10] = items.Count == 0 ? "" : string.Join(";", items);

        AddPlayerGold(count * 5);
        Console.WriteLine($"Du säljer {count} st Minor Gem för {count * 5} guld.");
    }

    public static void ShowStatus()
    {
        Console.WriteLine($"[{Player[0]} | {Player[1]}]  HP {Player[2]}/{Player[3]}  ATK {Player[4]}  DEF {Player[5]}  LVL {Player[8]}  XP {Player[7]}  Guld {Player[6]}  Drycker {Player[9]}");
        var inv = (Player[10] ?? "");
        if (!string.IsNullOrWhiteSpace(inv))
        {
            Console.WriteLine($"Väska: {inv}");
        }
    }

    public static bool DoRest()
    {
        Console.WriteLine("Du slår läger och vilar.");
        int maxhp = Program.ParseInt(Player[3], 1);
        Player[2] = maxhp.ToString();
        Console.WriteLine("HP återställt till max.");
        return true;
    }
}