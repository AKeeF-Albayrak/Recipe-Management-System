namespace LezzetKitabi.Forms
{
    partial class RecipeEditForm
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            textBoxName = new TextBox();
            label2 = new Label();
            comboBoxCatagory = new ComboBox();
            textBoxTime = new TextBox();
            label3 = new Label();
            buttonIngredientAdd = new Button();
            comboBoxIngredients = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            textBoxInstructions = new TextBox();
            buttonInstructionAdd = new Button();
            button3 = new Button();
            listBoxIngredients = new ListBox();
            listBoxInstructions = new ListBox();
            buttonIngredientDelete = new Button();
            buttonInstructuionDelete = new Button();
            textBoxAmount = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(98, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(65, 23);
            button1.TabIndex = 1;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(98, 267);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 2;
            label1.Text = "Tarif Adi:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(98, 313);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(181, 23);
            textBoxName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(98, 362);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 4;
            label2.Text = "Kategori:";
            // 
            // comboBoxCatagory
            // 
            comboBoxCatagory.FormattingEnabled = true;
            comboBoxCatagory.Location = new Point(98, 406);
            comboBoxCatagory.Name = "comboBoxCatagory";
            comboBoxCatagory.Size = new Size(181, 23);
            comboBoxCatagory.TabIndex = 5;
            // 
            // textBoxTime
            // 
            textBoxTime.Location = new Point(98, 501);
            textBoxTime.Name = "textBoxTime";
            textBoxTime.Size = new Size(181, 23);
            textBoxTime.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(98, 455);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 7;
            label3.Text = "Sure:";
            // 
            // buttonIngredientAdd
            // 
            buttonIngredientAdd.Location = new Point(407, 138);
            buttonIngredientAdd.Name = "buttonIngredientAdd";
            buttonIngredientAdd.Size = new Size(107, 23);
            buttonIngredientAdd.TabIndex = 8;
            buttonIngredientAdd.Text = "Malzeme Ekle";
            buttonIngredientAdd.UseVisualStyleBackColor = true;
            buttonIngredientAdd.Click += buttonAddIngredient_Click;
            // 
            // comboBoxIngredients
            // 
            comboBoxIngredients.FormattingEnabled = true;
            comboBoxIngredients.Location = new Point(409, 68);
            comboBoxIngredients.Name = "comboBoxIngredients";
            comboBoxIngredients.Size = new Size(218, 23);
            comboBoxIngredients.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(407, 30);
            label4.Name = "label4";
            label4.Size = new Size(115, 25);
            label4.TabIndex = 10;
            label4.Text = "Malzemeler:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(788, 30);
            label5.Name = "label5";
            label5.Size = new Size(107, 25);
            label5.TabIndex = 13;
            label5.Text = "Yonergeler:";
            // 
            // textBoxInstructions
            // 
            textBoxInstructions.Location = new Point(788, 82);
            textBoxInstructions.Name = "textBoxInstructions";
            textBoxInstructions.Size = new Size(319, 23);
            textBoxInstructions.TabIndex = 14;
            // 
            // buttonInstructionAdd
            // 
            buttonInstructionAdd.Location = new Point(788, 121);
            buttonInstructionAdd.Name = "buttonInstructionAdd";
            buttonInstructionAdd.Size = new Size(165, 23);
            buttonInstructionAdd.TabIndex = 15;
            buttonInstructionAdd.Text = "Yonerge Ekle";
            buttonInstructionAdd.UseVisualStyleBackColor = true;
            buttonInstructionAdd.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(98, 600);
            button3.Name = "button3";
            button3.Size = new Size(181, 51);
            button3.TabIndex = 18;
            button3.Text = "Kaydet";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBoxIngredients
            // 
            listBoxIngredients.FormattingEnabled = true;
            listBoxIngredients.ItemHeight = 15;
            listBoxIngredients.Location = new Point(409, 167);
            listBoxIngredients.Name = "listBoxIngredients";
            listBoxIngredients.Size = new Size(218, 484);
            listBoxIngredients.TabIndex = 19;
            // 
            // listBoxInstructions
            // 
            listBoxInstructions.FormattingEnabled = true;
            listBoxInstructions.ItemHeight = 15;
            listBoxInstructions.Location = new Point(788, 167);
            listBoxInstructions.Name = "listBoxInstructions";
            listBoxInstructions.Size = new Size(319, 484);
            listBoxInstructions.TabIndex = 20;
            // 
            // buttonIngredientDelete
            // 
            buttonIngredientDelete.Location = new Point(520, 138);
            buttonIngredientDelete.Name = "buttonIngredientDelete";
            buttonIngredientDelete.Size = new Size(107, 23);
            buttonIngredientDelete.TabIndex = 21;
            buttonIngredientDelete.Text = "Malzeme Sil";
            buttonIngredientDelete.UseVisualStyleBackColor = true;
            buttonIngredientDelete.Click += buttonIngredientDelete_Click;
            // 
            // buttonInstructuionDelete
            // 
            buttonInstructuionDelete.Location = new Point(959, 121);
            buttonInstructuionDelete.Name = "buttonInstructuionDelete";
            buttonInstructuionDelete.Size = new Size(148, 23);
            buttonInstructuionDelete.TabIndex = 22;
            buttonInstructuionDelete.Text = "Yonerge Sil";
            buttonInstructuionDelete.UseVisualStyleBackColor = true;
            buttonInstructuionDelete.Click += buttonInstructuionDelete_Click;
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new Point(409, 97);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(218, 23);
            textBoxAmount.TabIndex = 23;
            // 
            // RecipeEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1229, 753);
            Controls.Add(textBoxAmount);
            Controls.Add(buttonInstructuionDelete);
            Controls.Add(buttonIngredientDelete);
            Controls.Add(listBoxInstructions);
            Controls.Add(listBoxIngredients);
            Controls.Add(button3);
            Controls.Add(buttonInstructionAdd);
            Controls.Add(textBoxInstructions);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBoxIngredients);
            Controls.Add(buttonIngredientAdd);
            Controls.Add(label3);
            Controls.Add(textBoxTime);
            Controls.Add(comboBoxCatagory);
            Controls.Add(label2);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "RecipeEditForm";
            Text = "RecipeEditForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private TextBox textBoxName;
        private Label label2;
        private ComboBox comboBoxCatagory;
        private TextBox textBoxTime;
        private Label label3;
        private Button buttonIngredientAdd;
        private ComboBox comboBoxIngredients;
        private Label label4;
        private Label label5;
        private TextBox textBoxInstructions;
        private Button buttonInstructionAdd;
        private Button button3;
        private ListBox listBoxIngredients;
        private ListBox listBoxInstructions;
        private Button buttonIngredientDelete;
        private Button buttonInstructuionDelete;
        private TextBox textBoxAmount;
    }
}