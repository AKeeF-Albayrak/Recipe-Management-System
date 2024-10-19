namespace LezzetKitabi.Forms
{
    partial class IngredientEditForm
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
            label1 = new Label();
            textBoxIngredientName = new TextBox();
            label2 = new Label();
            textBoxAmount = new TextBox();
            label3 = new Label();
            comboBoxUnit = new ComboBox();
            buttonEdit = new Button();
            button2 = new Button();
            textBoxUnitPrice = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(55, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(196, 22);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "Malzeme Adi:";
            // 
            // textBoxIngredientName
            // 
            textBoxIngredientName.Location = new Point(297, 19);
            textBoxIngredientName.Name = "textBoxIngredientName";
            textBoxIngredientName.Size = new Size(138, 23);
            textBoxIngredientName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 71);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "Birim:";
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new Point(297, 114);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(138, 23);
            textBoxAmount.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(231, 114);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 5;
            label3.Text = "Miktar:";
            // 
            // comboBoxUnit
            // 
            comboBoxUnit.FormattingEnabled = true;
            comboBoxUnit.Location = new Point(297, 68);
            comboBoxUnit.Name = "comboBoxUnit";
            comboBoxUnit.Size = new Size(138, 23);
            comboBoxUnit.TabIndex = 6;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(55, 210);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(380, 23);
            buttonEdit.TabIndex = 7;
            buttonEdit.Text = "Duzenle";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 14);
            button2.Name = "button2";
            button2.Size = new Size(27, 23);
            button2.TabIndex = 8;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBoxUnitPrice
            // 
            textBoxUnitPrice.Location = new Point(297, 159);
            textBoxUnitPrice.Name = "textBoxUnitPrice";
            textBoxUnitPrice.Size = new Size(138, 23);
            textBoxUnitPrice.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(209, 162);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 10;
            label4.Text = "Birim Fiyat:";
            // 
            // IngredientEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 260);
            Controls.Add(label4);
            Controls.Add(textBoxUnitPrice);
            Controls.Add(button2);
            Controls.Add(buttonEdit);
            Controls.Add(comboBoxUnit);
            Controls.Add(label3);
            Controls.Add(textBoxAmount);
            Controls.Add(label2);
            Controls.Add(textBoxIngredientName);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IngredientEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IngredientEditForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox textBoxIngredientName;
        private Label label2;
        private TextBox textBoxAmount;
        private Label label3;
        private ComboBox comboBoxUnit;
        private Button buttonEdit;
        private Button button2;
        private TextBox textBoxUnitPrice;
        private Label label4;
    }
}