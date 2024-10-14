namespace LezzetKitabi.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelMenu = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            buttonIngredient = new Button();
            buttonRecipe = new Button();
            buttonSearch = new Button();
            panelLogo = new Panel();
            button1 = new Button();
            panelForms = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 56);
            panelMenu.Controls.Add(button5);
            panelMenu.Controls.Add(button4);
            panelMenu.Controls.Add(button3);
            panelMenu.Controls.Add(button2);
            panelMenu.Controls.Add(buttonIngredient);
            panelMenu.Controls.Add(buttonRecipe);
            panelMenu.Controls.Add(buttonSearch);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(214, 795);
            panelMenu.TabIndex = 0;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Top;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.Location = new Point(0, 530);
            button5.Name = "button5";
            button5.Size = new Size(214, 75);
            button5.TabIndex = 6;
            button5.Tag = "Ingredient";
            button5.Text = "tarif güncelle";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Top;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.White;
            button4.Location = new Point(0, 455);
            button4.Name = "button4";
            button4.Size = new Size(214, 75);
            button4.TabIndex = 5;
            button4.Tag = "Ingredient";
            button4.Text = "tarif sil";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(0, 380);
            button3.Name = "button3";
            button3.Size = new Size(214, 75);
            button3.TabIndex = 4;
            button3.Tag = "Ingredient";
            button3.Text = "tarif ekle ?";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(0, 305);
            button2.Name = "button2";
            button2.Size = new Size(214, 75);
            button2.TabIndex = 3;
            button2.Tag = "Ingredient";
            button2.Text = "deneme sayfasi";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // buttonIngredient
            // 
            buttonIngredient.Dock = DockStyle.Top;
            buttonIngredient.FlatAppearance.BorderSize = 0;
            buttonIngredient.FlatStyle = FlatStyle.Flat;
            buttonIngredient.ForeColor = Color.White;
            buttonIngredient.Location = new Point(0, 230);
            buttonIngredient.Name = "buttonIngredient";
            buttonIngredient.Size = new Size(214, 75);
            buttonIngredient.TabIndex = 2;
            buttonIngredient.Tag = "Ingredient";
            buttonIngredient.Text = "Malzemelerim";
            buttonIngredient.UseVisualStyleBackColor = true;
            buttonIngredient.Click += buttonIngredient_Click;
            // 
            // buttonRecipe
            // 
            buttonRecipe.Dock = DockStyle.Top;
            buttonRecipe.FlatAppearance.BorderSize = 0;
            buttonRecipe.FlatStyle = FlatStyle.Flat;
            buttonRecipe.ForeColor = Color.White;
            buttonRecipe.Location = new Point(0, 155);
            buttonRecipe.Name = "buttonRecipe";
            buttonRecipe.Size = new Size(214, 75);
            buttonRecipe.TabIndex = 1;
            buttonRecipe.Tag = "Recipe";
            buttonRecipe.Text = "Tariflerim";
            buttonRecipe.UseVisualStyleBackColor = true;
            buttonRecipe.Click += buttonRecipe_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Dock = DockStyle.Top;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Location = new Point(0, 80);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(214, 75);
            buttonSearch.TabIndex = 0;
            buttonSearch.Tag = "Search";
            buttonSearch.Text = "Arama";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(button1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(214, 80);
            panelLogo.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 28);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "►";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelForms
            // 
            panelForms.Dock = DockStyle.Fill;
            panelForms.Location = new Point(214, 0);
            panelForms.Name = "panelForms";
            panelForms.Size = new Size(1334, 795);
            panelForms.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1548, 795);
            Controls.Add(panelForms);
            Controls.Add(panelMenu);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lezzet Kitabı";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelMenu;
        private Button buttonSearch;
        private Panel panelLogo;
        private Button buttonIngredient;
        private Button buttonRecipe;
        private Button button1;
        private Panel panelForms;
        private Button button2;
        private Button button3;
        private Button button5;
        private Button button4;
    }
}
