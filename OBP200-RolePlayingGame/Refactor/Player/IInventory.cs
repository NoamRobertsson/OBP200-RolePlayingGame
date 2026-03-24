namespace OBP200_RolePlayingGame.Refactor.Player;

public interface IInventory
{
    void Add(string name);
    void RemoveAll(string name);    
    int NumberOf(string name);
    bool IsEmpty();
    string Show();

}