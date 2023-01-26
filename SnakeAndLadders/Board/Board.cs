namespace SnakeAndLadders.Board;

public class Board
{
    private List<Obstacle> _obstacles;

    public Board() => _obstacles = new List<Obstacle>();

    public List<Obstacle> GetObstacles() => _obstacles;

    public void SetObstacles(List<Obstacle> obstacles) => _obstacles = obstacles;
    
    public bool IsThereAnObstacle(int position) => _obstacles.Exists(o => o.GetStart() == position);
}