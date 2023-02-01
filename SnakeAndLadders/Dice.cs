namespace SnakeAndLadders;

public abstract class Dice
{
    public static int Roll(int seed) => new Random(seed).Next(1, 7);

    public static int Roll() => new Random().Next(1, 7);
}