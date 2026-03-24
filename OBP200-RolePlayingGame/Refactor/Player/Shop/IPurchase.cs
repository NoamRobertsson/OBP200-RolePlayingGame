namespace OBP200_RolePlayingGame.Refactor.Player;

public interface IPurchase
{
    int Cost { get; }
    string SuccessMsg { get; }
    public void Apply(IPurchaseTarget purchase);
}
            