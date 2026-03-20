namespace OBP200_RolePlayingGame;

public class MinorGem : Item, ISellable
{
    private const int SellValue = 5;
    
    public MinorGem(string name) : base(name){ }

    public int GetSellPrice()
    {
        return SellValue;
    }
}