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
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(98, 52);
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
            label1.Font = new Font("Segoe Print", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(98, 314);
            label1.Name = "label1";
            label1.Size = new Size(110, 33);
            label1.TabIndex = 2;
            label1.Text = "Tarif Adı:";
            // 
            // textBoxName
            // 
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxName.Location = new Point(98, 360);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(200, 29);
            textBoxName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(98, 411);
            label2.Name = "label2";
            label2.Size = new Size(103, 33);
            label2.TabIndex = 4;
            label2.Text = "Kategori:";
            // 
            // comboBoxCatagory
            // 
            comboBoxCatagory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCatagory.FormattingEnabled = true;
            comboBoxCatagory.Location = new Point(98, 465);
            comboBoxCatagory.Name = "comboBoxCatagory";
            comboBoxCatagory.Size = new Size(200, 29);
            comboBoxCatagory.TabIndex = 5;
            // 
            // textBoxTime
            // 
            textBoxTime.BorderStyle = BorderStyle.FixedSingle;
            textBoxTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxTime.Location = new Point(98, 546);
            textBoxTime.Name = "textBoxTime";
            textBoxTime.Size = new Size(200, 29);
            textBoxTime.TabIndex = 6;
            textBoxTime.KeyPress += textBoxAmount_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(98, 501);
            label3.Name = "label3";
            label3.Size = new Size(65, 33);
            label3.TabIndex = 7;
            label3.Text = "Süre:";
            // 
            // buttonIngredientAdd
            // 
            buttonIngredientAdd.BackColor = Color.FromArgb(34, 197, 94);
            buttonIngredientAdd.FlatStyle = FlatStyle.Flat;
            buttonIngredientAdd.Location = new Point(381, 152);
            buttonIngredientAdd.Name = "buttonIngredientAdd";
            buttonIngredientAdd.Size = new Size(140, 34);
            buttonIngredientAdd.TabIndex = 8;
            buttonIngredientAdd.Text = "Malzeme Ekle";
            buttonIngredientAdd.UseVisualStyleBackColor = false;
            buttonIngredientAdd.Click += buttonAddIngredient_Click;
            // 
            // comboBoxIngredients
            // 
            comboBoxIngredients.Font = new Font("Segoe UI", 12F);
            comboBoxIngredients.FormattingEnabled = true;
            comboBoxIngredients.Location = new Point(381, 77);
            comboBoxIngredients.Name = "comboBoxIngredients";
            comboBoxIngredients.Size = new Size(281, 29);
            comboBoxIngredients.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe Print", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(381, 34);
            label4.Name = "label4";
            label4.Size = new Size(130, 33);
            label4.TabIndex = 10;
            label4.Text = "Malzemeler:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe Print", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(750, 34);
            label5.Name = "label5";
            label5.Size = new Size(124, 33);
            label5.TabIndex = 13;
            label5.Text = "Yönergeler:";
            // 
            // textBoxInstructions
            // 
            textBoxInstructions.BorderStyle = BorderStyle.FixedSingle;
            textBoxInstructions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxInstructions.Location = new Point(750, 77);
            textBoxInstructions.Name = "textBoxInstructions";
            textBoxInstructions.Size = new Size(319, 29);
            textBoxInstructions.TabIndex = 14;
            // 
            // buttonInstructionAdd
            // 
            buttonInstructionAdd.BackColor = Color.FromArgb(34, 197, 94);
            buttonInstructionAdd.FlatStyle = FlatStyle.Flat;
            buttonInstructionAdd.Location = new Point(750, 115);
            buttonInstructionAdd.Name = "buttonInstructionAdd";
            buttonInstructionAdd.Size = new Size(153, 46);
            buttonInstructionAdd.TabIndex = 15;
            buttonInstructionAdd.Text = "Yonerge Ekle";
            buttonInstructionAdd.UseVisualStyleBackColor = false;
            buttonInstructionAdd.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(192, 255, 255);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(98, 605);
            button3.Name = "button3";
            button3.Size = new Size(200, 41);
            button3.TabIndex = 18;
            button3.Text = "Düzenlemeleri Kaydet";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // listBoxIngredients
            // 
            listBoxIngredients.BackColor = Color.FromArgb(244, 244, 245);
            listBoxIngredients.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            listBoxIngredients.FormattingEnabled = true;
            listBoxIngredients.ItemHeight = 25;
            listBoxIngredients.Location = new Point(381, 192);
            listBoxIngredients.Name = "listBoxIngredients";
            listBoxIngredients.Size = new Size(281, 454);
            listBoxIngredients.TabIndex = 19;
            listBoxIngredients.SelectedIndexChanged += listBoxIngredients_SelectedIndexChanged;
            // 
            // listBoxInstructions
            // 
            listBoxInstructions.BackColor = Color.FromArgb(244, 244, 245);
            listBoxInstructions.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            listBoxInstructions.FormattingEnabled = true;
            listBoxInstructions.ItemHeight = 25;
            listBoxInstructions.Location = new Point(750, 167);
            listBoxInstructions.Name = "listBoxInstructions";
            listBoxInstructions.Size = new Size(319, 479);
            listBoxInstructions.TabIndex = 20;
            listBoxInstructions.SelectedIndexChanged += listBoxInstructions_SelectedIndexChanged;
            // 
            // buttonIngredientDelete
            // 
            buttonIngredientDelete.BackColor = Color.FromArgb(248, 113, 113);
            buttonIngredientDelete.FlatStyle = FlatStyle.Flat;
            buttonIngredientDelete.Location = new Point(527, 152);
            buttonIngredientDelete.Name = "buttonIngredientDelete";
            buttonIngredientDelete.Size = new Size(135, 34);
            buttonIngredientDelete.TabIndex = 21;
            buttonIngredientDelete.Text = "Malzeme Sil";
            buttonIngredientDelete.UseVisualStyleBackColor = false;
            buttonIngredientDelete.Click += buttonIngredientDelete_Click;
            // 
            // buttonInstructuionDelete
            // 
            buttonInstructuionDelete.BackColor = Color.FromArgb(248, 113, 113);
            buttonInstructuionDelete.FlatStyle = FlatStyle.Flat;
            buttonInstructuionDelete.Location = new Point(909, 115);
            buttonInstructuionDelete.Name = "buttonInstructuionDelete";
            buttonInstructuionDelete.Size = new Size(160, 46);
            buttonInstructuionDelete.TabIndex = 22;
            buttonInstructuionDelete.Text = "Yonerge Sil";
            buttonInstructuionDelete.UseVisualStyleBackColor = false;
            buttonInstructuionDelete.Click += buttonInstructuionDelete_Click;
            // 
            // textBoxAmount
            // 
            textBoxAmount.BorderStyle = BorderStyle.FixedSingle;
            textBoxAmount.Font = new Font("Segoe UI", 12F);
            textBoxAmount.Location = new Point(381, 115);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(281, 29);
            textBoxAmount.TabIndex = 23;
            textBoxAmount.KeyPress += textBoxAmount_KeyPress;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(165, 180, 252);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(98, 262);
            button2.Name = "button2";
            button2.Size = new Size(200, 34);
            button2.TabIndex = 24;
            button2.Text = "Resmi Düzenle";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // RecipeEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1129, 688);
            Controls.Add(button2);
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
            FormBorderStyle = FormBorderStyle.None;
            Name = "RecipeEditForm";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button button2;
    }
}