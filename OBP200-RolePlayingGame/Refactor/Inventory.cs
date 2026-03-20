namespace OBP200_RolePlayingGame;

public class Inventory
{
    private List<Item> _items = new();

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
    }
}