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
            ComboBox comboBox1;
            panelSearch = new Panel();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            panelElements = new Panel();
            panelPage = new Panel();
            panelItems = new Panel();
            panelDown = new Panel();
            panelPrevius = new Panel();
            button4 = new Button();
            panelNext = new Panel();
            button3 = new Button();
            panelSort = new Panel();
            comboBox1 = new ComboBox();
            panelSearch.SuspendLayout();
            panelElements.SuspendLayout();
            panelPage.SuspendLayout();
            panelPrevius.SuspendLayout();
            panelNext.SuspendLayout();
            panelSort.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Alfabetik(A-Z)", "Farklı Seçenek 1", "Farklı Seçenek 2" });
            comboBox1.Location = new Point(793, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(168, 23);
            comboBox1.TabIndex = 0;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.Transparent;
            panelSearch.Controls.Add(button2);
            panelSearch.Controls.Add(button1);
            panelSearch.Controls.Add(textBox1);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1051, 65);
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
            // button1
            // 
            button1.Location = new Point(948, 22);
            button1.Name = "button1";
            button1.Size = new Size(68, 23);
            button1.TabIndex = 1;
            button1.Text = "Filtreleme";
            button1.UseVisualStyleBackColor = true;
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
            panelElements.BackColor = Color.Transparent;
            panelElements.Controls.Add(panelPage);
            panelElements.Controls.Add(panelSort);
            panelElements.Dock = DockStyle.Fill;
            panelElements.Location = new Point(0, 65);
            panelElements.Name = "panelElements";
            panelElements.Size = new Size(1051, 730);
            panelElements.TabIndex = 2;
            // 
            // panelPage
            // 
            panelPage.Controls.Add(panelItems);
            panelPage.Controls.Add(panelDown);
            panelPage.Controls.Add(panelPrevius);
            panelPage.Controls.Add(panelNext);
            panelPage.Dock = DockStyle.Fill;
            panelPage.Location = new Point(0, 40);
            panelPage.Name = "panelPage";
            panelPage.Size = new Size(1051, 690);
            panelPage.TabIndex = 2;
            // 
            // panelItems
            // 
            panelItems.Dock = DockStyle.Fill;
            panelItems.Location = new Point(91, 0);
            panelItems.Name = "panelItems";
            panelItems.Size = new Size(870, 662);
            panelItems.TabIndex = 3;
            // 
            // panelDown
            // 
            panelDown.Dock = DockStyle.Bottom;
            panelDown.Location = new Point(91, 662);
            panelDown.Name = "panelDown";
            panelDown.Size = new Size(870, 28);
            panelDown.TabIndex = 2;
            // 
            // panelPrevius
            // 
            panelPrevius.BackColor = Color.Transparent;
            panelPrevius.Controls.Add(button4);
            panelPrevius.Dock = DockStyle.Left;
            panelPrevius.Location = new Point(0, 0);
            panelPrevius.Name = "panelPrevius";
            panelPrevius.Size = new Size(91, 690);
            panelPrevius.TabIndex = 1;
            // 
            // button4
            // 
            button4.Location = new Point(19, 265);
            button4.Name = "button4";
            button4.Size = new Size(47, 23);
            button4.TabIndex = 0;
            button4.Text = "<";
            button4.UseVisualStyleBackColor = true;
            // 
            // panelNext
            // 
            panelNext.BackColor = Color.Transparent;
            panelNext.Controls.Add(button3);
            panelNext.Dock = DockStyle.Right;
            panelNext.Location = new Point(961, 0);
            panelNext.Name = "panelNext";
            panelNext.Size = new Size(90, 690);
            panelNext.TabIndex = 0;
            // 
            // button3
            // 
            button3.Location = new Point(44, 265);
            button3.Name = "button3";
            button3.Size = new Size(36, 23);
            button3.TabIndex = 0;
            button3.Text = ">";
            button3.UseVisualStyleBackColor = true;
            // 
            // panelSort
            // 
            panelSort.BackColor = Color.Transparent;
            panelSort.Controls.Add(comboBox1);
            panelSort.Dock = DockStyle.Top;
            panelSort.Location = new Point(0, 0);
            panelSort.Name = "panelSort";
            panelSort.Size = new Size(1051, 40);
            panelSort.TabIndex = 1;
            // 
            // SearchControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelElements);
            Controls.Add(panelSearch);
            Name = "SearchControl";
            Size = new Size(1051, 795);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelElements.ResumeLayout(false);
            panelPage.ResumeLayout(false);
            panelPrevius.ResumeLayout(false);
            panelNext.ResumeLayout(false);
            panelSort.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Panel panelElements;
        private ComboBox comboBox1;
        private Panel panelPage;
        private Panel panelPrevius;
        private Button button4;
        private Panel panelNext;
        private Button button3;
        private Panel panelSort;
        private Panel panelItems;
        private Panel panelDown;
    }
}
