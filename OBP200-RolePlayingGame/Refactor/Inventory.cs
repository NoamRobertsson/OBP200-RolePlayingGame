namespace OBP200_RolePlayingGame;

public class Inventory
{
    private List<string> _equipment = new();
    private int Potions { get; set; }
    private int MinorGems { get; set; }
    

    //Add 1 for integers and add item name to equipment list if theres a string, can be used for loot or shop interactions
    public void Add(ItemID id, string? name = null)
    {
        switch(id){
            case ItemID.Potion:
                Potions++;
                break;
            
            case ItemID.MinorGem:
                MinorGems++;
                break;
            
            case ItemID.Equipment:
                if (name == null) return;
                _equipment.Add(name);
                break;
        }
    }

// return true to check for removal success, can be used when buying/selling items or using potions
    public bool Remove(ItemID id)
    {
        switch (id)
        {
            case ItemID.Potion:
                if (Potions > 0)
                {
                    Potions--;
                    return true;
                }
                return false;

            case ItemID.MinorGem:
                if (MinorGems > 0)
                {
                    MinorGems--;
                    return true;
                }
                return false;
            
            default: return false;
        }
    } 
}
    