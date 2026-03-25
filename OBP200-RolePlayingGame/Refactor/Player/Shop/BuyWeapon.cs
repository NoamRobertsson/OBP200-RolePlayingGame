namespace OBP200_RolePlayingGame.Refactor.Player.Shop;

public class BuyWeapon : IPurchase
{
        public int Cost => 25;
        public string SuccessMsg => "Du köper ett bättre vapen.";
        public void Apply(IPurchaseTarget target)
        {
            target.IncreaseAtk();
        }
}