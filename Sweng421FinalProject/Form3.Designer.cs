namespace Sweng421FinalProject
{
    partial class Form3
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
            Username = new ListBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            button3 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            listBox1 = new ListBox();
            button4 = new Button();
            Notify = new Button();
            comboBox1 = new ComboBox();
            label4 = new Label();
            comboBox2 = new ComboBox();
            button6 = new Button();
            label5 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // Username
            // 
            Username.FormattingEnabled = true;
            Username.ItemHeight = 15;
            Username.Location = new Point(26, 27);
            Username.Name = "Username";
            Username.Size = new Size(120, 19);
            Username.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(669, 28);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 2;
            label1.Text = "View Tasks";
            // 
            // button1
            // 
            button1.Location = new Point(12, 411);
            button1.Name = "button1";
            button1.Size = new Size(70, 23);
            button1.TabIndex = 3;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(607, 285);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 382);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(332, 23);
            textBox1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 364);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 6;
            label2.Text = "New Task";
            // 
            // button3
            // 
            button3.Location = new Point(713, 285);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 7;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(11, 285);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(331, 23);
            textBox2.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 258);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 9;
            label3.Text = "Edit Task";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(607, 46);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(181, 214);
            listBox1.TabIndex = 10;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.Location = new Point(607, 330);
            button4.Name = "button4";
            button4.Size = new Size(181, 23);
            button4.TabIndex = 11;
            button4.Text = "Create Report";
            button4.UseVisualStyleBackColor = true;
            // 
            // Notify
            // 
            Notify.Location = new Point(607, 369);
            Notify.Name = "Notify";
            Notify.Size = new Size(181, 23);
            Notify.TabIndex = 12;
            Notify.Text = "Notify";
            Notify.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(372, 285);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(70, 23);
            comboBox1.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(372, 247);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 14;
            label4.Text = "Task Priority";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(372, 382);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(70, 23);
            comboBox2.TabIndex = 15;
            // 
            // button6
            // 
            button6.Location = new Point(12, 326);
            button6.Name = "button6";
            button6.Size = new Size(70, 23);
            button6.TabIndex = 16;
            button6.Text = "Confirm";
            button6.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(491, 245);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 17;
            label5.Text = "Deadline";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(473, 286);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 18;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(473, 382);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 19;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(button6);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(Notify);
            Controls.Add(button4);
            Controls.Add(listBox1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(Username);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox Username;
        private Label label1;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label2;
        private Button button3;
        private TextBox textBox2;
        private Label label3;
        private ListBox listBox1;
        private Button button4;
        private Button Notify;
        private ComboBox comboBox1;
        private Label label4;
        private ComboBox comboBox2;
        private Button button6;
        private Label label5;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}