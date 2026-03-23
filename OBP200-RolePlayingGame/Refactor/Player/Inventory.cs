namespace OBP200_RolePlayingGame;

// Inventory som håller items separat från player-klassen
// Används när spelaren plockar upp eller säljer något
public class Inventory
{
    private List<string> _items = new();
    
    public void Add(string name)
    {
        _items.Add(name);
    }
    
    public bool TryRemove(string name)
    {
        return _items.Remove(name);
    } 
    
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }
    
    public int NumberOf(string name)
    {
        return _items.Count(i => i == name);
    }
}
    