namespace OBP200_RolePlayingGame.Refactor.Player;

// Inventory som håller items separat från player-klassen
// Spelaren kan kalla på funktioner i inventory för att lägga till, ta bort och kolla items utan utan att Player eller Program kan se listan
public class Inventory : IInventory
{
    private readonly List<string> _items;
    
    public Inventory(List<string> items){
        _items = items;
    }
    
    public void Add(string name)
    {
        _items.Add(name.Trim());
    }
    
    public void RemoveAll(string name)
    {
        _items.RemoveAll(x => x == name);
    }

    public string Show()
    {
        return string.Join(";", _items);
    }
    
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }
    
    public int NumberOf(string name)
    {
        return _items.Count(x => x == name);
    }
}
    