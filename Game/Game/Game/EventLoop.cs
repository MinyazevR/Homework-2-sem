namespace Game;

using System;

/// <summary>
/// A class representing an event handler loop
/// </summary>
public class EventLoop
{
    /// <summary>
    /// Handler for the left move event
    /// </summary>
    public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

    /// <summary>
    /// Handler for the right move event
    /// </summary>
    public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

    /// <summary>
    /// Handler for the up move event
    /// </summary>
    public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

    /// <summary>
    /// Handler for the down move event
    /// </summary>
    public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

    /// <summary>
    /// Event handler loop
    /// </summary>
    /// <param name="EndOfСycleСondition">Delegate loop exit condition</param>
    public void Run(Func<bool> EndOfСycleСondition)
    {
        while (!EndOfСycleСondition())
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                {
                    LeftHandler(this, EventArgs.Empty);
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    RightHandler(this, EventArgs.Empty);
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    UpHandler(this, EventArgs.Empty);
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    DownHandler(this, EventArgs.Empty);
                    break;
                }
                case ConsoleKey.Escape:
                {
                    return;
                }
            }
        }
    }
}

