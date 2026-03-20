namespace OBP200_RolePlayingGame.Inventory;

public abstract class Item
{ 
    public string Name { get; protected set; }

    public Item(string name)
    {
        Name = name;
    }
}