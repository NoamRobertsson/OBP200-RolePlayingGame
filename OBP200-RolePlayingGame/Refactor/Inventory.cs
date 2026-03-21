namespace OBP200_RolePlayingGame;

public class Inventory
{
    private List<string> _equipment = new();
    private int Potions { get; set; }
    private int MinorGems { get; set; }
    

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

// remove item from inventory, can be used when buying/selling items or using potions
    public void Remove(ItemID id)
    {
        switch (id)
        {
            case ItemID.Potion:
                if (Potions > 0) Potions--;
                break;

            case ItemID.MinorGem:
                if (MinorGems > 0) MinorGems--;
                break;
        }
    }

    //Get sale price of item and remove it from inventory

    }

}