namespace Game;

/// <summary>
/// The class responsible for the logic of the game
/// </summary>
public class Game
{
    private readonly Action<int, int> controlFunction;
    private int currentPositionOnX;
    private int currentPositionOnY;
    private readonly string[] map;

    /// <summary>
    /// Сonstructor of Game class
    /// </summary>
    /// <param name="initialPositionOnX">Initial position on x</param>
    /// <param name="initialPositionOnY">Initial position on y</param>
    /// <param name="pathToFile">Path to file</param>
    /// <param name="action">Control function</param>
    public Game(int initialPositionOnX, int initialPositionOnY, string pathToFile, Action <int, int> action)
    {
        currentPositionOnX = initialPositionOnX;
        currentPositionOnY = initialPositionOnY;
        map = File.ReadAllLines(pathToFile);
        this.controlFunction = action;
        PrintMap(this.map);
        action(currentPositionOnX, currentPositionOnY);
        DrawCharacter();
    }

    private static void DrawCharacter() => Console.WriteLine("@");

    private static void PrintMap(string[] map)
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

    private void ChangePlayerPosition(Func<int, int, (int, int)> func)
    {
        var (newPositionOnX, newPositionOnY) = func(currentPositionOnX, currentPositionOnY);
        controlFunction(newPositionOnX, newPositionOnY);
        if (IsWall(map[newPositionOnY][newPositionOnX]))
        {
            controlFunction(currentPositionOnX, currentPositionOnY);
            return;
        }

        Console.Write("@");
        controlFunction(currentPositionOnX, currentPositionOnY);
        Console.WriteLine(" ");
        controlFunction(newPositionOnX, newPositionOnY);
        (currentPositionOnX, currentPositionOnY) = (newPositionOnX, newPositionOnY);
    }

    /// <summary>
    /// Function for changing the player's position one step to the left
    /// </summary>
    public void OnLeft(object? sender, EventArgs args) => ChangePlayerPosition((x, y) => (x - 1, y));

    /// <summary>
    /// Function for changing the player's position one step to the right
    /// </summary>
    public void OnRight(object? sender, EventArgs args) => ChangePlayerPosition((x, y) => (x + 1, y));

    /// <summary>
    /// Function for changing the player's position one step up
    /// </summary>
    public void Up(object? sender, EventArgs args) => ChangePlayerPosition((x, y) => (x, y - 1));

    /// <summary>
    /// Function for changing the player's position one step down
    /// </summary>
    public void Down(object? sender, EventArgs args) => ChangePlayerPosition((x, y) => (x, y + 1));

    /// <summary>
    /// Function for getting the player's position
    /// </summary>
    /// <returns>Player position</returns>
    public (int, int) PlayerPosition() => (currentPositionOnX, currentPositionOnY);

    /// <summary>
    /// A function that determines whether the game is completed or not
    /// </summary>
    /// <returns>True if passed</returns>
    public bool IsTheEndOfTheGame() => (currentPositionOnX, currentPositionOnY) == (68, 4); // Magic 68 and 4 are the coordinates of the point you need to reach in order to win
}