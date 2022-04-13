namespace Game;

public class Game
{
    private readonly Action<int, int> action;
    private int currentPositionOnX { get; set; }
    private int currentPositionOnY { get; set; }
    private string[] map { get; set; }

    public Game(int initialPositionOnX, int initialPositionOnY, string pathToFile, Action <int, int> action)
    {
        currentPositionOnX = initialPositionOnX;
        currentPositionOnY = initialPositionOnY;
        map = File.ReadAllLines(pathToFile);
        this.action = action;
        PrintMap(this.map);
        action(currentPositionOnX, currentPositionOnY);
        DrawCharacter();
    }


    private void DrawCharacter()
    {
        Console.WriteLine("@");
    }

    private void PrintMap(string[] map)
    {
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                Console.Write(map[i][j]);
            }
            Console.WriteLine();
        }
    }

    private static bool IsWall(char x) => x == '|' || x == '+' || x == '-' || x == '_';

    public void Move(Func<int, int, (int, int)> func)
    {
        var (newPositionOnX, newPositionOnY) = func(currentPositionOnX, currentPositionOnY);
        action(newPositionOnX, newPositionOnY);
        if (IsWall(map[newPositionOnY][newPositionOnX]))
        {
            action(currentPositionOnX, currentPositionOnY);
            return;
        }
        Console.Write("@");
        action(currentPositionOnX, currentPositionOnY);
        Console.WriteLine(" ");
        action(newPositionOnX, newPositionOnY);
        (currentPositionOnX, currentPositionOnY) = (newPositionOnX, newPositionOnY);
    }

    public void OnLeft(object? sender, EventArgs args)
    {
        Move((x, y) => (x - 1, y));
    }

    public void OnRight(object? sender, EventArgs args)
    {
        Move((x, y) => (x + 1, y));
    }

    public void Up(object? sender, EventArgs args)
    {
        Move((x, y) => (x, y - 1));
    }

    public void Down(object? sender, EventArgs args)
    {
        Move((x, y) => (x, y + 1));
    }

    public (int, int) PlayerPosition() => (currentPositionOnX, currentPositionOnY);
}