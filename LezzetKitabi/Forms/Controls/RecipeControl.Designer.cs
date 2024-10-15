namespace LezzetKitabi.Forms.Controls
{
    partial class RecipeControl
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
            buttonSearch = new Button();
            buttonFilter = new Button();
            textBoxSearch = new TextBox();
            panelElements = new Panel();
            panelPage = new Panel();
            panelItems = new Panel();
            panelDown = new Panel();
            panelPrevius = new Panel();
            panelSort = new Panel();
            comboBoxSort = new ComboBox();
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
            label1 = new Label();
            panel3 = new Panel();
            panelCurrentFilters = new Panel();
            panel4 = new Panel();
            button1 = new Button();
            panelSearch.SuspendLayout();
            panelElements.SuspendLayout();
            panelPage.SuspendLayout();
            panelSort.SuspendLayout();
            panelFilter.SuspendLayout();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panelFilterPrice.SuspendLayout();
            panel6.SuspendLayout();
            panelCurrentFilters.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.Transparent;
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Controls.Add(buttonFilter);
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1323, 65);
            panelSearch.TabIndex = 0;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(721, 22);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Arama";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonFilter
            // 
            buttonFilter.Location = new Point(980, 22);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(68, 23);
            buttonFilter.TabIndex = 1;
            buttonFilter.Text = "Filtreleme";
            buttonFilter.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BackColor = SystemColors.ControlDarkDark;
            textBoxSearch.Location = new Point(251, 22);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(445, 23);
            textBoxSearch.TabIndex = 0;
            textBoxSearch.Text = "Arama Yeri";
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
            // comboBoxSort
            // 
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Items.AddRange(new object[] { "Alfabetik(A-Z)", "Alfabetik(Z-A)", "Ucuzdan Pahaliya", "Pahalidan Ucuza", "Hizlidan Yavasa", "Yavasdan Hizliya" });
            comboBoxSort.Location = new Point(616, 11);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(192, 23);
            comboBoxSort.TabIndex = 0;
            comboBoxSort.SelectedIndexChanged += ComboBoxSort_SelectedIndexChanged;
            // 
            // panelFilter
            // 
            panelFilter.BackgroundImageLayout = ImageLayout.None;
            panelFilter.Controls.Add(panel2);
            panelFilter.Controls.Add(panel6);
            panelFilter.Controls.Add(panel3);
            panelFilter.Controls.Add(panelCurrentFilters);
            panelFilter.Dock = DockStyle.Left;
            panelFilter.Location = new Point(1127, 65);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(198, 731);
            panelFilter.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panelFilterPrice);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(198, 412);
            panel2.TabIndex = 19;
            // 
            // panel8
            // 
            panel8.Controls.Add(comboBoxIngredients);
            panel8.Controls.Add(buttonAddIngredient);
            panel8.Controls.Add(label9);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 309);
            panel8.Name = "panel8";
            panel8.Size = new Size(198, 103);
            panel8.TabIndex = 5;
            // 
            // comboBoxIngredients
            // 
            comboBoxIngredients.FormattingEnabled = true;
            comboBoxIngredients.Location = new Point(15, 41);
            comboBoxIngredients.Name = "comboBoxIngredients";
            comboBoxIngredients.Size = new Size(167, 23);
            comboBoxIngredients.TabIndex = 6;
            // 
            // buttonAddIngredient
            // 
            buttonAddIngredient.Location = new Point(58, 73);
            buttonAddIngredient.Name = "buttonAddIngredient";
            buttonAddIngredient.Size = new Size(75, 23);
            buttonAddIngredient.TabIndex = 4;
            buttonAddIngredient.Text = "Ekle";
            buttonAddIngredient.UseVisualStyleBackColor = true;
            buttonAddIngredient.Click += buttonAddIngredient_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label9.Location = new Point(58, 9);
            label9.Name = "label9";
            label9.Size = new Size(73, 21);
            label9.TabIndex = 0;
            label9.Text = "Malzeme";
            // 
            // panel7
            // 
            panel7.Controls.Add(comboBoxCategory);
            panel7.Controls.Add(buttonCatagory);
            panel7.Controls.Add(label7);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 206);
            panel7.Name = "panel7";
            panel7.Size = new Size(198, 103);
            panel7.TabIndex = 6;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(15, 40);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(167, 23);
            comboBoxCategory.TabIndex = 5;
            // 
            // buttonCatagory
            // 
            buttonCatagory.Location = new Point(58, 73);
            buttonCatagory.Name = "buttonCatagory";
            buttonCatagory.Size = new Size(75, 23);
            buttonCatagory.TabIndex = 4;
            buttonCatagory.Text = "Ekle";
            buttonCatagory.UseVisualStyleBackColor = true;
            buttonCatagory.Click += buttonCatagory_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label7.Location = new Point(60, 8);
            label7.Name = "label7";
            label7.Size = new Size(68, 21);
            label7.TabIndex = 0;
            label7.Text = "Kategori";
            // 
            // panel5
            // 
            panel5.Controls.Add(buttonTimeAdd);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(textBoxMaxPrepTime);
            panel5.Controls.Add(textBoxMinPrepTime);
            panel5.Controls.Add(label5);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 103);
            panel5.Name = "panel5";
            panel5.Size = new Size(198, 103);
            panel5.TabIndex = 5;
            // 
            // buttonTimeAdd
            // 
            buttonTimeAdd.Location = new Point(58, 73);
            buttonTimeAdd.Name = "buttonTimeAdd";
            buttonTimeAdd.Size = new Size(75, 23);
            buttonTimeAdd.TabIndex = 4;
            buttonTimeAdd.Text = "Ekle";
            buttonTimeAdd.UseVisualStyleBackColor = true;
            buttonTimeAdd.Click += buttonTimeAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 48);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 3;
            label4.Text = "---";
            // 
            // textBoxMaxPrepTime
            // 
            textBoxMaxPrepTime.BorderStyle = BorderStyle.None;
            textBoxMaxPrepTime.Location = new Point(118, 41);
            textBoxMaxPrepTime.Name = "textBoxMaxPrepTime";
            textBoxMaxPrepTime.Size = new Size(64, 16);
            textBoxMaxPrepTime.TabIndex = 2;
            // 
            // textBoxMinPrepTime
            // 
            textBoxMinPrepTime.BorderStyle = BorderStyle.None;
            textBoxMinPrepTime.Location = new Point(15, 42);
            textBoxMinPrepTime.Name = "textBoxMinPrepTime";
            textBoxMinPrepTime.Size = new Size(64, 16);
            textBoxMinPrepTime.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(26, 12);
            label5.Name = "label5";
            label5.Size = new Size(138, 21);
            label5.TabIndex = 0;
            label5.Text = "Hazirlanma Araligi";
            // 
            // panelFilterPrice
            // 
            panelFilterPrice.Controls.Add(buttonPriceTagAdd);
            panelFilterPrice.Controls.Add(label3);
            panelFilterPrice.Controls.Add(textBoxMaxPrice);
            panelFilterPrice.Controls.Add(textBoxMinPrice);
            panelFilterPrice.Controls.Add(label2);
            panelFilterPrice.Dock = DockStyle.Top;
            panelFilterPrice.Location = new Point(0, 0);
            panelFilterPrice.Name = "panelFilterPrice";
            panelFilterPrice.Size = new Size(198, 103);
            panelFilterPrice.TabIndex = 0;
            // 
            // buttonPriceTagAdd
            // 
            buttonPriceTagAdd.Location = new Point(58, 73);
            buttonPriceTagAdd.Name = "buttonPriceTagAdd";
            buttonPriceTagAdd.Size = new Size(75, 23);
            buttonPriceTagAdd.TabIndex = 4;
            buttonPriceTagAdd.Text = "Ekle";
            buttonPriceTagAdd.UseVisualStyleBackColor = true;
            buttonPriceTagAdd.Click += buttonPriceTagAdd_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 48);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 3;
            label3.Text = "---";
            // 
            // textBoxMaxPrice
            // 
            textBoxMaxPrice.BorderStyle = BorderStyle.None;
            textBoxMaxPrice.Location = new Point(118, 41);
            textBoxMaxPrice.Name = "textBoxMaxPrice";
            textBoxMaxPrice.Size = new Size(64, 16);
            textBoxMaxPrice.TabIndex = 2;
            // 
            // textBoxMinPrice
            // 
            textBoxMinPrice.BorderStyle = BorderStyle.None;
            textBoxMinPrice.Location = new Point(15, 42);
            textBoxMinPrice.Name = "textBoxMinPrice";
            textBoxMinPrice.Size = new Size(64, 16);
            textBoxMinPrice.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(43, 12);
            label2.Name = "label2";
            label2.Size = new Size(110, 21);
            label2.TabIndex = 0;
            label2.Text = "Maliyet Araligi";
            // 
            // panel6
            // 
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(198, 71);
            panel6.TabIndex = 18;
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
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 483);
            panel3.Name = "panel3";
            panel3.Size = new Size(198, 27);
            panel3.TabIndex = 16;
            // 
            // panelCurrentFilters
            // 
            panelCurrentFilters.Controls.Add(panel4);
            panelCurrentFilters.Dock = DockStyle.Bottom;
            panelCurrentFilters.Location = new Point(0, 510);
            panelCurrentFilters.Name = "panelCurrentFilters";
            panelCurrentFilters.Size = new Size(198, 221);
            panelCurrentFilters.TabIndex = 11;
            // 
            // panel4
            // 
            panel4.Controls.Add(button1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 155);
            panel4.Name = "panel4";
            panel4.Size = new Size(198, 66);
            panel4.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(15, 24);
            button1.Name = "button1";
            button1.Size = new Size(149, 23);
            button1.TabIndex = 0;
            button1.Text = "Filtrele";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonFilter_Click;
            // 
            // RecipeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelFilter);
            Controls.Add(panelElements);
            Controls.Add(panelSearch);
            Name = "RecipeControl";
            Size = new Size(1323, 796);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelElements.ResumeLayout(false);
            panelPage.ResumeLayout(false);
            panelSort.ResumeLayout(false);
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
            panelCurrentFilters.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private Button buttonSearch;
        private Button buttonFilter;
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
        private Panel panel3;
        private Panel panel6;
        private ComboBox comboBoxSort;
        private Panel panel2;
        private Panel panelFilterPrice;
        private Panel panel4;
        private Button button1;
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
    }
}
