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

    /// <summary>
    /// It is known in advance that there is no wall on the left in the position
    /// </summary>
    [Test]
    public void ShouldPlayerPositionOnXEqualPreviousPositionOnXMinus1WhenOnLeft()
    {
        var (x, y) = game.PlayerPosition();
        game.OnLeft(this, EventArgs.Empty);
        var (z, t) = game.PlayerPosition();
        Assert.AreEqual(z, x - 1);
        Assert.AreEqual(t, y);
    }

    /// <summary>
    /// It is known in advance that there is no wall on the right in the position
    /// </summary>
    [Test]
    public void ShouldPlayerPositionOnXEqualPreviousPositionOnXPlus1WhenOnRight()
    {
        var (x, y) = game.PlayerPosition();
        game.OnRight(this, EventArgs.Empty);
        var (z, t) = game.PlayerPosition();
        Assert.AreEqual(z, x + 1);
        Assert.AreEqual(t, y);
    }

    /// <summary>
    /// It is known in advance that there is no wall on the up in the position
    /// </summary>
    [Test]
    public void ShouldPlayerPositionOnYEqualPreviousPositionOnYMinus1WhenUp()
    {
        for (int i = 0; i < 11; i++)
        {
            game.OnRight(this, EventArgs.Empty);
        }

        var (x, y) = game.PlayerPosition();
        game.Up(this, EventArgs.Empty);
        var (z, t) = game.PlayerPosition();
        Assert.AreEqual(z, x);
        Assert.AreEqual(t, y - 1);
    }

    /// <summary>
    /// It is known in advance that there is no wall on the down in the position
    /// </summary>
    [Test]
    public void ShouldPlayerPositionOnYEqualPreviousPositionOnYPlus1WhenDown()
    {
        for (int i = 0; i < 11; i++)
        {
            game.OnRight(this, EventArgs.Empty);
        }

        game.Up(this, EventArgs.Empty);
        var (x, y) = game.PlayerPosition();
        game.Down(this, EventArgs.Empty);
        var (z, t) = game.PlayerPosition();
        Assert.AreEqual(z, x);
        Assert.AreEqual(t, y + 1);
    }


    /// <summary>
    /// It is known in advance that in the current position there will be a wall on the left
    /// </summary>
    [Test]
    public void ShouldPlayerPositionOnXEqualPreviousPositionOnXWhenOnLeft()
    {
        game.OnLeft(this, EventArgs.Empty);
        var (x, y) = game.PlayerPosition();
        game.OnLeft(this, EventArgs.Empty);
        var (z, t) = game.PlayerPosition();
        Assert.AreEqual(z, x);
        Assert.AreEqual(t, y);
    }

    /// <summary>
    /// It is known in advance that in the current position there will be a wall on the right
    /// </summary>
    [Test]
    public void ShouldPlayerPositionOnXEqualPreviousPositionOnXWhenOnRight()
    {
        for (int i = 0; i < 65; i ++)
        {
            game.OnRight(this, EventArgs.Empty);
        }

        var (x, y) = game.PlayerPosition();
        game.OnRight(this, EventArgs.Empty);
        var (z, t) = game.PlayerPosition();
        Assert.AreEqual(z, x);
        Assert.AreEqual(t, y);
    }

    /// <summary>
    /// It is known in advance that in the current position there will be a wall on the up
    /// </summary>
    [Test]
    public void ShouldPlayerPositionOnXEqualPreviousPositionOnXWhenUp()
    {
        var (x, y) = game.PlayerPosition();
        game.Up(this, EventArgs.Empty);
        var (z, t) = game.PlayerPosition();
        Assert.AreEqual(z, x);
        Assert.AreEqual(t, y);
    }

    /// <summary>
    /// It is known in advance that in the current position there will be a wall on the down
    /// </summary>
    [Test]
    public void ShouldPlayerPositionOnXEqualPreviousPositionOnXWhenDown()
    {
        var (x, y) = game.PlayerPosition();
        game.Down(this, EventArgs.Empty);
        var (z, t) = game.PlayerPosition();
        Assert.AreEqual(z, x);
        Assert.AreEqual(t, y);
    }
}
