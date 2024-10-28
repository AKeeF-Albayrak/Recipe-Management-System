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
            pictureBoxIngredient = new PictureBox();
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
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIngredient).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxIngredient
            // 
            pictureBoxIngredient.Location = new Point(54, 44);
            pictureBoxIngredient.Name = "pictureBoxIngredient";
            pictureBoxIngredient.Size = new Size(232, 232);
            pictureBoxIngredient.TabIndex = 0;
            pictureBoxIngredient.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F);
            label1.Location = new Point(347, 62);
            label1.Name = "label1";
            label1.Size = new Size(140, 30);
            label1.TabIndex = 1;
            label1.Text = "Malzeme Adi:";
            // 
            // textBoxIngredientName
            // 
            textBoxIngredientName.Font = new Font("Segoe UI", 15.75F);
            textBoxIngredientName.Location = new Point(510, 62);
            textBoxIngredientName.Name = "textBoxIngredientName";
            textBoxIngredientName.Size = new Size(138, 35);
            textBoxIngredientName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F);
            label2.Location = new Point(422, 133);
            label2.Name = "label2";
            label2.Size = new Size(65, 30);
            label2.TabIndex = 3;
            label2.Text = "Birim:";
            // 
            // textBoxAmount
            // 
            textBoxAmount.Font = new Font("Segoe UI", 15.75F);
            textBoxAmount.Location = new Point(510, 202);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(138, 35);
            textBoxAmount.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F);
            label3.Location = new Point(410, 202);
            label3.Name = "label3";
            label3.Size = new Size(77, 30);
            label3.TabIndex = 5;
            label3.Text = "Miktar:";
            // 
            // comboBoxUnit
            // 
            comboBoxUnit.Font = new Font("Segoe UI", 15.75F);
            comboBoxUnit.FormattingEnabled = true;
            comboBoxUnit.Location = new Point(510, 125);
            comboBoxUnit.Name = "comboBoxUnit";
            comboBoxUnit.Size = new Size(138, 38);
            comboBoxUnit.TabIndex = 6;
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonEdit.Location = new Point(33, 349);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(670, 42);
            buttonEdit.TabIndex = 7;
            buttonEdit.Text = "Düzenle";
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
            textBoxUnitPrice.Font = new Font("Segoe UI", 15.75F);
            textBoxUnitPrice.Location = new Point(510, 269);
            textBoxUnitPrice.Name = "textBoxUnitPrice";
            textBoxUnitPrice.Size = new Size(138, 35);
            textBoxUnitPrice.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F);
            label4.Location = new Point(373, 274);
            label4.Name = "label4";
            label4.Size = new Size(114, 30);
            label4.TabIndex = 10;
            label4.Text = "Birim Fiyat:";
            // 
            // button1
            // 
            button1.Location = new Point(128, 298);
            button1.Name = "button1";
            button1.Size = new Size(91, 23);
            button1.TabIndex = 11;
            button1.Text = "Resmi Duzen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // IngredientEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 412);
            Controls.Add(button1);
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
            Controls.Add(pictureBoxIngredient);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IngredientEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IngredientEditForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxIngredient).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxIngredient;
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
        private Button button1;
    }
}