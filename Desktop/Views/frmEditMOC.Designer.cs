namespace Desktop.Views
{
    partial class frmEditMOC
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblcategory = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.nudAdd = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPartlist = new System.Windows.Forms.Button();
            this.lblDivider = new System.Windows.Forms.Label();
            this.lblAddName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTheme2 = new System.Windows.Forms.Label();
            this.lblTheme1 = new System.Windows.Forms.Label();
            this.lblTheme3 = new System.Windows.Forms.Label();
            this.txtAddName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTheme1 = new System.Windows.Forms.TextBox();
            this.txtTheme2 = new System.Windows.Forms.TextBox();
            this.txtTheme3 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Location = new System.Drawing.Point(540, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(15, 45);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(600, 300);
            this.dataGridView.TabIndex = 20;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // cmbColor
            // 
            this.cmbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(56, 351);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(121, 21);
            this.cmbColor.TabIndex = 28;
            // 
            // lblColor
            // 
            this.lblColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblColor.Location = new System.Drawing.Point(15, 354);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(35, 13);
            this.lblColor.TabIndex = 0;
            this.lblColor.Text = "Color:";
            // 
            // nudAdd
            // 
            this.nudAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudAdd.Location = new System.Drawing.Point(183, 352);
            this.nudAdd.Name = "nudAdd";
            this.nudAdd.Size = new System.Drawing.Size(50, 20);
            this.nudAdd.TabIndex = 29;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(239, 351);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPartlist
            // 
            this.btnPartlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPartlist.Location = new System.Drawing.Point(540, 352);
            this.btnPartlist.Name = "btnPartlist";
            this.btnPartlist.Size = new System.Drawing.Size(75, 25);
            this.btnPartlist.TabIndex = 31;
            this.btnPartlist.Text = "View Partlist";
            this.btnPartlist.UseVisualStyleBackColor = true;
            this.btnPartlist.Click += new System.EventHandler(this.btnPartlist_Click);
            // 
            // lblDivider
            // 
            this.lblDivider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Location = new System.Drawing.Point(15, 380);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(600, 2);
            this.lblDivider.TabIndex = 32;
            // 
            // lblAddName
            // 
            this.lblAddName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAddName.AutoSize = true;
            this.lblAddName.Location = new System.Drawing.Point(18, 388);
            this.lblAddName.Name = "lblAddName";
            this.lblAddName.Size = new System.Drawing.Size(38, 13);
            this.lblAddName.TabIndex = 33;
            this.lblAddName.Text = "Name:";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(168, 388);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 34;
            this.lblDescription.Text = "Description:";
            // 
            // lblTheme2
            // 
            this.lblTheme2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTheme2.AutoSize = true;
            this.lblTheme2.Location = new System.Drawing.Point(179, 414);
            this.lblTheme2.Name = "lblTheme2";
            this.lblTheme2.Size = new System.Drawing.Size(46, 13);
            this.lblTheme2.TabIndex = 35;
            this.lblTheme2.Text = "Theme2";
            // 
            // lblTheme1
            // 
            this.lblTheme1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTheme1.AutoSize = true;
            this.lblTheme1.Location = new System.Drawing.Point(18, 414);
            this.lblTheme1.Name = "lblTheme1";
            this.lblTheme1.Size = new System.Drawing.Size(49, 13);
            this.lblTheme1.TabIndex = 36;
            this.lblTheme1.Text = "Theme1:";
            // 
            // lblTheme3
            // 
            this.lblTheme3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTheme3.AutoSize = true;
            this.lblTheme3.Location = new System.Drawing.Point(337, 414);
            this.lblTheme3.Name = "lblTheme3";
            this.lblTheme3.Size = new System.Drawing.Size(49, 13);
            this.lblTheme3.TabIndex = 37;
            this.lblTheme3.Text = "Theme3:";
            // 
            // txtAddName
            // 
            this.txtAddName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAddName.Location = new System.Drawing.Point(62, 385);
            this.txtAddName.Name = "txtAddName";
            this.txtAddName.Size = new System.Drawing.Size(100, 20);
            this.txtAddName.TabIndex = 38;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDescription.Location = new System.Drawing.Point(237, 385);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(255, 20);
            this.txtDescription.TabIndex = 39;
            // 
            // txtTheme1
            // 
            this.txtTheme1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTheme1.Location = new System.Drawing.Point(73, 411);
            this.txtTheme1.Name = "txtTheme1";
            this.txtTheme1.Size = new System.Drawing.Size(100, 20);
            this.txtTheme1.TabIndex = 40;
            // 
            // txtTheme2
            // 
            this.txtTheme2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTheme2.Location = new System.Drawing.Point(231, 411);
            this.txtTheme2.Name = "txtTheme2";
            this.txtTheme2.Size = new System.Drawing.Size(100, 20);
            this.txtTheme2.TabIndex = 41;
            // 
            // txtTheme3
            // 
            this.txtTheme3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTheme3.Location = new System.Drawing.Point(392, 411);
            this.txtTheme3.Name = "txtTheme3";
            this.txtTheme3.Size = new System.Drawing.Size(100, 20);
            this.txtTheme3.TabIndex = 42;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(540, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 45);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEditMOC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(634, 436);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTheme3);
            this.Controls.Add(this.txtTheme2);
            this.Controls.Add(this.txtTheme1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAddName);
            this.Controls.Add(this.lblTheme3);
            this.Controls.Add(this.lblTheme1);
            this.Controls.Add(this.lblTheme2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAddName);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.btnPartlist);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.nudAdd);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblcategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditMOC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit MOC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAddMOC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblcategory;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.NumericUpDown nudAdd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPartlist;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Label lblAddName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTheme2;
        private System.Windows.Forms.Label lblTheme1;
        private System.Windows.Forms.Label lblTheme3;
        private System.Windows.Forms.TextBox txtAddName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTheme1;
        private System.Windows.Forms.TextBox txtTheme2;
        private System.Windows.Forms.TextBox txtTheme3;
        private System.Windows.Forms.Button btnSave;
    }
}