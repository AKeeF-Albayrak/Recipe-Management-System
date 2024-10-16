namespace LezzetKitabi.Forms.Controls
{
    partial class IngredientAddForm
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
            txtUnit = new TextBox();
            lblUnitPrice = new Label();
            txtUnitPrice = new TextBox();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // lblIngredientName
            // 
            lblIngredientName.AutoSize = true;
            lblIngredientName.Location = new Point(161, 137);
            lblIngredientName.Margin = new Padding(4, 0, 4, 0);
            lblIngredientName.Name = "lblIngredientName";
            lblIngredientName.Size = new Size(79, 15);
            lblIngredientName.TabIndex = 0;
            lblIngredientName.Text = "Malzeme Adı:";
            // 
            // txtIngredientName
            // 
            txtIngredientName.Location = new Point(278, 134);
            txtIngredientName.Margin = new Padding(4, 3, 4, 3);
            txtIngredientName.Name = "txtIngredientName";
            txtIngredientName.Size = new Size(233, 23);
            txtIngredientName.TabIndex = 1;
            // 
            // lblTotalQuantity
            // 
            lblTotalQuantity.AutoSize = true;
            lblTotalQuantity.Location = new Point(161, 183);
            lblTotalQuantity.Margin = new Padding(4, 0, 4, 0);
            lblTotalQuantity.Name = "lblTotalQuantity";
            lblTotalQuantity.Size = new Size(86, 15);
            lblTotalQuantity.TabIndex = 2;
            lblTotalQuantity.Text = "Toplam Miktar:";
            // 
            // txtTotalQuantity
            // 
            txtTotalQuantity.Location = new Point(278, 180);
            txtTotalQuantity.Margin = new Padding(4, 3, 4, 3);
            txtTotalQuantity.Name = "txtTotalQuantity";
            txtTotalQuantity.Size = new Size(233, 23);
            txtTotalQuantity.TabIndex = 3;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(161, 229);
            lblUnit.Margin = new Padding(4, 0, 4, 0);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(38, 15);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "Birim:";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(278, 226);
            txtUnit.Margin = new Padding(4, 3, 4, 3);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(233, 23);
            txtUnit.TabIndex = 5;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(161, 276);
            lblUnitPrice.Margin = new Padding(4, 0, 4, 0);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(69, 15);
            lblUnitPrice.TabIndex = 6;
            lblUnitPrice.Text = "Birim Fiyatı:";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(278, 272);
            txtUnitPrice.Margin = new Padding(4, 3, 4, 3);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(233, 23);
            txtUnitPrice.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(278, 322);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 27);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // IngredientControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAdd);
            Controls.Add(txtUnitPrice);
            Controls.Add(lblUnitPrice);
            Controls.Add(txtUnit);
            Controls.Add(lblUnit);
            Controls.Add(txtTotalQuantity);
            Controls.Add(lblTotalQuantity);
            Controls.Add(txtIngredientName);
            Controls.Add(lblIngredientName);
            Margin = new Padding(4, 3, 4, 3);
            Name = "IngredientControl";
            Size = new Size(624, 567);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIngredientName;
        private System.Windows.Forms.TextBox txtIngredientName;
        private System.Windows.Forms.Label lblTotalQuantity;
        private System.Windows.Forms.TextBox txtTotalQuantity;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Button btnAdd;
    }
}
