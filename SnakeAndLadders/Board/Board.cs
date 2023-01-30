namespace SnakeAndLadders.Board;

public class Board
{
    private List<Obstacle> _obstacles;

    public Board()
    {
        _obstacles = new List<Obstacle>();
        _obstacles.AddRange(new []
        {
            new Obstacle(4, 14),
            new Obstacle(9, 31),
            new Obstacle(16, 6),
            new Obstacle(21, 42),
            new Obstacle(28, 84),
            new Obstacle(33, 11),
            new Obstacle(36, 44),
            new Obstacle(47, 26),
            new Obstacle(51, 67),
            new Obstacle(56, 49),
            new Obstacle(62, 19),
            new Obstacle(64, 60),
            new Obstacle(71, 91),
            new Obstacle(80, 99),
            new Obstacle(87, 24),
            new Obstacle(93, 73),
            new Obstacle(95, 75)
        });
    }

    public List<Obstacle> GetObstacles() => _obstacles;

    public void SetObstacles(List<Obstacle> obstacles) => _obstacles = obstacles;
    
    public bool IsThereAnObstacle(int position) => _obstacles.Exists(o => o.GetStart() == position);
}