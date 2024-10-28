namespace LezzetKitabi.Forms
{
    partial class RecipeDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeDetailsForm));
            labelRecipeName = new Label();
            label1 = new Label();
            labelCategory = new Label();
            labelPreparationTime = new Label();
            labelInstructions = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            panelInstructions = new Panel();
            panelIngredients = new Panel();
            button1 = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelRecipeName
            // 
            labelRecipeName.AutoSize = true;
            labelRecipeName.Font = new Font("Arial", 14.25F);
            labelRecipeName.Location = new Point(311, 555);
            labelRecipeName.Name = "labelRecipeName";
            labelRecipeName.Size = new Size(80, 22);
            labelRecipeName.TabIndex = 0;
            labelRecipeName.Text = "Tarif Adı";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label1.Location = new Point(531, 387);
            label1.Name = "label1";
            label1.Size = new Size(185, 40);
            label1.TabIndex = 2;
            label1.Text = "Malzemeler";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Arial", 14.25F);
            labelCategory.Location = new Point(311, 627);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(122, 22);
            labelCategory.TabIndex = 3;
            labelCategory.Text = "Tarif Kategori";
            // 
            // labelPreparationTime
            // 
            labelPreparationTime.AutoSize = true;
            labelPreparationTime.Font = new Font("Arial", 14.25F);
            labelPreparationTime.Location = new Point(296, 699);
            labelPreparationTime.Name = "labelPreparationTime";
            labelPreparationTime.Size = new Size(204, 22);
            labelPreparationTime.TabIndex = 4;
            labelPreparationTime.Text = "Tarif Hazırlanma Süresi";
            // 
            // labelInstructions
            // 
            labelInstructions.AutoSize = true;
            labelInstructions.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelInstructions.Location = new Point(531, 19);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.Size = new Size(172, 40);
            labelInstructions.TabIndex = 6;
            labelInstructions.Text = "Yonergeler";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(45, 78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(428, 428);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe Print", 20.25F, FontStyle.Bold);
            label4.Location = new Point(12, 683);
            label4.Name = "label4";
            label4.Size = new Size(278, 47);
            label4.TabIndex = 9;
            label4.Text = "Hazirlanma Suresi:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe Print", 20.25F, FontStyle.Bold);
            label5.Location = new Point(138, 539);
            label5.Name = "label5";
            label5.Size = new Size(152, 47);
            label5.TabIndex = 10;
            label5.Text = "Tarif Adi:";
            // 
            // panelInstructions
            // 
            panelInstructions.BackColor = SystemColors.ActiveBorder;
            panelInstructions.Font = new Font("Segoe Print", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            panelInstructions.Location = new Point(531, 78);
            panelInstructions.Name = "panelInstructions";
            panelInstructions.Size = new Size(672, 290);
            panelInstructions.TabIndex = 12;
            // 
            // panelIngredients
            // 
            panelIngredients.BackColor = SystemColors.ActiveBorder;
            panelIngredients.Font = new Font("Segoe Print", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            panelIngredients.Location = new Point(531, 440);
            panelIngredients.Name = "panelIngredients";
            panelIngredients.Size = new Size(672, 290);
            panelIngredients.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(12, 19);
            button1.Name = "button1";
            button1.Size = new Size(76, 40);
            button1.TabIndex = 14;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 20.25F, FontStyle.Bold);
            label3.Location = new Point(147, 611);
            label3.Name = "label3";
            label3.Size = new Size(143, 47);
            label3.TabIndex = 8;
            label3.Text = "Kategori:";
            // 
            // RecipeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1244, 767);
            Controls.Add(button1);
            Controls.Add(panelIngredients);
            Controls.Add(labelInstructions);
            Controls.Add(label1);
            Controls.Add(panelInstructions);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(labelPreparationTime);
            Controls.Add(labelCategory);
            Controls.Add(labelRecipeName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RecipeDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tarif Detay Sayfası";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRecipeName;
        private Label label1;
        private Label labelCategory;
        private Label labelPreparationTime;
        private Label labelInstructions;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label5;
        private Panel panelInstructions;
        private Panel panelIngredients;
        private Button button1;
        private Label label3;
    }
}