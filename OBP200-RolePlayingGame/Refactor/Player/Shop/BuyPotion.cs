namespace OBP200_RolePlayingGame.Refactor.Player.Shop;

public class BuyPotion : IPurchase
{
    public int Cost => 10;
    public string SuccessMsg => "Du köper en dryck.";
    
    public void Apply(IPurchaseTarget target)
    {
        target.AddPotion();
    }
}