namespace JDR.Models
{
    public class Boss(
        int x,
        int y,
        int heroLevel,
        string name = "Dragon"
        ) : Monster(x, y, heroLevel, name)
    {
    }
}
