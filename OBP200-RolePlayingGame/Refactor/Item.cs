namespace OBP200_RolePlayingGame;

public abstract class Item
{ 
    public string Name { get; protected set; }

    protected Item(string name)
    {
        Name = name;
    }
}