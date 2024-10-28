
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelMenu = new Panel();
            btnAddRecipe = new Button();
            btnAddIngredient = new Button();
            btnIngredients = new Button();
            btnRecipes = new Button();
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
            panelMenu.Controls.Add(btnAddRecipe);
            panelMenu.Controls.Add(btnAddIngredient);
            panelMenu.Controls.Add(btnIngredients);
            panelMenu.Controls.Add(btnRecipes);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(214, 795);
            panelMenu.TabIndex = 0;
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Dock = DockStyle.Top;
            btnAddRecipe.FlatAppearance.BorderSize = 0;
            btnAddRecipe.FlatStyle = FlatStyle.Flat;
            btnAddRecipe.ForeColor = Color.White;
            btnAddRecipe.Location = new Point(0, 305);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(214, 75);
            btnAddRecipe.TabIndex = 4;
            btnAddRecipe.Tag = "AddRecipe";
            btnAddRecipe.Text = "Tarif Ekleme";
            btnAddRecipe.UseVisualStyleBackColor = true;
            btnAddRecipe.Click += btnAddRecipe_Click;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Dock = DockStyle.Top;
            btnAddIngredient.FlatAppearance.BorderSize = 0;
            btnAddIngredient.FlatStyle = FlatStyle.Flat;
            btnAddIngredient.ForeColor = Color.White;
            btnAddIngredient.Location = new Point(0, 230);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(214, 75);
            btnAddIngredient.TabIndex = 2;
            btnAddIngredient.Tag = "AddIngredient";
            btnAddIngredient.Text = "Malzeme Ekle";
            btnAddIngredient.UseVisualStyleBackColor = true;
            btnAddIngredient.Click += btnAddIngredient_Click;
            // 
            // btnIngredients
            // 
            btnIngredients.Dock = DockStyle.Top;
            btnIngredients.FlatAppearance.BorderSize = 0;
            btnIngredients.FlatStyle = FlatStyle.Flat;
            btnIngredients.ForeColor = Color.White;
            btnIngredients.Location = new Point(0, 155);
            btnIngredients.Name = "btnIngredients";
            btnIngredients.Size = new Size(214, 75);
            btnIngredients.TabIndex = 1;
            btnIngredients.Tag = "Ingredients";
            btnIngredients.Text = "Malzemelerim";
            btnIngredients.UseVisualStyleBackColor = true;
            btnIngredients.Click += btnIngredients_Click;
            // 
            // btnRecipes
            // 
            btnRecipes.Dock = DockStyle.Top;
            btnRecipes.FlatAppearance.BorderSize = 0;
            btnRecipes.FlatStyle = FlatStyle.Flat;
            btnRecipes.ForeColor = Color.White;
            btnRecipes.Location = new Point(0, 80);
            btnRecipes.Name = "btnRecipes";
            btnRecipes.Size = new Size(214, 75);
            btnRecipes.TabIndex = 0;
            btnRecipes.Tag = "Recipes";
            btnRecipes.Text = "Tariflerim";
            btnRecipes.UseVisualStyleBackColor = true;
            btnRecipes.Click += btnRecipes_Click;
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lezzet Kitabı";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelMenu;
        private Button btnRecipes;
        private Panel panelLogo;
        private Button btnAddIngredient;
        private Button btnIngredients;
        private Button button1;
        private Panel panelForms;
        private Button btnAddRecipe;
    }
}
