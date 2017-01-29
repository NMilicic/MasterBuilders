namespace Desktop.Views
{
    partial class frmInventorySets
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAssemble = new System.Windows.Forms.Button();
            this.nudAssemble = new System.Windows.Forms.NumericUpDown();
            this.lblDivider2 = new System.Windows.Forms.Label();
            this.nudRemove = new System.Windows.Forms.NumericUpDown();
            this.btnDisassemble = new System.Windows.Forms.Button();
            this.nudDisassemble = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAssemble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisassemble)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(55, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(161, 18);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(43, 13);
            this.lblTheme.TabIndex = 3;
            this.lblTheme.Text = "Theme:";
            // 
            // cmbTheme
            // 
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Location = new System.Drawing.Point(210, 15);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(121, 21);
            this.cmbTheme.TabIndex = 4;
            this.cmbTheme.SelectedIndexChanged += new System.EventHandler(this.cmbTheme_SelectedIndexChanged);
            // 
            // lblSubtheme
            // 
            this.lblSubtheme.AutoSize = true;
            this.lblSubtheme.Location = new System.Drawing.Point(336, 18);
            this.lblSubtheme.Name = "lblSubtheme";
            this.lblSubtheme.Size = new System.Drawing.Size(58, 13);
            this.lblSubtheme.TabIndex = 5;
            this.lblSubtheme.Text = "Subtheme:";
            // 
            // cmbSubtheme
            // 
            this.cmbSubtheme.FormattingEnabled = true;
            this.cmbSubtheme.Location = new System.Drawing.Point(400, 15);
            this.cmbSubtheme.Name = "cmbSubtheme";
            this.cmbSubtheme.Size = new System.Drawing.Size(121, 21);
            this.cmbSubtheme.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Location = new System.Drawing.Point(540, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(71, 376);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 25);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAssemble
            // 
            this.btnAssemble.Location = new System.Drawing.Point(231, 376);
            this.btnAssemble.Name = "btnAssemble";
            this.btnAssemble.Size = new System.Drawing.Size(95, 25);
            this.btnAssemble.TabIndex = 14;
            this.btnAssemble.Text = "Assemble";
            this.btnAssemble.UseVisualStyleBackColor = true;
            this.btnAssemble.Click += new System.EventHandler(this.btnAssemble_Click);
            // 
            // nudAssemble
            // 
            this.nudAssemble.Location = new System.Drawing.Point(175, 378);
            this.nudAssemble.Name = "nudAssemble";
            this.nudAssemble.Size = new System.Drawing.Size(50, 20);
            this.nudAssemble.TabIndex = 18;
            // 
            // lblDivider2
            // 
            this.lblDivider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider2.Location = new System.Drawing.Point(167, 376);
            this.lblDivider2.Name = "lblDivider2";
            this.lblDivider2.Size = new System.Drawing.Size(2, 25);
            this.lblDivider2.TabIndex = 19;
            // 
            // nudRemove
            // 
            this.nudRemove.Location = new System.Drawing.Point(15, 378);
            this.nudRemove.Name = "nudRemove";
            this.nudRemove.Size = new System.Drawing.Size(50, 20);
            this.nudRemove.TabIndex = 20;
            // 
            // btnDisassemble
            // 
            this.btnDisassemble.Location = new System.Drawing.Point(388, 376);
            this.btnDisassemble.Name = "btnDisassemble";
            this.btnDisassemble.Size = new System.Drawing.Size(95, 25);
            this.btnDisassemble.TabIndex = 21;
            this.btnDisassemble.Text = "Disassemble";
            this.btnDisassemble.UseVisualStyleBackColor = true;
            this.btnDisassemble.Click += new System.EventHandler(this.btnDisassemble_Click);
            // 
            // nudDisassemble
            // 
            this.nudDisassemble.Location = new System.Drawing.Point(332, 378);
            this.nudDisassemble.Name = "nudDisassemble";
            this.nudDisassemble.Size = new System.Drawing.Size(50, 20);
            this.nudDisassemble.TabIndex = 22;
            // 
            // frmInventorySets
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.ControlBox = false;
            this.Controls.Add(this.nudDisassemble);
            this.Controls.Add(this.btnDisassemble);
            this.Controls.Add(this.nudRemove);
            this.Controls.Add(this.lblDivider2);
            this.Controls.Add(this.nudAssemble);
            this.Controls.Add(this.btnAssemble);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSubtheme);
            this.Controls.Add(this.lblSubtheme);
            this.Controls.Add(this.cmbTheme);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInventorySets";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sets Inventory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInventorySets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAssemble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisassemble)).EndInit();
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
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAssemble;
        private System.Windows.Forms.NumericUpDown nudAssemble;
        private System.Windows.Forms.Label lblDivider2;
        private System.Windows.Forms.NumericUpDown nudRemove;
        private System.Windows.Forms.Button btnDisassemble;
        private System.Windows.Forms.NumericUpDown nudDisassemble;
    }
}