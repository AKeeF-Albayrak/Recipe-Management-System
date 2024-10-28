namespace LezzetKitabi.Forms.Controls
{
    partial class IngredientAddControl
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
            lblIngredientName = new Label();
            txtIngredientName = new TextBox();
            lblTotalQuantity = new Label();
            txtTotalQuantity = new TextBox();
            lblUnit = new Label();
            lblUnitPrice = new Label();
            txtUnitPrice = new TextBox();
            btnAdd = new Button();
            label1 = new Label();
            cmbUnit = new ComboBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblIngredientName
            // 
            lblIngredientName.AutoSize = true;
            lblIngredientName.BackColor = Color.Transparent;
            lblIngredientName.Font = new Font("Segoe Print", 15.75F);
            lblIngredientName.Location = new Point(745, 256);
            lblIngredientName.Margin = new Padding(4, 0, 4, 0);
            lblIngredientName.Name = "lblIngredientName";
            lblIngredientName.Size = new Size(158, 36);
            lblIngredientName.TabIndex = 0;
            lblIngredientName.Text = "Malzeme Adı:";
            // 
            // txtIngredientName
            // 
            txtIngredientName.Font = new Font("Segoe UI", 15.75F);
            txtIngredientName.Location = new Point(955, 257);
            txtIngredientName.Margin = new Padding(4, 3, 4, 3);
            txtIngredientName.Name = "txtIngredientName";
            txtIngredientName.Size = new Size(233, 35);
            txtIngredientName.TabIndex = 1;
            // 
            // lblTotalQuantity
            // 
            lblTotalQuantity.AutoSize = true;
            lblTotalQuantity.BackColor = Color.Transparent;
            lblTotalQuantity.Font = new Font("Segoe Print", 15.75F);
            lblTotalQuantity.Location = new Point(745, 320);
            lblTotalQuantity.Margin = new Padding(4, 0, 4, 0);
            lblTotalQuantity.Name = "lblTotalQuantity";
            lblTotalQuantity.Size = new Size(180, 36);
            lblTotalQuantity.TabIndex = 2;
            lblTotalQuantity.Text = "Toplam Miktar:";
            // 
            // txtTotalQuantity
            // 
            txtTotalQuantity.Font = new Font("Segoe UI", 15.75F);
            txtTotalQuantity.Location = new Point(955, 319);
            txtTotalQuantity.Margin = new Padding(4, 3, 4, 3);
            txtTotalQuantity.Name = "txtTotalQuantity";
            txtTotalQuantity.Size = new Size(233, 35);
            txtTotalQuantity.TabIndex = 3;
            txtTotalQuantity.KeyPress += txtTotalQuantity_KeyPress;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.BackColor = Color.Transparent;
            lblUnit.Font = new Font("Segoe Print", 15.75F);
            lblUnit.Location = new Point(745, 383);
            lblUnit.Margin = new Padding(4, 0, 4, 0);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(81, 36);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "Birim:";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.BackColor = Color.Transparent;
            lblUnitPrice.Font = new Font("Segoe Print", 15.75F);
            lblUnitPrice.Location = new Point(745, 448);
            lblUnitPrice.Margin = new Padding(4, 0, 4, 0);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(147, 36);
            lblUnitPrice.TabIndex = 6;
            lblUnitPrice.Text = "Birim Fiyatı:";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Font = new Font("Segoe UI", 15.75F);
            txtUnitPrice.Location = new Point(955, 449);
            txtUnitPrice.Margin = new Padding(4, 3, 4, 3);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(233, 35);
            txtUnitPrice.TabIndex = 7;
            txtUnitPrice.KeyPress += txtTotalQuantity_KeyPress;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(737, 543);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(10, 20, 10, 20);
            btnAdd.Size = new Size(451, 81);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Ekle";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe Print", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(701, 101);
            label1.Name = "label1";
            label1.Size = new Size(487, 85);
            label1.TabIndex = 9;
            label1.Text = "Yeni Malzeme Ekle";
            // 
            // cmbUnit
            // 
            cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnit.Font = new Font("Segoe UI", 15.75F);
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Location = new Point(955, 383);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(233, 38);
            cmbUnit.TabIndex = 10;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(244, 244, 245);
            pictureBox1.Location = new Point(92, 101);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(514, 469);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(165, 180, 252);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(92, 588);
            button1.Name = "button1";
            button1.Size = new Size(514, 36);
            button1.TabIndex = 12;
            button1.Text = "Resim Yükle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // IngredientAddControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(cmbUnit);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(txtUnitPrice);
            Controls.Add(lblUnitPrice);
            Controls.Add(lblUnit);
            Controls.Add(txtTotalQuantity);
            Controls.Add(lblTotalQuantity);
            Controls.Add(txtIngredientName);
            Controls.Add(lblIngredientName);
            Margin = new Padding(4, 3, 4, 3);
            Name = "IngredientAddControl";
            Size = new Size(1323, 796);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIngredientName;
        private System.Windows.Forms.TextBox txtIngredientName;
        private System.Windows.Forms.Label lblTotalQuantity;
        private System.Windows.Forms.TextBox txtTotalQuantity;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Button btnAdd;
        private Label label1;
        private ComboBox cmbUnit;
        private PictureBox pictureBox1;
        private Button button1;
    }
}
