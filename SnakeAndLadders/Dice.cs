namespace SnakeAndLadders;

public class Dice
{
    public static int Roll()
    {
        Thread.Sleep(2000);
        return new Random().Next(1, 6);
    }
}