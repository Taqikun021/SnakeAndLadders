namespace SnakeAndLadders;

public class Dice
{
    private int _numberOfDice = 2;
    public static int Roll(int seed) => new Random(seed).Next(1, 7);
    
    public static int Roll() => new Random().Next(1, 7);

    public void SetDice(int number) => _numberOfDice = number;

    public int GetNumberOfDice() => _numberOfDice;
}