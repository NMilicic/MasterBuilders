namespace Desktop.Views
{
    partial class frmDatabaseSets
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
            this.btnWishlist = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnPartlist = new System.Windows.Forms.Button();
            this.nudWishlist = new System.Windows.Forms.NumericUpDown();
            this.nudInventory = new System.Windows.Forms.NumericUpDown();
            this.lblDivider = new System.Windows.Forms.Label();
            this.btnPicture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblParts = new System.Windows.Forms.Label();
            this.lblYearDivider = new System.Windows.Forms.Label();
            this.lblPartsDivider = new System.Windows.Forms.Label();
            this.txtYearFrom = new System.Windows.Forms.MaskedTextBox();
            this.txtYearTo = new System.Windows.Forms.MaskedTextBox();
            this.txtPartsFrom = new System.Windows.Forms.MaskedTextBox();
            this.txtPartsTo = new System.Windows.Forms.MaskedTextBox();
            this.searchPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWishlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInventory)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(15, 65);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1160, 300);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 5);
            this.lblName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(47, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(110, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(163, 5);
            this.lblTheme.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(43, 13);
            this.lblTheme.TabIndex = 3;
            this.lblTheme.Text = "Theme:";
            // 
            // cmbTheme
            // 
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Location = new System.Drawing.Point(212, 3);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(121, 21);
            this.cmbTheme.TabIndex = 4;
            this.cmbTheme.SelectedIndexChanged += new System.EventHandler(this.cmbTheme_SelectedIndexChanged);
            // 
            // lblSubtheme
            // 
            this.lblSubtheme.AutoSize = true;
            this.lblSubtheme.Location = new System.Drawing.Point(339, 5);
            this.lblSubtheme.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblSubtheme.Name = "lblSubtheme";
            this.lblSubtheme.Size = new System.Drawing.Size(58, 13);
            this.lblSubtheme.TabIndex = 5;
            this.lblSubtheme.Text = "Subtheme:";
            // 
            // cmbSubtheme
            // 
            this.cmbSubtheme.FormattingEnabled = true;
            this.cmbSubtheme.Location = new System.Drawing.Point(403, 3);
            this.cmbSubtheme.Name = "cmbSubtheme";
            this.cmbSubtheme.Size = new System.Drawing.Size(121, 21);
            this.cmbSubtheme.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Location = new System.Drawing.Point(1100, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnWishlist
            // 
            this.btnWishlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(1049, 376);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(125, 25);
            this.btnDownload.TabIndex = 15;
            this.btnDownload.Text = "Download Instructions";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnPartlist
            // 
            this.btnPartlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPartlist.Location = new System.Drawing.Point(968, 376);
            this.btnPartlist.Name = "btnPartlist";
            this.btnPartlist.Size = new System.Drawing.Size(75, 25);
            this.btnPartlist.TabIndex = 16;
            this.btnPartlist.Text = "View Partlist";
            this.btnPartlist.UseVisualStyleBackColor = true;
            this.btnPartlist.Click += new System.EventHandler(this.btnPartlist_Click);
            // 
            // nudWishlist
            // 
            this.nudWishlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudWishlist.Location = new System.Drawing.Point(12, 378);
            this.nudWishlist.Name = "nudWishlist";
            this.nudWishlist.Size = new System.Drawing.Size(50, 20);
            this.nudWishlist.TabIndex = 17;
            // 
            // nudInventory
            // 
            this.nudInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudInventory.Location = new System.Drawing.Point(172, 378);
            this.nudInventory.Name = "nudInventory";
            this.nudInventory.Size = new System.Drawing.Size(50, 20);
            this.nudInventory.TabIndex = 18;
            // 
            // lblDivider
            // 
            this.lblDivider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Location = new System.Drawing.Point(164, 377);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(2, 25);
            this.lblDivider.TabIndex = 19;
            // 
            // btnPicture
            // 
            this.btnPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPicture.Location = new System.Drawing.Point(887, 376);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(75, 25);
            this.btnPicture.TabIndex = 20;
            this.btnPicture.Text = "View Picture";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(329, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 25);
            this.label1.TabIndex = 21;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(530, 5);
            this.lblYear.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 21;
            this.lblYear.Text = "Year:";
            // 
            // lblParts
            // 
            this.lblParts.AutoSize = true;
            this.lblParts.Location = new System.Drawing.Point(802, 5);
            this.lblParts.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblParts.Name = "lblParts";
            this.lblParts.Size = new System.Drawing.Size(34, 13);
            this.lblParts.TabIndex = 22;
            this.lblParts.Text = "Parts:";
            // 
            // lblYearDivider
            // 
            this.lblYearDivider.AutoSize = true;
            this.lblYearDivider.Location = new System.Drawing.Point(674, 5);
            this.lblYearDivider.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblYearDivider.Name = "lblYearDivider";
            this.lblYearDivider.Size = new System.Drawing.Size(16, 13);
            this.lblYearDivider.TabIndex = 27;
            this.lblYearDivider.Text = "to";
            // 
            // lblPartsDivider
            // 
            this.lblPartsDivider.AutoSize = true;
            this.lblPartsDivider.Location = new System.Drawing.Point(948, 5);
            this.lblPartsDivider.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblPartsDivider.Name = "lblPartsDivider";
            this.lblPartsDivider.Size = new System.Drawing.Size(16, 13);
            this.lblPartsDivider.TabIndex = 28;
            this.lblPartsDivider.Text = "to";
            // 
            // txtYearFrom
            // 
            this.txtYearFrom.HidePromptOnLeave = true;
            this.txtYearFrom.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtYearFrom.Location = new System.Drawing.Point(568, 3);
            this.txtYearFrom.Mask = "0000";
            this.txtYearFrom.Name = "txtYearFrom";
            this.txtYearFrom.PromptChar = ' ';
            this.txtYearFrom.Size = new System.Drawing.Size(100, 20);
            this.txtYearFrom.TabIndex = 29;
            // 
            // txtYearTo
            // 
            this.txtYearTo.HidePromptOnLeave = true;
            this.txtYearTo.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtYearTo.Location = new System.Drawing.Point(696, 3);
            this.txtYearTo.Mask = "0000";
            this.txtYearTo.Name = "txtYearTo";
            this.txtYearTo.PromptChar = ' ';
            this.txtYearTo.Size = new System.Drawing.Size(100, 20);
            this.txtYearTo.TabIndex = 30;
            // 
            // txtPartsFrom
            // 
            this.txtPartsFrom.HidePromptOnLeave = true;
            this.txtPartsFrom.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtPartsFrom.Location = new System.Drawing.Point(842, 3);
            this.txtPartsFrom.Mask = "00000";
            this.txtPartsFrom.Name = "txtPartsFrom";
            this.txtPartsFrom.PromptChar = ' ';
            this.txtPartsFrom.Size = new System.Drawing.Size(100, 20);
            this.txtPartsFrom.TabIndex = 31;
            // 
            // txtPartsTo
            // 
            this.txtPartsTo.HidePromptOnLeave = true;
            this.txtPartsTo.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtPartsTo.Location = new System.Drawing.Point(970, 3);
            this.txtPartsTo.Mask = "00000";
            this.txtPartsTo.Name = "txtPartsTo";
            this.txtPartsTo.PromptChar = ' ';
            this.txtPartsTo.Size = new System.Drawing.Size(100, 20);
            this.txtPartsTo.TabIndex = 32;
            // 
            // searchPanel
            // 
            this.searchPanel.AutoSize = true;
            this.searchPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchPanel.Controls.Add(this.lblName);
            this.searchPanel.Controls.Add(this.txtName);
            this.searchPanel.Controls.Add(this.lblTheme);
            this.searchPanel.Controls.Add(this.cmbTheme);
            this.searchPanel.Controls.Add(this.lblSubtheme);
            this.searchPanel.Controls.Add(this.cmbSubtheme);
            this.searchPanel.Controls.Add(this.lblYear);
            this.searchPanel.Controls.Add(this.txtYearFrom);
            this.searchPanel.Controls.Add(this.lblYearDivider);
            this.searchPanel.Controls.Add(this.txtYearTo);
            this.searchPanel.Controls.Add(this.lblParts);
            this.searchPanel.Controls.Add(this.txtPartsFrom);
            this.searchPanel.Controls.Add(this.lblPartsDivider);
            this.searchPanel.Controls.Add(this.txtPartsTo);
            this.searchPanel.Location = new System.Drawing.Point(15, 12);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1073, 27);
            this.searchPanel.TabIndex = 33;
            // 
            // frmDatabaseSets
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1184, 411);
            this.ControlBox = false;
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.nudInventory);
            this.Controls.Add(this.nudWishlist);
            this.Controls.Add(this.btnPartlist);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnWishlist);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabaseSets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sets Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDatabaseSets_Load);
            this.Resize += new System.EventHandler(this.frmDatabaseSets_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWishlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInventory)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
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
        private System.Windows.Forms.Button btnWishlist;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnPartlist;
        private System.Windows.Forms.NumericUpDown nudWishlist;
        private System.Windows.Forms.NumericUpDown nudInventory;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblParts;
        private System.Windows.Forms.Label lblYearDivider;
        private System.Windows.Forms.Label lblPartsDivider;
        private System.Windows.Forms.MaskedTextBox txtYearFrom;
        private System.Windows.Forms.MaskedTextBox txtYearTo;
        private System.Windows.Forms.MaskedTextBox txtPartsFrom;
        private System.Windows.Forms.MaskedTextBox txtPartsTo;
        private System.Windows.Forms.FlowLayoutPanel searchPanel;
    }
}