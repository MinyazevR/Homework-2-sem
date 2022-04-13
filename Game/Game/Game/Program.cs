namespace Game;

public class Program
{
    static void Main(string[] args)
    {
        var eventLoop = new EventLoop();

        var game = new Game(2, 9, "..//..//..//Game.txt", Console.SetCursorPosition);
        eventLoop.LeftHandler += game.OnLeft;
        eventLoop.RightHandler += game.OnRight;
        eventLoop.UpHandler += game.Up;
        eventLoop.DownHandler += game.Down;
        eventLoop.Run();
    }
}

