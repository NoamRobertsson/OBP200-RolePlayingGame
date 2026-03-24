namespace OBP200_RolePlayingGame.Refactor.Player.Shop;

public class BuyArmor : IPurchase
{
    public int Cost => 25;
    public string SuccessMsg => "Du köper bättre rustning.";
    public void Apply(IPurchaseTarget purchase){
        purchase.IncreaseDef();
    }
}