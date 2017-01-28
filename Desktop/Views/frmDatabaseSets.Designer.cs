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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTheme = new System.Windows.Forms.Label();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.lblSubtheme = new System.Windows.Forms.Label();
            this.cmbSubtheme = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblDivider1 = new System.Windows.Forms.Label();
            this.btnWishlist = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnPartlist = new System.Windows.Forms.Button();
            this.nudWishlist = new System.Windows.Forms.NumericUpDown();
            this.nudInventory = new System.Windows.Forms.NumericUpDown();
            this.lblDivider2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWishlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 64);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(600, 300);
            this.dataGridView.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(101, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(145, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(251, 9);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(43, 13);
            this.lblTheme.TabIndex = 3;
            this.lblTheme.Text = "Theme:";
            // 
            // cmbTheme
            // 
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Location = new System.Drawing.Point(300, 8);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(121, 21);
            this.cmbTheme.TabIndex = 4;
            this.cmbTheme.SelectedIndexChanged += new System.EventHandler(this.cmbTheme_SelectedIndexChanged);
            // 
            // lblSubtheme
            // 
            this.lblSubtheme.AutoSize = true;
            this.lblSubtheme.Location = new System.Drawing.Point(427, 10);
            this.lblSubtheme.Name = "lblSubtheme";
            this.lblSubtheme.Size = new System.Drawing.Size(58, 13);
            this.lblSubtheme.TabIndex = 5;
            this.lblSubtheme.Text = "Subtheme:";
            // 
            // cmbSubtheme
            // 
            this.cmbSubtheme.FormattingEnabled = true;
            this.cmbSubtheme.Location = new System.Drawing.Point(491, 8);
            this.cmbSubtheme.Name = "cmbSubtheme";
            this.cmbSubtheme.Size = new System.Drawing.Size(121, 21);
            this.cmbSubtheme.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Location = new System.Drawing.Point(12, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 50);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblDivider1
            // 
            this.lblDivider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider1.Location = new System.Drawing.Point(93, 7);
            this.lblDivider1.Name = "lblDivider1";
            this.lblDivider1.Size = new System.Drawing.Size(2, 50);
            this.lblDivider1.TabIndex = 12;
            // 
            // btnWishlist
            // 
            this.btnWishlist.Location = new System.Drawing.Point(68, 376);
            this.btnWishlist.Name = "btnWishlist";
            this.btnWishlist.Size = new System.Drawing.Size(90, 25);
            this.btnWishlist.TabIndex = 13;
            this.btnWishlist.Text = "Add to Wishlist";
            this.btnWishlist.UseVisualStyleBackColor = true;
            this.btnWishlist.Click += new System.EventHandler(this.btnWishlist_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(228, 376);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(95, 25);
            this.btnInventory.TabIndex = 14;
            this.btnInventory.Text = "Add to Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(487, 376);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(125, 25);
            this.btnDownload.TabIndex = 15;
            this.btnDownload.Text = "Download Instructions";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnPartlist
            // 
            this.btnPartlist.Location = new System.Drawing.Point(406, 376);
            this.btnPartlist.Name = "btnPartlist";
            this.btnPartlist.Size = new System.Drawing.Size(75, 25);
            this.btnPartlist.TabIndex = 16;
            this.btnPartlist.Text = "View Partlist";
            this.btnPartlist.UseVisualStyleBackColor = true;
            this.btnPartlist.Click += new System.EventHandler(this.btnPartlist_Click);
            // 
            // nudWishlist
            // 
            this.nudWishlist.Location = new System.Drawing.Point(12, 378);
            this.nudWishlist.Name = "nudWishlist";
            this.nudWishlist.Size = new System.Drawing.Size(50, 20);
            this.nudWishlist.TabIndex = 17;
            // 
            // nudInventory
            // 
            this.nudInventory.Location = new System.Drawing.Point(172, 378);
            this.nudInventory.Name = "nudInventory";
            this.nudInventory.Size = new System.Drawing.Size(50, 20);
            this.nudInventory.TabIndex = 18;
            // 
            // lblDivider2
            // 
            this.lblDivider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider2.Location = new System.Drawing.Point(164, 377);
            this.lblDivider2.Name = "lblDivider2";
            this.lblDivider2.Size = new System.Drawing.Size(2, 25);
            this.lblDivider2.TabIndex = 19;
            // 
            // frmDatabaseParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.lblDivider2);
            this.Controls.Add(this.nudInventory);
            this.Controls.Add(this.nudWishlist);
            this.Controls.Add(this.btnPartlist);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnWishlist);
            this.Controls.Add(this.lblDivider1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSubtheme);
            this.Controls.Add(this.lblSubtheme);
            this.Controls.Add(this.cmbTheme);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dataGridView);
            this.Name = "frmDatabaseParts";
            this.Text = "Sets Database";
            this.Load += new System.EventHandler(this.frmDatabaseSets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWishlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.Label lblSubtheme;
        private System.Windows.Forms.ComboBox cmbSubtheme;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblDivider1;
        private System.Windows.Forms.Button btnWishlist;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnPartlist;
        private System.Windows.Forms.NumericUpDown nudWishlist;
        private System.Windows.Forms.NumericUpDown nudInventory;
        private System.Windows.Forms.Label lblDivider2;
    }
}