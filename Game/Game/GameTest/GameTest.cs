namespace GameTest;

using NUnit.Framework;
using System.IO;
using System;

public class Tests
{ 
    private Game.Game game = new(0 ,0, "..//..//..//..//Game//Game.txt", (x, y) => { } );

    [SetUp]
    public void Setup()
    {
        game = new Game.Game(2, 9, "..//..//..//..//Game//Game.txt", (x, y) => { });
    }

    [Test]
    public void Test1()
    {
        var (x, y) = game.PlayerPosition();
        game.OnLeft(this, EventArgs.Empty);
        var (z, t) = game.PlayerPosition();
        Assert.AreEqual(z, x - 1);
    }

}
