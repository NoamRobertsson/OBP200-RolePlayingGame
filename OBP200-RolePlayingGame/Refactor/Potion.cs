namespace OBP200_RolePlayingGame;

public class Potion : Item, IUsable
{
    private const int HealAmount = 12;
    
    public Potion(string name) : base(name){ }

    public void Use(Player player)
    {
        player.Heal(HealAmount);
    }
}