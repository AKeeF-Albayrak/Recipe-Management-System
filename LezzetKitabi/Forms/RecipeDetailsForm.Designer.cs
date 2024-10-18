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
            SuspendLayout();
            // 
            // labelRecipeName
            // 
            labelRecipeName.AutoSize = true;
            labelRecipeName.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRecipeName.Location = new Point(142, 72);
            labelRecipeName.Name = "labelRecipeName";
            labelRecipeName.Size = new Size(120, 50);
            labelRecipeName.TabIndex = 0;
            labelRecipeName.Text = "label1";
            // 
            // richTextBoxIngredients
            // 
            richTextBoxIngredients.Location = new Point(504, 201);
            richTextBoxIngredients.Name = "richTextBoxIngredients";
            richTextBoxIngredients.Size = new Size(379, 258);
            richTextBoxIngredients.TabIndex = 1;
            richTextBoxIngredients.Text = "";
            // 
            // RecipeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 559);
            Controls.Add(richTextBoxIngredients);
            Controls.Add(labelRecipeName);
            Name = "RecipeDetailsForm";
            Text = "RecipeDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRecipeName;
        private RichTextBox richTextBoxIngredients;
    }
}