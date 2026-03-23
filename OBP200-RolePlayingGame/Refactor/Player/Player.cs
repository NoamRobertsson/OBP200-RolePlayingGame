using OBP200_RolePlayingGame.Refactor.Player.Class;

namespace OBP200_RolePlayingGame.Refactor.Player;

//Player klass som ersätter arrayen i program. Den innehåller spelarens värden som attribut och hanterar logiken som relaterar till spelaren
public class Player // 
{
    // Spelarens "databas": alla värden som strängar
    // index: 0 Name, 1 Class, 2 HP, 3 MaxHP, 4 ATK, 5 DEF, 6 GOLD, 7 XP, 8 LEVEL, 9 POTIONS, 10 INVENTORY (semicolon-sep)
    private string Name { get; set; }
    private IClassType Class { get; set; }
    private int Hp { get; set; }
    private int MaxHp { get; set; }
    private int Atk { get; set; }
    private int Def { get; set; }
    private int Exp { get; set; }
    private int Level { get; set; }
    private int Gold { get; set; }
    private int Potions { get; set; }
    private Inventory Inventory { get; } // semicolon-sep
    
    public Player(string name, IClassType playerClass, int hp, int maxHp, int atk, int def, int gold, int xp, int level, int potions, Inventory inventory)
    {
        Name = name;
        Class = playerClass;
        Hp = hp;
        MaxHp = maxHp;
        Atk = atk;
        Def = def;
        Exp = xp;
        Level = level;
        Gold = gold;
        Potions = potions;
        Inventory = inventory;
    }
    

    public void Heal(int amount = 12)
    {
        Hp += amount;
        if (Hp > MaxHp) Hp = MaxHp;
    }
        public int UseClassSpecial(int enemyDef, bool vsBoss, Random rng)
    {
        //Lagra spelarinformationen klassen behöver för att beräkna specialattacken
        var context = new SpecialAttackContext()
        {
            PlayerAtk = Atk,
            Rng = rng,
            TrySpendGold = TrySpendGold,
            TakeDamage = TakeDamage,
            EnemyDef = enemyDef
        };
        
         var specialDmg = Class.SpecialAttackDamage(context);
         
        // Dämpa skada mot bossen
        if (vsBoss)
        {
            specialDmg = (int)Math.Round(specialDmg * 0.8);
        }

        return Math.Max(0, specialDmg);
    }
    
    public void TakeDamage(int dmg)
    {
        Hp -= Math.Max(0, dmg); 
        Hp = Math.Max(0, Hp);
    }

    public int CalculatePlayerDamage(int enemyDef, Random rng)
    {

        // Beräkna grundskada
        int baseDmg = Math.Max(1, Atk - (enemyDef / 2));
        int roll = rng.Next(0, 3); // liten variation
        
        //lägg till klass-buff
        baseDmg += Class.DmgBuff(rng);

        return Math.Max(1, baseDmg + roll);
    }

    public void UsePotion()
    {
        // Ta bort en dryck från inventory och meddela om det inte finns några kvar
        if (Potions <= 0)
        {
            Console.WriteLine("Du har inga drycker kvar.");
        }
        else
        {
            int previousHp = Hp;
            int heal = 12;
            Heal(heal); // Helning av spelaren
            Console.WriteLine($"Du dricker en dryck och återfår {Hp - previousHp} HP.");
        }
        
    }

    public bool TryRunAway(Random rng)
    {
        // Flyktschans baserad på karaktärsklass
        double chance = Class.RunAwayChance;
        return rng.NextDouble() < chance;
    }

    public bool IsDead()
    {
        return Hp <= 0;
    }

    public void AddExp(int amount)
    {
        Exp += Math.Max(0, amount);
        MaybeLevelUp();
    }

    public void AddGold(int amount)
    {
        Gold += Math.Max(0, amount);
    }

    public void TryBuy(int cost, Action apply, string successMsg)
    {
        if (TrySpendGold(cost))
        {
            apply();
            Console.WriteLine(successMsg);
        }
        else
        {
            Console.WriteLine("Du har inte råd.");
        }
    }

    public bool TrySpendGold(int cost)
    {
        if (Gold >= cost)
        {
            Gold -= cost;
            return true;
        }

        return false;
    }

    private void MaybeLevelUp()
    {
        // Nivåtrösklar
        int nextThreshold = Level == 1 ? 10 : (Level == 2 ? 25 : (Level == 3 ? 45 : Level * 20));

        if (Exp >= nextThreshold)
        {
            Level += 1;

            // Uppgradering baserad på karaktärsklass
            var (maxhp, atk, def) = Class.LevelUpStats;
            MaxHp += maxhp;
            Atk += atk;
            Def += def;
            Hp = MaxHp; // full heal vid level up

            Console.WriteLine($"Du når nivå {Level}! Värden ökade och HP återställd.");
        }
    }

    public void MaybeDropLoot(string enemyName)
    {
        // Enkel loot-regel
        if (Rng.NextDouble() < 0.35)
        {
            string item = "Minor Gem";
            if (enemyName.Contains("Urdraken")) item = "Dragon Scale";

            var inv = (Player[10] ?? "").Trim();
            if (string.IsNullOrEmpty(inv)) Player[10] = item;
            else Inventory.Add(item);

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

    public void SellMinorGems()
    {
        if (Inventory.IsEmpty())
        {
            Console.WriteLine("Du har inga föremål att sälja.");
            return;
        }


        int count = Inventory.NumberOf("Minor Gem");
        if (count == 0)
        {
            Console.WriteLine("Inga 'Minor Gem' i väskan.");
            return;
        }
        
        Inventory.RemoveAll("Minor Gem");
        AddGold(count * 5);
        Console.WriteLine($"Du säljer {count} st Minor Gem för {count * 5} guld.");
    }

    public void ShowStatus()
    {
        Console.WriteLine($"[{Name} | {Class}]  HP {Hp}/{MaxHp}  ATK {Atk}  DEF {Def}  LVL {Level}  XP {Exp}  Guld {Gold}  Drycker {Potions}");
        if (!Inventory.IsEmpty())
        {
            Console.WriteLine($"Väska: {Inventory.Show()}");
        }
    }

    public bool DoRest()
    {
        Console.WriteLine("Du slår läger och vilar.");
        Hp = MaxHp;
        Console.WriteLine("HP återställt till max.");
        return true;
    }
}