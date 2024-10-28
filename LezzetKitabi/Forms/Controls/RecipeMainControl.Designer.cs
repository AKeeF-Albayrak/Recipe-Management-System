namespace LezzetKitabi.Forms.Controls
{
    partial class RecipeMainControl
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
            panel1 = new Panel();
            label1 = new Label();
            buttonSearch = new Button();
            textBoxSearch = new TextBox();
            comboBoxSort = new ComboBox();
            panelElements = new Panel();
            panelPage = new Panel();
            panelItems = new Panel();
            button4 = new Button();
            panelDown = new Panel();
            panelPrevius = new Panel();
            button3 = new Button();
            panelSort = new Panel();
            label10 = new Label();
            panelFilter = new Panel();
            panel2 = new Panel();
            panel8 = new Panel();
            comboBoxIngredients = new ComboBox();
            buttonAddIngredient = new Button();
            label9 = new Label();
            panel7 = new Panel();
            comboBoxCategory = new ComboBox();
            buttonCatagory = new Button();
            label7 = new Label();
            panel5 = new Panel();
            buttonTimeAdd = new Button();
            label4 = new Label();
            textBoxMaxPrepTime = new TextBox();
            textBoxMinPrepTime = new TextBox();
            label5 = new Label();
            panelFilterPrice = new Panel();
            buttonPriceTagAdd = new Button();
            label3 = new Label();
            textBoxMaxPrice = new TextBox();
            textBoxMinPrice = new TextBox();
            label2 = new Label();
            panel6 = new Panel();
            button2 = new Button();
            label8 = new Label();
            textBoxmaxIngredientCount = new TextBox();
            textBoxminIngredientCount = new TextBox();
            label6 = new Label();
            panelCurrentFilters = new Panel();
            panelSearch.SuspendLayout();
            panel1.SuspendLayout();
            panelElements.SuspendLayout();
            panelPage.SuspendLayout();
            panelPrevius.SuspendLayout();
            panelSort.SuspendLayout();
            panelFilter.SuspendLayout();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panelFilterPrice.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.Transparent;
            panelSearch.Controls.Add(panel1);
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1334, 65);
            panelSearch.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1127, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(207, 65);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 27.75F);
            label1.Location = new Point(32, 13);
            label1.Name = "label1";
            label1.Size = new Size(141, 42);
            label1.TabIndex = 0;
            label1.Text = "Filtreler";
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.FromArgb(5, 150, 105);
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Location = new Point(993, 22);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 33);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Arama";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BackColor = Color.White;
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxSearch.Location = new Point(192, 22);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Arama";
            textBoxSearch.Size = new Size(781, 33);
            textBoxSearch.TabIndex = 0;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // comboBoxSort
            // 
            comboBoxSort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Items.AddRange(new object[] { "Artan Yuzde", "Azalan Yuzde", "Alfabetik(A-Z)", "Alfabetik(Z-A)", "Ucuzdan Pahaliya", "Pahalidan Ucuza", "Hizlidan Yavasa", "Yavasdan Hizliya", "Malzeme Sayisina Gore Artan", "Malzeme Sayisina Gore Azalan" });
            comboBoxSort.Location = new Point(690, 9);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(266, 29);
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
            panelPage.Controls.Add(panelItems);
            panelPage.Controls.Add(button4);
            panelPage.Controls.Add(panelDown);
            panelPage.Controls.Add(panelPrevius);
            panelPage.Location = new Point(0, 40);
            panelPage.Name = "panelPage";
            panelPage.Size = new Size(1126, 690);
            panelPage.TabIndex = 2;
            // 
            // panelItems
            // 
            panelItems.BackColor = Color.Transparent;
            panelItems.Dock = DockStyle.Left;
            panelItems.Location = new Point(48, 0);
            panelItems.Name = "panelItems";
            panelItems.Size = new Size(1041, 639);
            panelItems.TabIndex = 3;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 219, 254);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Comic Sans MS", 36F, FontStyle.Bold);
            button4.Location = new Point(1089, 261);
            button4.Name = "button4";
            button4.Size = new Size(38, 105);
            button4.TabIndex = 1;
            button4.Text = ">";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panelDown
            // 
            panelDown.BackColor = Color.Transparent;
            panelDown.Dock = DockStyle.Bottom;
            panelDown.Location = new Point(48, 639);
            panelDown.Name = "panelDown";
            panelDown.Size = new Size(1078, 51);
            panelDown.TabIndex = 2;
            // 
            // panelPrevius
            // 
            panelPrevius.BackColor = Color.Transparent;
            panelPrevius.Controls.Add(button3);
            panelPrevius.Dock = DockStyle.Left;
            panelPrevius.Location = new Point(0, 0);
            panelPrevius.Name = "panelPrevius";
            panelPrevius.Size = new Size(48, 690);
            panelPrevius.TabIndex = 1;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 219, 254);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Comic Sans MS", 36F, FontStyle.Bold);
            button3.Location = new Point(0, 261);
            button3.Name = "button3";
            button3.Size = new Size(38, 105);
            button3.TabIndex = 0;
            button3.Text = "<";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panelSort
            // 
            panelSort.BackColor = Color.Transparent;
            panelSort.Controls.Add(label10);
            panelSort.Controls.Add(comboBoxSort);
            panelSort.Location = new Point(0, 0);
            panelSort.Name = "panelSort";
            panelSort.Size = new Size(1126, 43);
            panelSort.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            label10.Location = new Point(1003, 7);
            label10.Name = "label10";
            label10.Size = new Size(56, 30);
            label10.TabIndex = 0;
            label10.Text = "x / x";
            // 
            // panelFilter
            // 
            panelFilter.BackgroundImageLayout = ImageLayout.None;
            panelFilter.Controls.Add(panel2);
            panelFilter.Controls.Add(panel6);
            panelFilter.Controls.Add(panelCurrentFilters);
            panelFilter.Dock = DockStyle.Left;
            panelFilter.Location = new Point(1127, 65);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(207, 730);
            panelFilter.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panelFilterPrice);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 102);
            panel2.Name = "panel2";
            panel2.Size = new Size(207, 407);
            panel2.TabIndex = 19;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(248, 250, 252);
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(comboBoxIngredients);
            panel8.Controls.Add(buttonAddIngredient);
            panel8.Controls.Add(label9);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 309);
            panel8.Name = "panel8";
            panel8.Size = new Size(207, 142);
            panel8.TabIndex = 5;
            // 
            // comboBoxIngredients
            // 
            comboBoxIngredients.FormattingEnabled = true;
            comboBoxIngredients.Location = new Point(18, 33);
            comboBoxIngredients.Name = "comboBoxIngredients";
            comboBoxIngredients.Size = new Size(162, 23);
            comboBoxIngredients.TabIndex = 6;
            // 
            // buttonAddIngredient
            // 
            buttonAddIngredient.BackColor = Color.FromArgb(5, 150, 105);
            buttonAddIngredient.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            buttonAddIngredient.FlatStyle = FlatStyle.Flat;
            buttonAddIngredient.Location = new Point(18, 62);
            buttonAddIngredient.Name = "buttonAddIngredient";
            buttonAddIngredient.Size = new Size(162, 23);
            buttonAddIngredient.TabIndex = 4;
            buttonAddIngredient.Text = "Filtrele";
            buttonAddIngredient.UseVisualStyleBackColor = false;
            buttonAddIngredient.Click += buttonAddIngredient_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(18, 10);
            label9.Name = "label9";
            label9.Size = new Size(71, 20);
            label9.TabIndex = 0;
            label9.Text = "Malzeme";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(248, 250, 252);
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(comboBoxCategory);
            panel7.Controls.Add(buttonCatagory);
            panel7.Controls.Add(label7);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 206);
            panel7.Name = "panel7";
            panel7.Size = new Size(207, 103);
            panel7.TabIndex = 6;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(18, 35);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(162, 23);
            comboBoxCategory.TabIndex = 5;
            // 
            // buttonCatagory
            // 
            buttonCatagory.BackColor = Color.FromArgb(5, 150, 105);
            buttonCatagory.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            buttonCatagory.FlatStyle = FlatStyle.Flat;
            buttonCatagory.Location = new Point(18, 64);
            buttonCatagory.Name = "buttonCatagory";
            buttonCatagory.Size = new Size(162, 23);
            buttonCatagory.TabIndex = 4;
            buttonCatagory.Text = "Filtrele";
            buttonCatagory.UseVisualStyleBackColor = false;
            buttonCatagory.Click += buttonCatagory_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ControlText;
            label7.Location = new Point(15, 12);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 0;
            label7.Text = "Kategori";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(248, 250, 252);
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(buttonTimeAdd);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(textBoxMaxPrepTime);
            panel5.Controls.Add(textBoxMinPrepTime);
            panel5.Controls.Add(label5);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 103);
            panel5.Name = "panel5";
            panel5.Size = new Size(207, 103);
            panel5.TabIndex = 5;
            // 
            // buttonTimeAdd
            // 
            buttonTimeAdd.BackColor = Color.FromArgb(5, 150, 105);
            buttonTimeAdd.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            buttonTimeAdd.FlatStyle = FlatStyle.Flat;
            buttonTimeAdd.ForeColor = SystemColors.ControlText;
            buttonTimeAdd.Location = new Point(18, 71);
            buttonTimeAdd.Name = "buttonTimeAdd";
            buttonTimeAdd.Size = new Size(162, 23);
            buttonTimeAdd.TabIndex = 4;
            buttonTimeAdd.Text = "Filtrele";
            buttonTimeAdd.UseVisualStyleBackColor = false;
            buttonTimeAdd.Click += buttonTimeAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold);
            label4.Location = new Point(88, 38);
            label4.Name = "label4";
            label4.Size = new Size(22, 30);
            label4.TabIndex = 15;
            label4.Text = "-";
            // 
            // textBoxMaxPrepTime
            // 
            textBoxMaxPrepTime.BackColor = Color.FromArgb(241, 245, 249);
            textBoxMaxPrepTime.BorderStyle = BorderStyle.FixedSingle;
            textBoxMaxPrepTime.Font = new Font("Segoe UI", 9F);
            textBoxMaxPrepTime.Location = new Point(116, 42);
            textBoxMaxPrepTime.Name = "textBoxMaxPrepTime";
            textBoxMaxPrepTime.PlaceholderText = "Max";
            textBoxMaxPrepTime.Size = new Size(64, 23);
            textBoxMaxPrepTime.TabIndex = 2;
            textBoxMaxPrepTime.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxMinPrepTime
            // 
            textBoxMinPrepTime.BackColor = Color.FromArgb(241, 245, 249);
            textBoxMinPrepTime.BorderStyle = BorderStyle.FixedSingle;
            textBoxMinPrepTime.Font = new Font("Segoe UI", 9F);
            textBoxMinPrepTime.Location = new Point(18, 42);
            textBoxMinPrepTime.Name = "textBoxMinPrepTime";
            textBoxMinPrepTime.PlaceholderText = "Min";
            textBoxMinPrepTime.Size = new Size(64, 23);
            textBoxMinPrepTime.TabIndex = 1;
            textBoxMinPrepTime.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(18, 15);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 0;
            label5.Text = "Hazırlanma Aralığı";
            // 
            // panelFilterPrice
            // 
            panelFilterPrice.BackColor = Color.FromArgb(248, 250, 252);
            panelFilterPrice.BorderStyle = BorderStyle.FixedSingle;
            panelFilterPrice.Controls.Add(buttonPriceTagAdd);
            panelFilterPrice.Controls.Add(label3);
            panelFilterPrice.Controls.Add(textBoxMaxPrice);
            panelFilterPrice.Controls.Add(textBoxMinPrice);
            panelFilterPrice.Controls.Add(label2);
            panelFilterPrice.Dock = DockStyle.Top;
            panelFilterPrice.Location = new Point(0, 0);
            panelFilterPrice.Name = "panelFilterPrice";
            panelFilterPrice.Size = new Size(207, 103);
            panelFilterPrice.TabIndex = 0;
            // 
            // buttonPriceTagAdd
            // 
            buttonPriceTagAdd.BackColor = Color.FromArgb(5, 150, 105);
            buttonPriceTagAdd.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            buttonPriceTagAdd.FlatStyle = FlatStyle.Flat;
            buttonPriceTagAdd.Location = new Point(18, 70);
            buttonPriceTagAdd.Name = "buttonPriceTagAdd";
            buttonPriceTagAdd.Size = new Size(162, 23);
            buttonPriceTagAdd.TabIndex = 4;
            buttonPriceTagAdd.Text = "Filtrele";
            buttonPriceTagAdd.UseVisualStyleBackColor = false;
            buttonPriceTagAdd.Click += buttonPriceTagAdd_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold);
            label3.Location = new Point(88, 35);
            label3.Name = "label3";
            label3.Size = new Size(22, 30);
            label3.TabIndex = 3;
            label3.Text = "-";
            // 
            // textBoxMaxPrice
            // 
            textBoxMaxPrice.BackColor = Color.FromArgb(241, 245, 249);
            textBoxMaxPrice.BorderStyle = BorderStyle.FixedSingle;
            textBoxMaxPrice.Font = new Font("Segoe UI", 9F);
            textBoxMaxPrice.Location = new Point(116, 42);
            textBoxMaxPrice.Name = "textBoxMaxPrice";
            textBoxMaxPrice.PlaceholderText = "Max";
            textBoxMaxPrice.Size = new Size(64, 23);
            textBoxMaxPrice.TabIndex = 2;
            textBoxMaxPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxMinPrice
            // 
            textBoxMinPrice.BackColor = Color.FromArgb(241, 245, 249);
            textBoxMinPrice.BorderStyle = BorderStyle.FixedSingle;
            textBoxMinPrice.Font = new Font("Segoe UI", 9F);
            textBoxMinPrice.Location = new Point(18, 41);
            textBoxMinPrice.Name = "textBoxMinPrice";
            textBoxMinPrice.PlaceholderText = "Min";
            textBoxMinPrice.Size = new Size(64, 23);
            textBoxMinPrice.TabIndex = 1;
            textBoxMinPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(18, 15);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 0;
            label2.Text = "Maliyet Aralığı";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(248, 250, 252);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(button2);
            panel6.Controls.Add(label8);
            panel6.Controls.Add(textBoxmaxIngredientCount);
            panel6.Controls.Add(textBoxminIngredientCount);
            panel6.Controls.Add(label6);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(207, 102);
            panel6.TabIndex = 18;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(5, 150, 105);
            button2.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(18, 68);
            button2.Name = "button2";
            button2.Size = new Size(162, 23);
            button2.TabIndex = 5;
            button2.Text = "Filtrele";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold);
            label8.Location = new Point(88, 32);
            label8.Name = "label8";
            label8.Size = new Size(22, 30);
            label8.TabIndex = 5;
            label8.Text = "-";
            // 
            // textBoxmaxIngredientCount
            // 
            textBoxmaxIngredientCount.BackColor = Color.FromArgb(241, 245, 249);
            textBoxmaxIngredientCount.BorderStyle = BorderStyle.FixedSingle;
            textBoxmaxIngredientCount.Font = new Font("Segoe UI", 9F);
            textBoxmaxIngredientCount.Location = new Point(116, 39);
            textBoxmaxIngredientCount.Name = "textBoxmaxIngredientCount";
            textBoxmaxIngredientCount.PlaceholderText = "Max";
            textBoxmaxIngredientCount.Size = new Size(64, 23);
            textBoxmaxIngredientCount.TabIndex = 3;
            textBoxmaxIngredientCount.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxminIngredientCount
            // 
            textBoxminIngredientCount.BackColor = Color.FromArgb(241, 245, 249);
            textBoxminIngredientCount.BorderStyle = BorderStyle.FixedSingle;
            textBoxminIngredientCount.Font = new Font("Segoe UI", 9F);
            textBoxminIngredientCount.Location = new Point(18, 39);
            textBoxminIngredientCount.Name = "textBoxminIngredientCount";
            textBoxminIngredientCount.PlaceholderText = "Min";
            textBoxminIngredientCount.Size = new Size(64, 23);
            textBoxminIngredientCount.TabIndex = 6;
            textBoxminIngredientCount.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(18, 8);
            label6.Name = "label6";
            label6.Size = new Size(167, 20);
            label6.TabIndex = 0;
            label6.Text = "Malzeme Sayısına Göre";
            // 
            // panelCurrentFilters
            // 
            panelCurrentFilters.BorderStyle = BorderStyle.FixedSingle;
            panelCurrentFilters.Dock = DockStyle.Bottom;
            panelCurrentFilters.Location = new Point(0, 509);
            panelCurrentFilters.Name = "panelCurrentFilters";
            panelCurrentFilters.Size = new Size(207, 221);
            panelCurrentFilters.TabIndex = 11;
            // 
            // RecipeMainControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(panelFilter);
            Controls.Add(panelElements);
            Controls.Add(panelSearch);
            DoubleBuffered = true;
            Name = "RecipeMainControl";
            Size = new Size(1334, 795);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelElements.ResumeLayout(false);
            panelPage.ResumeLayout(false);
            panelPrevius.ResumeLayout(false);
            panelSort.ResumeLayout(false);
            panelSort.PerformLayout();
            panelFilter.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panelFilterPrice.ResumeLayout(false);
            panelFilterPrice.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private Button buttonSearch;
        private TextBox textBoxSearch;
        private Panel panelElements;
        private Panel panelPage;
        private Panel panelPrevius;
        private Panel panelSort;
        private Panel panelItems;
        private Panel panelDown;
        private Panel panelFilter;
        private Label label1;
        private Panel panelCurrentFilters;
        private Panel panel6;
        private ComboBox comboBoxSort;
        private Panel panel2;
        private Panel panelFilterPrice;
        private Panel panel8;
        private Button buttonAddIngredient;
        private Label label9;
        private Panel panel7;
        private ComboBox comboBoxCategory;
        private Button buttonCatagory;
        private Label label7;
        private Panel panel5;
        private Button buttonTimeAdd;
        private Label label4;
        private TextBox textBoxMaxPrepTime;
        private TextBox textBoxMinPrepTime;
        private Label label5;
        private Button buttonPriceTagAdd;
        private Label label3;
        private TextBox textBoxMaxPrice;
        private TextBox textBoxMinPrice;
        private Label label2;
        private ComboBox comboBoxIngredients;
        private Button button2;
        private Label label8;
        private TextBox textBoxmaxIngredientCount;
        private TextBox textBoxminIngredientCount;
        private Label label6;
        private Button button4;
        private Button button3;
        private Label label10;
        private Panel panel1;
    }
}
