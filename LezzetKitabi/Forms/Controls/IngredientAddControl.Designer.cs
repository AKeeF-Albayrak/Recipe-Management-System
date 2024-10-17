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
            SuspendLayout();
            // 
            // lblIngredientName
            // 
            lblIngredientName.AutoSize = true;
            lblIngredientName.BackColor = Color.Transparent;
            lblIngredientName.Font = new Font("Segoe Print", 15.75F);
            lblIngredientName.Location = new Point(745, 226);
            lblIngredientName.Margin = new Padding(4, 0, 4, 0);
            lblIngredientName.Name = "lblIngredientName";
            lblIngredientName.Size = new Size(158, 36);
            lblIngredientName.TabIndex = 0;
            lblIngredientName.Text = "Malzeme Adı:";
            // 
            // txtIngredientName
            // 
            txtIngredientName.Font = new Font("Segoe UI", 15.75F);
            txtIngredientName.Location = new Point(955, 227);
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
            lblTotalQuantity.Location = new Point(745, 290);
            lblTotalQuantity.Margin = new Padding(4, 0, 4, 0);
            lblTotalQuantity.Name = "lblTotalQuantity";
            lblTotalQuantity.Size = new Size(180, 36);
            lblTotalQuantity.TabIndex = 2;
            lblTotalQuantity.Text = "Toplam Miktar:";
            // 
            // txtTotalQuantity
            // 
            txtTotalQuantity.Font = new Font("Segoe UI", 15.75F);
            txtTotalQuantity.Location = new Point(955, 289);
            txtTotalQuantity.Margin = new Padding(4, 3, 4, 3);
            txtTotalQuantity.Name = "txtTotalQuantity";
            txtTotalQuantity.Size = new Size(233, 35);
            txtTotalQuantity.TabIndex = 3;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.BackColor = Color.Transparent;
            lblUnit.Font = new Font("Segoe Print", 15.75F);
            lblUnit.Location = new Point(745, 353);
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
            lblUnitPrice.Location = new Point(745, 418);
            lblUnitPrice.Margin = new Padding(4, 0, 4, 0);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(147, 36);
            lblUnitPrice.TabIndex = 6;
            lblUnitPrice.Text = "Birim Fiyatı:";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Font = new Font("Segoe UI", 15.75F);
            txtUnitPrice.Location = new Point(955, 419);
            txtUnitPrice.Margin = new Padding(4, 3, 4, 3);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(233, 35);
            txtUnitPrice.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.Font = new Font("Segoe Print", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(868, 545);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(10, 20, 10, 20);
            btnAdd.Size = new Size(228, 79);
            btnAdd.TabIndex = 8;
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
            label1.Location = new Point(637, 70);
            label1.Name = "label1";
            label1.Size = new Size(606, 85);
            label1.TabIndex = 9;
            label1.Text = "  Add New Ingredient  ";
            // 
            // cmbUnit
            // 
            cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnit.Font = new Font("Segoe UI", 15.75F);
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Location = new Point(955, 353);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(233, 38);
            cmbUnit.TabIndex = 10;
            // 
            // IngredientAddControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
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
    }
}
