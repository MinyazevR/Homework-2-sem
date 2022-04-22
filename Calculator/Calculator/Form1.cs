namespace Calculator;

public partial class Form1 : Form
{
    private Calculator calculator;

    public Form1()
    {
        InitializeComponent();
        calculator = new Calculator();
    }

    private void Reaction(string text)
    {
        if (calculator.AddOperatorOrOperand(text))
        {
            label1.Text = calculator.Text;
        }
        else
        {
            label1.Text = calculator.Text;
            label2.Text = calculator.GetValue();
        }
    }

    private void AllButtonsOneClick(object sender, EventArgs e)
    {
        Reaction(((Button)sender).Text);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.Enter:
                Reaction("=");
                break;
            case Keys.NumPad0:
                Reaction("0");
                break;
            case Keys.NumPad1:
                Reaction("1");
                break;
            case Keys.NumPad2:
                Reaction("2");
                break;
            case Keys.NumPad3:
                Reaction("3");
                break;
            case Keys.NumPad4:
                Reaction("4");
                break;
            case Keys.NumPad5:
                Reaction("5");
                break;
            case Keys.NumPad6:
                Reaction("6");
                break;
            case Keys.NumPad7:
                Reaction("7");
                break;
            case Keys.NumPad8:
                Reaction("8");
                break;
            case Keys.NumPad9:
                Reaction("9");
                break;
            case Keys.Divide:
                Reaction("/");
                break;
            case Keys.Multiply:
                Reaction("*");
                break;
            case Keys.Add:
                Reaction("+");
                break;
            case Keys.Subtract:
                Reaction("-");
                break;
            case Keys.Delete:
                Reaction(",");
                break;
            case Keys.Back:
                Reaction("⌫");
                break;
        }

        return true;
    }
}