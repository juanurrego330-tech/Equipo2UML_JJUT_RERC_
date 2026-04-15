namespace Equipo2UML_JJUT_RERC
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            panel1 = new Panel();
            label3 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // radioButton1
            // 
            radioButton1.Anchor = AnchorStyles.None;
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 15F);
            radioButton1.Location = new Point(812, 213);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(129, 39);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Nombre";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.None;
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 15F);
            radioButton2.Location = new Point(812, 258);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(94, 39);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Placa";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.AutoScroll = true;
            panel1.Controls.Add(label3);
            panel1.Location = new Point(143, 173);
            panel1.Name = "panel1";
            panel1.Size = new Size(645, 397);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(3, 15);
            label3.Name = "label3";
            label3.Size = new Size(0, 30);
            label3.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(44, 105);
            label1.Name = "label1";
            label1.Size = new Size(99, 37);
            label1.TabIndex = 3;
            label1.Text = "Buscar:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Font = new Font("Segoe UI", 13F);
            textBox1.Location = new Point(143, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(645, 36);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(812, 173);
            label2.Name = "label2";
            label2.Size = new Size(129, 35);
            label2.TabIndex = 5;
            label2.Text = "Filtrar por:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(812, 108);
            button1.Name = "button1";
            button1.Size = new Size(129, 36);
            button1.TabIndex = 16;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Name = "Form2";
            Text = "Buscador Polizas";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Button button1;
        private Label label3;
    }
}