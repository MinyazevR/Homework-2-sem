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
        PointF clockCenter = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
        var radius = Math.Min(pictureBox1.Width, pictureBox1.Height) * 4/5 * 1/2;
        graph.DrawEllipse(new(Brushes.Black, 5), pictureBox1.Width / 2 - radius, pictureBox1.Height / 2 - radius, radius * 2, radius * 2);
        int fontSize = (int)Math.Floor((decimal)radius / 9);
        Matrix matrix = new();

        for (int i = 60; i > 0; i--)
        {
            if (i % 5 == 0)
            {
                graph.DrawString($"{i / 5}", new Font("Arial", fontSize), Brushes.Black, clockCenter.X - fontSize, clockCenter.Y - radius);
                graph.DrawLine(new(Brushes.Black, 5), (int)Math.Floor(clockCenter.X), (int)Math.Floor(clockCenter.Y - radius * 1.94 / 2), (int)Math.Floor(clockCenter.X), (int)Math.Floor(clockCenter.Y - radius));
            }
            else
            {
                graph.DrawLine(new(Brushes.Black, 2), (int)Math.Floor(clockCenter.X), (int)Math.Floor(clockCenter.Y - radius * 1.94 / 2), (int)Math.Floor(clockCenter.X), (int)Math.Floor(clockCenter.Y - radius));

            }

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
        DrawHand(e, Color.Red, DateTime.Now.Second * 6F, 0.6F, 0.01F);
        DrawHand(e, Color.Black, (DateTime.Now.Minute + DateTime.Now.Second / 60f) * 6F, 0.3F, 0.012F);
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