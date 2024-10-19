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
            labelRecipeName = new Label();
            richTextBoxIngredients = new RichTextBox();
            label1 = new Label();
            labelCategory = new Label();
            labelPreparationTime = new Label();
            label2 = new Label();
            textBoxInstructions = new RichTextBox();
            SuspendLayout();
            // 
            // labelRecipeName
            // 
            labelRecipeName.AutoSize = true;
            labelRecipeName.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRecipeName.Location = new Point(43, 59);
            labelRecipeName.Name = "labelRecipeName";
            labelRecipeName.Size = new Size(155, 50);
            labelRecipeName.TabIndex = 0;
            labelRecipeName.Text = "Tarif Adı";
            // 
            // richTextBoxIngredients
            // 
            richTextBoxIngredients.Enabled = false;
            richTextBoxIngredients.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxIngredients.Location = new Point(506, 121);
            richTextBoxIngredients.Name = "richTextBoxIngredients";
            richTextBoxIngredients.Size = new Size(336, 608);
            richTextBoxIngredients.TabIndex = 1;
            richTextBoxIngredients.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(506, 59);
            label1.Name = "label1";
            label1.Size = new Size(160, 40);
            label1.TabIndex = 2;
            label1.Text = "Ingredients";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCategory.Location = new Point(43, 121);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(238, 50);
            labelCategory.TabIndex = 3;
            labelCategory.Text = "Tarif Kategori";
            // 
            // labelPreparationTime
            // 
            labelPreparationTime.AutoSize = true;
            labelPreparationTime.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPreparationTime.Location = new Point(43, 213);
            labelPreparationTime.Name = "labelPreparationTime";
            labelPreparationTime.Size = new Size(392, 50);
            labelPreparationTime.TabIndex = 4;
            labelPreparationTime.Text = "Tarif Hazırlanma Süresi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(882, 59);
            label2.Name = "label2";
            label2.Size = new Size(164, 40);
            label2.TabIndex = 6;
            label2.Text = "Instructions";
            // 
            // textBoxInstructions
            // 
            textBoxInstructions.Enabled = false;
            textBoxInstructions.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxInstructions.Location = new Point(882, 121);
            textBoxInstructions.Name = "textBoxInstructions";
            textBoxInstructions.Size = new Size(336, 608);
            textBoxInstructions.TabIndex = 5;
            textBoxInstructions.Text = "";
            // 
            // RecipeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 767);
            Controls.Add(label2);
            Controls.Add(textBoxInstructions);
            Controls.Add(labelPreparationTime);
            Controls.Add(labelCategory);
            Controls.Add(label1);
            Controls.Add(richTextBoxIngredients);
            Controls.Add(labelRecipeName);
            Name = "RecipeDetailsForm";
            Text = "Tarif Detay Sayfası";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRecipeName;
        private RichTextBox richTextBoxIngredients;
        private Label label1;
        private Label labelCategory;
        private Label labelPreparationTime;
        private Label label2;
        private RichTextBox textBoxInstructions;
    }
}