namespace OBP200_RolePlayingGame.Refactor.Player.Shop;

public interface IPurchaseTarget
{
    void AddPotion(int amount = 1);
    void IncreaseAtk(int amount = 2);
    void IncreaseDef(int amount = 2);
}