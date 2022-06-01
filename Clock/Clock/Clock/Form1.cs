namespace Clock;
using System.Drawing.Drawing2D;

public partial class Form1 : Form 
{
    public Form1() 
    {
        InitializeComponent();
    }

    private void DrawClock(Graphics graph)
    {
        // The center of the clock will be in the center of the shape
        PointF clockCenter = new(pictureBox1.Width / 2, pictureBox1.Height / 2);

        // Multiply by 4/5 so that the clock does not go beyond the form, but at the same time occupies most of the form
        var radius = Math.Min(pictureBox1.Width, pictureBox1.Height) * 4/5 * 1/2;

        // Draw clock
        graph.DrawEllipse(new(Brushes.Black, 5), pictureBox1.Width / 2 - radius, pictureBox1.Height / 2 - radius, radius * 2, radius * 2);

        // If the counter is divided by 5, then draw a thick hour mark and a number
        int fontSize = (int)Math.Floor((decimal)radius / 9);
        Matrix matrix = new();

        for (int i = 60; i > 0; i--)
        {
            // if the counter is divided by 5, then draw a thick hour mark and a number
            if (i % 5 == 0)
            {
                graph.DrawString($"{i / 5}", new Font("Arial", fontSize), Brushes.Black, clockCenter.X - fontSize, clockCenter.Y - radius);
                graph.DrawLine(new(Brushes.Black, 5), (int)Math.Floor(clockCenter.X), (int)Math.Floor(clockCenter.Y - radius * 1.94 / 2), (int)Math.Floor(clockCenter.X), (int)Math.Floor(clockCenter.Y - radius));
            }
            else
            {
                // Draw a minute mark
                graph.DrawLine(new(Brushes.Black, 2), (int)Math.Floor(clockCenter.X), (int)Math.Floor(clockCenter.Y - radius * 1.94 / 2), (int)Math.Floor(clockCenter.X), (int)Math.Floor(clockCenter.Y - radius));

            }

            // We change the angle by -6 (that is, we reduce the minute)
            matrix.RotateAt(-6.0F, clockCenter);
            graph.Transform = matrix;
        }
    }


    private void DrawHand(Graphics graph, Color color, float angleRelativeStartingPoint, float length, float width)
    {
        PointF clockCenter = new(pictureBox1.Width / 2, pictureBox1.Height / 2);
        var radius = Math.Min(pictureBox1.Width, pictureBox1.Height) * 4 / 5 * 1 / 2;
        Matrix matrix = new();
        matrix.RotateAt(angleRelativeStartingPoint, clockCenter);
        graph.Transform = matrix;
        graph.DrawLine(new(color, radius * width), clockCenter, new(clockCenter.X, radius * (1 - length)));
    }

    private void DrawAllHands(Graphics e)
    {
        // draw the second hand
        DrawHand(e, Color.Red, DateTime.Now.Second * 6F, 0.6F, 0.01F);

        // draw the minute hand
        DrawHand(e, Color.Black, (DateTime.Now.Minute + DateTime.Now.Second / 60f) * 6F, 0.3F, 0.012F);

        // draw the hour hand
        DrawHand(e, Color.Black, (DateTime.Now.Hour + DateTime.Now.Minute / 60f + DateTime.Now.Second / 3600f) * 30F, 0.2F, 0.015F);
    }

    private void PictureBoxPaint(object sender, PaintEventArgs e)
    {
        DrawClock(e.Graphics);
        DrawAllHands(e.Graphics);
    }

    private void TimerTick(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
}