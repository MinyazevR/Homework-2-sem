using Game;

var eventLoop = new EventLoop();
var game = new Game.Game(2, 9, "..//..//..//Game.txt", Console.SetCursorPosition);
eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRight;
eventLoop.UpHandler += game.Up;
eventLoop.DownHandler += game.Down;
eventLoop.Run(game.IsTheEndOfTheGame);