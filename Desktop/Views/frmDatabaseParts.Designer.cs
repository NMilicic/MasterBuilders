namespace Desktop.Views
{
    partial class frmDatabaseParts
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
            this.btnWishlist = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.nudWishlist = new System.Windows.Forms.NumericUpDown();
            this.nudInventory = new System.Windows.Forms.NumericUpDown();
            this.lblDivider2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblcategory = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudWishlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWishlist
            // 
            this.btnWishlist.Location = new System.Drawing.Point(71, 376);
            this.btnWishlist.Name = "btnWishlist";
            this.btnWishlist.Size = new System.Drawing.Size(90, 25);
            this.btnWishlist.TabIndex = 13;
            this.btnWishlist.Text = "Add to Wishlist";
            this.btnWishlist.UseVisualStyleBackColor = true;
            this.btnWishlist.Click += new System.EventHandler(this.btnWishlist_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(231, 376);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(95, 25);
            this.btnInventory.TabIndex = 14;
            this.btnInventory.Text = "Add to Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // nudWishlist
            // 
            this.nudWishlist.Location = new System.Drawing.Point(15, 378);
            this.nudWishlist.Name = "nudWishlist";
            this.nudWishlist.Size = new System.Drawing.Size(50, 20);
            this.nudWishlist.TabIndex = 17;
            // 
            // nudInventory
            // 
            this.nudInventory.Location = new System.Drawing.Point(175, 378);
            this.nudInventory.Name = "nudInventory";
            this.nudInventory.Size = new System.Drawing.Size(50, 20);
            this.nudInventory.TabIndex = 18;
            // 
            // lblDivider2
            // 
            this.lblDivider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider2.Location = new System.Drawing.Point(167, 376);
            this.lblDivider2.Name = "lblDivider2";
            this.lblDivider2.Size = new System.Drawing.Size(2, 25);
            this.lblDivider2.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Location = new System.Drawing.Point(540, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(395, 15);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(121, 21);
            this.cmbColor.TabIndex = 26;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(355, 18);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 25;
            this.lblColor.Text = "Color:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(228, 15);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 24;
            // 
            // lblcategory
            // 
            this.lblcategory.AutoSize = true;
            this.lblcategory.Location = new System.Drawing.Point(170, 18);
            this.lblcategory.Name = "lblcategory";
            this.lblcategory.Size = new System.Drawing.Size(52, 13);
            this.lblcategory.TabIndex = 23;
            this.lblcategory.Text = "Category:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(58, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 22;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "Name:";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(15, 45);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(600, 325);
            this.dataGridView.TabIndex = 20;
            // 
            // frmDatabaseParts
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.ControlBox = false;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblcategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.lblDivider2);
            this.Controls.Add(this.nudInventory);
            this.Controls.Add(this.nudWishlist);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnWishlist);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabaseParts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parts Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDatabaseParts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWishlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnWishlist;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.NumericUpDown nudWishlist;
        private System.Windows.Forms.NumericUpDown nudInventory;
        private System.Windows.Forms.Label lblDivider2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblcategory;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}