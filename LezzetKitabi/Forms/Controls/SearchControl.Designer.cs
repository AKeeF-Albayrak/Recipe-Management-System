namespace LezzetKitabi.Forms.Controls
{
    partial class SearchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComboBox comboBoxSort;
            panelSearch = new Panel();
            button2 = new Button();
            buttonFilter = new Button();
            textBox1 = new TextBox();
            panelElements = new Panel();
            panelPage = new Panel();
            panelItems = new Panel();
            panelDown = new Panel();
            panelPrevius = new Panel();
            panelSort = new Panel();
            panelFilter = new Panel();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            comboBoxSort = new ComboBox();
            panelSearch.SuspendLayout();
            panelElements.SuspendLayout();
            panelPage.SuspendLayout();
            panelSort.SuspendLayout();
            panelFilter.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxSort
            // 
            comboBoxSort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Items.AddRange(new object[] { "Alfabetik(A-Z)", "Alfabetik(Z-A)", "Ucuzdan Pahaliya", "Pahalidan Ucuza" });
            comboBoxSort.Location = new Point(353, 3);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(168, 23);
            comboBoxSort.TabIndex = 0;
            comboBoxSort.SelectedIndexChanged += ComboBoxSort_SelectedIndexChanged;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.Transparent;
            panelSearch.Controls.Add(button2);
            panelSearch.Controls.Add(buttonFilter);
            panelSearch.Controls.Add(textBox1);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1323, 65);
            panelSearch.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(721, 22);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Arama";
            button2.UseVisualStyleBackColor = true;
            // 
            // buttonFilter
            // 
            buttonFilter.Location = new Point(980, 22);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(68, 23);
            buttonFilter.TabIndex = 1;
            buttonFilter.Text = "Filtreleme";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlDarkDark;
            textBox1.Location = new Point(251, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(445, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "Arama Yeri";
            // 
            // panelElements
            // 
            panelElements.BackColor = Color.Chocolate;
            panelElements.Controls.Add(panelPage);
            panelElements.Controls.Add(panelSort);
            panelElements.Dock = DockStyle.Left;
            panelElements.Location = new Point(0, 65);
            panelElements.Name = "panelElements";
            panelElements.Size = new Size(1127, 731);
            panelElements.TabIndex = 2;
            // 
            // panelPage
            // 
            panelPage.Controls.Add(panelItems);
            panelPage.Controls.Add(panelDown);
            panelPage.Controls.Add(panelPrevius);
            panelPage.Location = new Point(0, 40);
            panelPage.Name = "panelPage";
            panelPage.Size = new Size(1126, 690);
            panelPage.TabIndex = 2;
            // 
            // panelItems
            // 
            panelItems.Dock = DockStyle.Left;
            panelItems.Location = new Point(48, 0);
            panelItems.Name = "panelItems";
            panelItems.Size = new Size(1041, 662);
            panelItems.TabIndex = 3;
            // 
            // panelDown
            // 
            panelDown.Dock = DockStyle.Bottom;
            panelDown.Location = new Point(48, 662);
            panelDown.Name = "panelDown";
            panelDown.Size = new Size(1078, 28);
            panelDown.TabIndex = 2;
            // 
            // panelPrevius
            // 
            panelPrevius.BackColor = Color.Transparent;
            panelPrevius.Dock = DockStyle.Left;
            panelPrevius.Location = new Point(0, 0);
            panelPrevius.Name = "panelPrevius";
            panelPrevius.Size = new Size(48, 690);
            panelPrevius.TabIndex = 1;
            // 
            // panelSort
            // 
            panelSort.BackColor = Color.Transparent;
            panelSort.Controls.Add(comboBoxSort);
            panelSort.Location = new Point(0, 0);
            panelSort.Name = "panelSort";
            panelSort.Size = new Size(1126, 40);
            panelSort.TabIndex = 1;
            // 
            // panelFilter
            // 
            panelFilter.BackgroundImageLayout = ImageLayout.None;
            panelFilter.Controls.Add(panel6);
            panelFilter.Controls.Add(panel5);
            panelFilter.Controls.Add(panel4);
            panelFilter.Controls.Add(panel2);
            panelFilter.Controls.Add(panel3);
            panelFilter.Controls.Add(panel1);
            panelFilter.Dock = DockStyle.Left;
            panelFilter.Location = new Point(1127, 65);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(198, 731);
            panelFilter.TabIndex = 4;
            // 
            // button4
            // 
            button4.Location = new Point(12, 86);
            button4.Name = "button4";
            button4.Size = new Size(166, 23);
            button4.TabIndex = 14;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(9, 89);
            button3.Name = "button3";
            button3.Size = new Size(166, 23);
            button3.TabIndex = 13;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(12, 85);
            button1.Name = "button1";
            button1.Size = new Size(166, 23);
            button1.TabIndex = 12;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 510);
            panel1.Name = "panel1";
            panel1.Size = new Size(198, 221);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(50, 17);
            label1.Name = "label1";
            label1.Size = new Size(94, 32);
            label1.TabIndex = 0;
            label1.Text = "Filtreler";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 47);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(81, 52);
            label6.Name = "label6";
            label6.Size = new Size(22, 15);
            label6.TabIndex = 9;
            label6.Text = "---";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(109, 49);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(66, 23);
            textBox5.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(9, 49);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(66, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(112, 47);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(66, 23);
            textBox4.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(84, 50);
            label5.Name = "label5";
            label5.Size = new Size(22, 15);
            label5.TabIndex = 5;
            label5.Text = "---";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 47);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(66, 23);
            textBox2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(12, 10);
            label4.Name = "label4";
            label4.Size = new Size(60, 25);
            label4.TabIndex = 2;
            label4.Text = "Birim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(9, 11);
            label3.Name = "label3";
            label3.Size = new Size(51, 25);
            label3.TabIndex = 1;
            label3.Text = "Stok:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(12, 19);
            label2.Name = "label2";
            label2.Size = new Size(109, 25);
            label2.TabIndex = 0;
            label2.Text = "Birim Fiyati:";
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 325);
            panel2.Name = "panel2";
            panel2.Size = new Size(198, 125);
            panel2.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 450);
            panel3.Name = "panel3";
            panel3.Size = new Size(198, 60);
            panel3.TabIndex = 16;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(button3);
            panel4.Controls.Add(textBox3);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(textBox5);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 192);
            panel4.Name = "panel4";
            panel4.Size = new Size(198, 133);
            panel4.TabIndex = 17;
            // 
            // panel5
            // 
            panel5.Controls.Add(button4);
            panel5.Controls.Add(textBox2);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(textBox4);
            panel5.Controls.Add(label2);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 71);
            panel5.Name = "panel5";
            panel5.Size = new Size(198, 121);
            panel5.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(198, 71);
            panel6.TabIndex = 18;
            // 
            // SearchControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelFilter);
            Controls.Add(panelElements);
            Controls.Add(panelSearch);
            Name = "SearchControl";
            Size = new Size(1323, 796);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelElements.ResumeLayout(false);
            panelPage.ResumeLayout(false);
            panelSort.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private Button button2;
        private Button buttonFilter;
        private TextBox textBox1;
        private Panel panelElements;
        private ComboBox comboBoxSort;
        private Panel panelPage;
        private Panel panelPrevius;
        private Panel panelSort;
        private Panel panelItems;
        private Panel panelDown;
        private Panel panelFilter;
        private Label label2;
        private Label label1;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private Button button4;
        private Button button3;
        private Button button1;
        private Panel panel1;
        private ComboBox comboBox1;
        private Label label6;
        private TextBox textBox5;
        private TextBox textBox3;
        private Panel panel4;
        private Panel panel2;
        private Panel panel3;
        private Panel panel6;
        private Panel panel5;
    }
}
