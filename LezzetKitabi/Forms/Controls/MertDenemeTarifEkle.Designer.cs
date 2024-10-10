namespace LezzetKitabi.Forms.Controls
{
    partial class MertDenemeTarifEkle
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
            txtRecipeName = new TextBox();
            txtCategory = new TextBox();
            txtInstructions = new TextBox();
            button1 = new Button();
            label1 = new Label();
            Category = new Label();
            PreparationTime = new Label();
            label4 = new Label();
            numPreparationTime = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numPreparationTime).BeginInit();
            SuspendLayout();
            // 
            // txtRecipeName
            // 
            txtRecipeName.Location = new Point(157, 68);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(229, 23);
            txtRecipeName.TabIndex = 0;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(157, 125);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(229, 23);
            txtCategory.TabIndex = 1;
            // 
            // txtInstructions
            // 
            txtInstructions.Location = new Point(157, 245);
            txtInstructions.Name = "txtInstructions";
            txtInstructions.Size = new Size(229, 23);
            txtInstructions.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(206, 314);
            button1.Name = "button1";
            button1.Size = new Size(119, 23);
            button1.TabIndex = 4;
            button1.Text = "tarifi kaydet";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 71);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 5;
            label1.Text = "RecipeName ";
            // 
            // Category
            // 
            Category.AutoSize = true;
            Category.Location = new Point(63, 129);
            Category.Name = "Category";
            Category.Size = new Size(55, 15);
            Category.TabIndex = 6;
            Category.Text = "Category";
            // 
            // PreparationTime
            // 
            PreparationTime.AutoSize = true;
            PreparationTime.Location = new Point(43, 191);
            PreparationTime.Name = "PreparationTime";
            PreparationTime.Size = new Size(94, 15);
            PreparationTime.TabIndex = 7;
            PreparationTime.Text = "PreparationTime";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 248);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 8;
            label4.Text = "Instructions";
            // 
            // numPreparationTime
            // 
            numPreparationTime.Location = new Point(157, 189);
            numPreparationTime.Name = "numPreparationTime";
            numPreparationTime.Size = new Size(120, 23);
            numPreparationTime.TabIndex = 9;
            // 
            // MertDenemeTarifEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numPreparationTime);
            Controls.Add(label4);
            Controls.Add(PreparationTime);
            Controls.Add(Category);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(txtInstructions);
            Controls.Add(txtCategory);
            Controls.Add(txtRecipeName);
            Name = "MertDenemeTarifEkle";
            Size = new Size(783, 560);
            ((System.ComponentModel.ISupportInitialize)numPreparationTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRecipeName;
        private TextBox txtCategory;
        private TextBox txtInstructions;
        private Button button1;
        private Label label1;
        private Label Category;
        private Label PreparationTime;
        private Label label4;
        private NumericUpDown numPreparationTime;
    }
}
