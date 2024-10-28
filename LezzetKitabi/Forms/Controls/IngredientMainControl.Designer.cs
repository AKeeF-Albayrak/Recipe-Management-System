namespace LezzetKitabi.Forms.Controls
{
    partial class IngredientMainControl
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
            panelSearch = new Panel();
            button2 = new Button();
            textBoxSearch = new TextBox();
            label7 = new Label();
            comboBoxSort = new ComboBox();
            panelElements = new Panel();
            panelPage = new Panel();
            panel1 = new Panel();
            buttonNext = new Button();
            panelItems = new Panel();
            panelPrevius = new Panel();
            buttonPrevious = new Button();
            panelSort = new Panel();
            panelFilter = new Panel();
            panel6 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            label5 = new Label();
            buttonPriceRangeAdd = new Button();
            textBoxMinPrice = new TextBox();
            textBoxMaxPrice = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            label3 = new Label();
            buttonStockRangeAdd = new Button();
            textBoxMinStock = new TextBox();
            label6 = new Label();
            textBoxMaxStock = new TextBox();
            panel2 = new Panel();
            buttonUnitAdd = new Button();
            comboBoxUnit = new ComboBox();
            label4 = new Label();
            panelCurrentFilters = new Panel();
            panelSearch.SuspendLayout();
            panelElements.SuspendLayout();
            panelPage.SuspendLayout();
            panel1.SuspendLayout();
            panelPrevius.SuspendLayout();
            panelSort.SuspendLayout();
            panelFilter.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.Transparent;
            panelSearch.Controls.Add(button2);
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1334, 65);
            panelSearch.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(5, 150, 105);
            button2.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(993, 22);
            button2.Name = "button2";
            button2.Size = new Size(75, 33);
            button2.TabIndex = 2;
            button2.Text = "Arama";
            button2.UseVisualStyleBackColor = false;
            button2.Click += buttonSearch_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BackColor = Color.White;
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxSearch.Location = new Point(195, 22);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Arama";
            textBoxSearch.Size = new Size(781, 33);
            textBoxSearch.TabIndex = 2;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(1003, 7);
            label7.Name = "label7";
            label7.Size = new Size(21, 30);
            label7.TabIndex = 0;
            label7.Text = "1";
            // 
            // comboBoxSort
            // 
            comboBoxSort.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Items.AddRange(new object[] { "Alfabetik(A-Z)", "Alfabetik(Z-A)", "Ucuzdan Pahaliya", "Pahalidan Ucuza" });
            comboBoxSort.Location = new Point(690, 9);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(286, 25);
            comboBoxSort.TabIndex = 0;
            comboBoxSort.SelectedIndexChanged += ComboBoxSort_SelectedIndexChanged;
            // 
            // panelElements
            // 
            panelElements.BackColor = Color.Transparent;
            panelElements.Controls.Add(panelPage);
            panelElements.Controls.Add(panelSort);
            panelElements.Dock = DockStyle.Left;
            panelElements.Location = new Point(0, 65);
            panelElements.Name = "panelElements";
            panelElements.Size = new Size(1127, 730);
            panelElements.TabIndex = 2;
            // 
            // panelPage
            // 
            panelPage.BackColor = Color.Transparent;
            panelPage.Controls.Add(panel1);
            panelPage.Controls.Add(panelItems);
            panelPage.Controls.Add(panelPrevius);
            panelPage.Location = new Point(0, 40);
            panelPage.Name = "panelPage";
            panelPage.Size = new Size(1126, 690);
            panelPage.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonNext);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1086, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(40, 690);
            panel1.TabIndex = 2;
            // 
            // buttonNext
            // 
            buttonNext.BackColor = Color.Transparent;
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 219, 254);
            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.Font = new Font("Comic Sans MS", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonNext.ForeColor = Color.FromArgb(71, 85, 105);
            buttonNext.Location = new Point(0, 261);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(41, 105);
            buttonNext.TabIndex = 1;
            buttonNext.Text = ">";
            buttonNext.UseVisualStyleBackColor = false;
            buttonNext.Click += buttonNext_Click;
            // 
            // panelItems
            // 
            panelItems.BackColor = Color.Transparent;
            panelItems.Dock = DockStyle.Left;
            panelItems.Location = new Point(40, 0);
            panelItems.Name = "panelItems";
            panelItems.Size = new Size(1048, 690);
            panelItems.TabIndex = 3;
            // 
            // panelPrevius
            // 
            panelPrevius.BackColor = Color.Transparent;
            panelPrevius.Controls.Add(buttonPrevious);
            panelPrevius.Dock = DockStyle.Left;
            panelPrevius.Location = new Point(0, 0);
            panelPrevius.Name = "panelPrevius";
            panelPrevius.Size = new Size(40, 690);
            panelPrevius.TabIndex = 1;
            // 
            // buttonPrevious
            // 
            buttonPrevious.BackColor = Color.Transparent;
            buttonPrevious.FlatAppearance.BorderColor = Color.Black;
            buttonPrevious.FlatAppearance.BorderSize = 0;
            buttonPrevious.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 219, 254);
            buttonPrevious.FlatStyle = FlatStyle.Flat;
            buttonPrevious.Font = new Font("Comic Sans MS", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPrevious.ForeColor = Color.FromArgb(71, 85, 105);
            buttonPrevious.Location = new Point(0, 261);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new Size(38, 105);
            buttonPrevious.TabIndex = 0;
            buttonPrevious.Text = "<";
            buttonPrevious.UseVisualStyleBackColor = false;
            buttonPrevious.Click += buttonPrevious_Click;
            // 
            // panelSort
            // 
            panelSort.BackColor = Color.Transparent;
            panelSort.Controls.Add(label7);
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
            panelFilter.Controls.Add(panelCurrentFilters);
            panelFilter.Dock = DockStyle.Left;
            panelFilter.Location = new Point(1127, 65);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(207, 730);
            panelFilter.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(207, 57);
            panel6.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 9);
            label1.Name = "label1";
            label1.Size = new Size(141, 42);
            label1.TabIndex = 0;
            label1.Text = "Filtreler";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(label5);
            panel5.Controls.Add(buttonPriceRangeAdd);
            panel5.Controls.Add(textBoxMinPrice);
            panel5.Controls.Add(textBoxMaxPrice);
            panel5.Controls.Add(label2);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 57);
            panel5.Name = "panel5";
            panel5.Size = new Size(207, 131);
            panel5.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(89, 50);
            label5.Name = "label5";
            label5.Size = new Size(22, 30);
            label5.TabIndex = 15;
            label5.Text = "-";
            // 
            // buttonPriceRangeAdd
            // 
            buttonPriceRangeAdd.BackColor = Color.FromArgb(5, 150, 105);
            buttonPriceRangeAdd.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            buttonPriceRangeAdd.FlatAppearance.BorderSize = 2;
            buttonPriceRangeAdd.FlatStyle = FlatStyle.Flat;
            buttonPriceRangeAdd.ForeColor = Color.White;
            buttonPriceRangeAdd.Location = new Point(15, 88);
            buttonPriceRangeAdd.Name = "buttonPriceRangeAdd";
            buttonPriceRangeAdd.Size = new Size(171, 27);
            buttonPriceRangeAdd.TabIndex = 14;
            buttonPriceRangeAdd.Text = "Filtrele";
            buttonPriceRangeAdd.UseVisualStyleBackColor = false;
            buttonPriceRangeAdd.Click += buttonPriceRangeAdd_Click;
            // 
            // textBoxMinPrice
            // 
            textBoxMinPrice.BackColor = Color.FromArgb(241, 245, 249);
            textBoxMinPrice.BorderStyle = BorderStyle.FixedSingle;
            textBoxMinPrice.Font = new Font("Segoe UI", 9.75F);
            textBoxMinPrice.Location = new Point(15, 54);
            textBoxMinPrice.Name = "textBoxMinPrice";
            textBoxMinPrice.PlaceholderText = "Min Price";
            textBoxMinPrice.Size = new Size(66, 25);
            textBoxMinPrice.TabIndex = 3;
            textBoxMinPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxMaxPrice
            // 
            textBoxMaxPrice.BackColor = Color.FromArgb(241, 245, 249);
            textBoxMaxPrice.BorderStyle = BorderStyle.FixedSingle;
            textBoxMaxPrice.Font = new Font("Segoe UI", 9.75F);
            textBoxMaxPrice.Location = new Point(120, 54);
            textBoxMaxPrice.Name = "textBoxMaxPrice";
            textBoxMaxPrice.PlaceholderText = "Max Price";
            textBoxMaxPrice.Size = new Size(66, 25);
            textBoxMaxPrice.TabIndex = 6;
            textBoxMaxPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(15, 15);
            label2.Name = "label2";
            label2.Size = new Size(120, 30);
            label2.TabIndex = 0;
            label2.Text = "Birim Fiyatı";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(buttonStockRangeAdd);
            panel4.Controls.Add(textBoxMinStock);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(textBoxMaxStock);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 188);
            panel4.Name = "panel4";
            panel4.Size = new Size(207, 130);
            panel4.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(15, 11);
            label3.Name = "label3";
            label3.Size = new Size(55, 30);
            label3.TabIndex = 1;
            label3.Text = "Stok";
            // 
            // buttonStockRangeAdd
            // 
            buttonStockRangeAdd.BackColor = Color.FromArgb(5, 150, 105);
            buttonStockRangeAdd.BackgroundImageLayout = ImageLayout.None;
            buttonStockRangeAdd.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            buttonStockRangeAdd.FlatAppearance.BorderSize = 2;
            buttonStockRangeAdd.FlatStyle = FlatStyle.Flat;
            buttonStockRangeAdd.ForeColor = Color.White;
            buttonStockRangeAdd.Location = new Point(15, 82);
            buttonStockRangeAdd.Name = "buttonStockRangeAdd";
            buttonStockRangeAdd.Size = new Size(171, 30);
            buttonStockRangeAdd.TabIndex = 13;
            buttonStockRangeAdd.Text = "Filtrele";
            buttonStockRangeAdd.UseVisualStyleBackColor = false;
            buttonStockRangeAdd.Click += buttonStockRangeAdd_Click;
            // 
            // textBoxMinStock
            // 
            textBoxMinStock.BackColor = Color.FromArgb(241, 245, 249);
            textBoxMinStock.BorderStyle = BorderStyle.FixedSingle;
            textBoxMinStock.Font = new Font("Segoe UI", 9.75F);
            textBoxMinStock.Location = new Point(15, 47);
            textBoxMinStock.Name = "textBoxMinStock";
            textBoxMinStock.PlaceholderText = "Min Stock";
            textBoxMinStock.Size = new Size(66, 25);
            textBoxMinStock.TabIndex = 7;
            textBoxMinStock.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(89, 41);
            label6.Name = "label6";
            label6.Size = new Size(22, 30);
            label6.TabIndex = 9;
            label6.Text = "-";
            // 
            // textBoxMaxStock
            // 
            textBoxMaxStock.BackColor = Color.FromArgb(241, 245, 249);
            textBoxMaxStock.BorderStyle = BorderStyle.FixedSingle;
            textBoxMaxStock.Font = new Font("Segoe UI", 9.75F);
            textBoxMaxStock.Location = new Point(119, 47);
            textBoxMaxStock.Name = "textBoxMaxStock";
            textBoxMaxStock.PlaceholderText = "Max Stock";
            textBoxMaxStock.Size = new Size(66, 25);
            textBoxMaxStock.TabIndex = 8;
            textBoxMaxStock.TextAlign = HorizontalAlignment.Center;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(buttonUnitAdd);
            panel2.Controls.Add(comboBoxUnit);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 318);
            panel2.Name = "panel2";
            panel2.Size = new Size(207, 125);
            panel2.TabIndex = 15;
            // 
            // buttonUnitAdd
            // 
            buttonUnitAdd.BackColor = Color.FromArgb(5, 150, 105);
            buttonUnitAdd.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            buttonUnitAdd.FlatAppearance.BorderSize = 2;
            buttonUnitAdd.FlatStyle = FlatStyle.Flat;
            buttonUnitAdd.ForeColor = Color.White;
            buttonUnitAdd.Location = new Point(15, 86);
            buttonUnitAdd.Name = "buttonUnitAdd";
            buttonUnitAdd.Size = new Size(170, 32);
            buttonUnitAdd.TabIndex = 12;
            buttonUnitAdd.Text = "Filtrele";
            buttonUnitAdd.UseVisualStyleBackColor = false;
            buttonUnitAdd.Click += buttonUnitAdd_Click;
            // 
            // comboBoxUnit
            // 
            comboBoxUnit.BackColor = Color.FromArgb(241, 245, 249);
            comboBoxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUnit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxUnit.FormattingEnabled = true;
            comboBoxUnit.Location = new Point(15, 51);
            comboBoxUnit.Name = "comboBoxUnit";
            comboBoxUnit.Size = new Size(170, 25);
            comboBoxUnit.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(15, 14);
            label4.Name = "label4";
            label4.Size = new Size(63, 30);
            label4.TabIndex = 2;
            label4.Text = "Birim";
            // 
            // panelCurrentFilters
            // 
            panelCurrentFilters.BorderStyle = BorderStyle.FixedSingle;
            panelCurrentFilters.Dock = DockStyle.Bottom;
            panelCurrentFilters.Location = new Point(0, 443);
            panelCurrentFilters.Name = "panelCurrentFilters";
            panelCurrentFilters.Size = new Size(207, 287);
            panelCurrentFilters.TabIndex = 16;
            // 
            // IngredientMainControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(panelFilter);
            Controls.Add(panelElements);
            Controls.Add(panelSearch);
            Name = "IngredientMainControl";
            Size = new Size(1334, 795);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelElements.ResumeLayout(false);
            panelPage.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelPrevius.ResumeLayout(false);
            panelSort.ResumeLayout(false);
            panelSort.PerformLayout();
            panelFilter.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private Button button2;
        private TextBox textBoxSearch;
        private Panel panelElements;
        private Panel panelPage;
        private Panel panelPrevius;
        private Panel panelSort;
        private Panel panelFilter;
        private Label label2;
        private Label label1;
        private TextBox textBoxMaxPrice;
        private TextBox textBoxMinPrice;
        private Label label4;
        private Label label3;
        private Button buttonPriceRangeAdd;
        private Button buttonStockRangeAdd;
        private Button buttonUnitAdd;
        private ComboBox comboBoxUnit;
        private Label label6;
        private TextBox textBoxMaxStock;
        private TextBox textBoxMinStock;
        private Panel panel4;
        private Panel panel2;
        private Panel panelCurrentFilters;
        private Panel panel6;
        private Panel panel5;
        private ComboBox comboBoxSort;
        private Button buttonPrevious;
        private Panel panelItems;
        private Panel panel1;
        private Button buttonNext;
        private Label label5;
        private Label label7;
    }
}
