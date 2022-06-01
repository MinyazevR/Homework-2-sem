namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Multiplication = new System.Windows.Forms.Button();
            this.Subtraction = new System.Windows.Forms.Button();
            this.Addition = new System.Windows.Forms.Button();
            this.Zero = new System.Windows.Forms.Button();
            this.One = new System.Windows.Forms.Button();
            this.Comma = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.Three = new System.Windows.Forms.Button();
            this.Four = new System.Windows.Forms.Button();
            this.Seven = new System.Windows.Forms.Button();
            this.Root = new System.Windows.Forms.Button();
            this.Five = new System.Windows.Forms.Button();
            this.Six = new System.Windows.Forms.Button();
            this.Eight = new System.Windows.Forms.Button();
            this.Nine = new System.Windows.Forms.Button();
            this.PlusMinus = new System.Windows.Forms.Button();
            this.Division = new System.Windows.Forms.Button();
            this.Equally = new System.Windows.Forms.Button();
            this.Erase = new System.Windows.Forms.Button();
            this.EraseEverything = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.Multiplication, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Subtraction, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Addition, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.Zero, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.One, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Comma, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Two, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Three, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Four, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Seven, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Root, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Five, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Six, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Eight, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Nine, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.PlusMinus, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Division, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.Equally, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Erase, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.EraseEverything, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 143);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 373);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Multiplication
            // 
            this.Multiplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Multiplication.Location = new System.Drawing.Point(309, 77);
            this.Multiplication.Name = "Multiplication";
            this.Multiplication.Size = new System.Drawing.Size(97, 68);
            this.Multiplication.TabIndex = 15;
            this.Multiplication.Text = "*";
            this.Multiplication.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Multiplication.UseVisualStyleBackColor = true;
            this.Multiplication.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Subtraction
            // 
            this.Subtraction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Subtraction.Location = new System.Drawing.Point(309, 151);
            this.Subtraction.Name = "Subtraction";
            this.Subtraction.Size = new System.Drawing.Size(97, 68);
            this.Subtraction.TabIndex = 11;
            this.Subtraction.Text = "-";
            this.Subtraction.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Subtraction.UseVisualStyleBackColor = true;
            this.Subtraction.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Addition
            // 
            this.Addition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Addition.Location = new System.Drawing.Point(309, 225);
            this.Addition.Name = "Addition";
            this.Addition.Size = new System.Drawing.Size(97, 68);
            this.Addition.TabIndex = 7;
            this.Addition.Text = "+";
            this.Addition.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Addition.UseVisualStyleBackColor = true;
            this.Addition.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Zero
            // 
            this.Zero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Zero.Location = new System.Drawing.Point(3, 299);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(96, 71);
            this.Zero.TabIndex = 0;
            this.Zero.Text = "0";
            this.Zero.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Zero.UseVisualStyleBackColor = true;
            this.Zero.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // One
            // 
            this.One.Dock = System.Windows.Forms.DockStyle.Fill;
            this.One.Location = new System.Drawing.Point(3, 225);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(96, 68);
            this.One.TabIndex = 4;
            this.One.Tag = "";
            this.One.Text = "1";
            this.One.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.One.UseVisualStyleBackColor = true;
            this.One.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Comma
            // 
            this.Comma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Comma.Location = new System.Drawing.Point(105, 299);
            this.Comma.Name = "Comma";
            this.Comma.Size = new System.Drawing.Size(96, 71);
            this.Comma.TabIndex = 1;
            this.Comma.Text = ",";
            this.Comma.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Comma.UseVisualStyleBackColor = true;
            this.Comma.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Two
            // 
            this.Two.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Two.Location = new System.Drawing.Point(105, 225);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(96, 68);
            this.Two.TabIndex = 5;
            this.Two.Text = "2";
            this.Two.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Two.UseVisualStyleBackColor = true;
            this.Two.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Three
            // 
            this.Three.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Three.Location = new System.Drawing.Point(207, 225);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(96, 68);
            this.Three.TabIndex = 6;
            this.Three.Text = "3";
            this.Three.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Three.UseVisualStyleBackColor = true;
            this.Three.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Four
            // 
            this.Four.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Four.Location = new System.Drawing.Point(3, 151);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(96, 68);
            this.Four.TabIndex = 8;
            this.Four.Text = "4";
            this.Four.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Four.UseVisualStyleBackColor = true;
            this.Four.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Seven
            // 
            this.Seven.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Seven.Location = new System.Drawing.Point(3, 77);
            this.Seven.Name = "Seven";
            this.Seven.Size = new System.Drawing.Size(96, 68);
            this.Seven.TabIndex = 12;
            this.Seven.Text = "7";
            this.Seven.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Seven.UseVisualStyleBackColor = true;
            this.Seven.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Root
            // 
            this.Root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Root.Location = new System.Drawing.Point(3, 3);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(96, 68);
            this.Root.TabIndex = 16;
            this.Root.Text = "√";
            this.Root.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Root.UseVisualStyleBackColor = true;
            this.Root.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Five
            // 
            this.Five.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Five.Location = new System.Drawing.Point(105, 151);
            this.Five.Name = "Five";
            this.Five.Size = new System.Drawing.Size(96, 68);
            this.Five.TabIndex = 9;
            this.Five.Text = "5";
            this.Five.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Five.UseVisualStyleBackColor = true;
            this.Five.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Six
            // 
            this.Six.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Six.Location = new System.Drawing.Point(207, 151);
            this.Six.Name = "Six";
            this.Six.Size = new System.Drawing.Size(96, 68);
            this.Six.TabIndex = 10;
            this.Six.Text = "6";
            this.Six.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Six.UseVisualStyleBackColor = true;
            this.Six.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Eight
            // 
            this.Eight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Eight.Location = new System.Drawing.Point(105, 77);
            this.Eight.Name = "Eight";
            this.Eight.Size = new System.Drawing.Size(96, 68);
            this.Eight.TabIndex = 13;
            this.Eight.Text = "8";
            this.Eight.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Eight.UseVisualStyleBackColor = true;
            this.Eight.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Nine
            // 
            this.Nine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Nine.Location = new System.Drawing.Point(207, 77);
            this.Nine.Name = "Nine";
            this.Nine.Size = new System.Drawing.Size(96, 68);
            this.Nine.TabIndex = 14;
            this.Nine.Text = "9";
            this.Nine.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Nine.UseVisualStyleBackColor = true;
            this.Nine.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // PlusMinus
            // 
            this.PlusMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlusMinus.Location = new System.Drawing.Point(207, 299);
            this.PlusMinus.Name = "PlusMinus";
            this.PlusMinus.Size = new System.Drawing.Size(96, 71);
            this.PlusMinus.TabIndex = 2;
            this.PlusMinus.Text = "±";
            this.PlusMinus.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlusMinus.UseVisualStyleBackColor = true;
            this.PlusMinus.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Division
            // 
            this.Division.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Division.Location = new System.Drawing.Point(309, 299);
            this.Division.Name = "Division";
            this.Division.Size = new System.Drawing.Size(97, 71);
            this.Division.TabIndex = 3;
            this.Division.Text = "/";
            this.Division.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Division.UseVisualStyleBackColor = true;
            this.Division.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Equally
            // 
            this.Equally.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Equally.Location = new System.Drawing.Point(309, 3);
            this.Equally.Name = "Equally";
            this.Equally.Size = new System.Drawing.Size(97, 68);
            this.Equally.TabIndex = 19;
            this.Equally.Text = "=";
            this.Equally.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Equally.UseVisualStyleBackColor = true;
            this.Equally.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // Erase
            // 
            this.Erase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Erase.Location = new System.Drawing.Point(207, 3);
            this.Erase.Name = "Erase";
            this.Erase.Size = new System.Drawing.Size(96, 68);
            this.Erase.TabIndex = 18;
            this.Erase.Text = "⌫";
            this.Erase.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Erase.UseVisualStyleBackColor = true;
            this.Erase.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // EraseEverything
            // 
            this.EraseEverything.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EraseEverything.Location = new System.Drawing.Point(105, 3);
            this.EraseEverything.Name = "EraseEverything";
            this.EraseEverything.Size = new System.Drawing.Size(96, 68);
            this.EraseEverything.TabIndex = 17;
            this.EraseEverything.Text = "C";
            this.EraseEverything.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EraseEverything.UseVisualStyleBackColor = true;
            this.EraseEverything.Click += new System.EventHandler(this.AllButtonsOneClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(406, 138);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 39);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 99);
            this.label2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 518);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(427, 565);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Button One;
        private Button Two;
        private Button Three;
        private Button Nine;
        private Button Six;
        private Button Eight;
        private Button Five;
        private Button Seven;
        private Button Four;
        private Button Division;
        private Button Multiplication;
        private Button Subtraction;
        private Button Zero;
        private Button Equally;
        private Button Addition;
        private Button Comma;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label label2;
        private Button Root;
        private Button PlusMinus;
        private Button Erase;
        private Button EraseEverything;
    }
}