namespace Desktop.Views
{
    partial class frmMain
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseSets = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseParts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWishlist = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMOC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMOCView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMOCEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCommunity = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDatabase,
            this.menuInventory,
            this.menuWishlist,
            this.menuMOC,
            this.menuBA,
            this.menuCommunity,
            this.menuProfile,
            this.menuLogout});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 24);
            this.menu.TabIndex = 0;
            // 
            // menuDatabase
            // 
            this.menuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDatabaseSets,
            this.menuDatabaseParts});
            this.menuDatabase.Name = "menuDatabase";
            this.menuDatabase.Size = new System.Drawing.Size(67, 20);
            this.menuDatabase.Text = "Database";
            // 
            // menuDatabaseSets
            // 
            this.menuDatabaseSets.Name = "menuDatabaseSets";
            this.menuDatabaseSets.Size = new System.Drawing.Size(100, 22);
            this.menuDatabaseSets.Text = "Sets";
            this.menuDatabaseSets.Click += new System.EventHandler(this.menuDatabaseSets_Click);
            // 
            // menuDatabaseParts
            // 
            this.menuDatabaseParts.Name = "menuDatabaseParts";
            this.menuDatabaseParts.Size = new System.Drawing.Size(100, 22);
            this.menuDatabaseParts.Text = "Parts";
            this.menuDatabaseParts.Click += new System.EventHandler(this.menuDatabaseParts_Click);
            // 
            // menuInventory
            // 
            this.menuInventory.Name = "menuInventory";
            this.menuInventory.Size = new System.Drawing.Size(69, 20);
            this.menuInventory.Text = "Inventory";
            this.menuInventory.Click += new System.EventHandler(this.menuInventory_Click);
            // 
            // menuWishlist
            // 
            this.menuWishlist.Name = "menuWishlist";
            this.menuWishlist.Size = new System.Drawing.Size(60, 20);
            this.menuWishlist.Text = "Wishlist";
            this.menuWishlist.Click += new System.EventHandler(this.wishlistToolStripMenuItem_Click);
            // 
            // menuMOC
            // 
            this.menuMOC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMOCView,
            this.menuMOCEdit});
            this.menuMOC.Name = "menuMOC";
            this.menuMOC.Size = new System.Drawing.Size(47, 20);
            this.menuMOC.Text = "MOC";
            // 
            // menuMOCView
            // 
            this.menuMOCView.Name = "menuMOCView";
            this.menuMOCView.Size = new System.Drawing.Size(99, 22);
            this.menuMOCView.Text = "View";
            this.menuMOCView.Click += new System.EventHandler(this.menuMOCView_Click);
            // 
            // menuMOCEdit
            // 
            this.menuMOCEdit.Name = "menuMOCEdit";
            this.menuMOCEdit.Size = new System.Drawing.Size(99, 22);
            this.menuMOCEdit.Text = "Edit";
            this.menuMOCEdit.Click += new System.EventHandler(this.menuMOCEdit_Click);
            // 
            // menuBA
            // 
            this.menuBA.Name = "menuBA";
            this.menuBA.Size = new System.Drawing.Size(106, 20);
            this.menuBA.Text = "Builder Assistant";
            this.menuBA.Click += new System.EventHandler(this.menuBA_Click);
            // 
            // menuCommunity
            // 
            this.menuCommunity.Name = "menuCommunity";
            this.menuCommunity.Size = new System.Drawing.Size(83, 20);
            this.menuCommunity.Text = "Community";
            this.menuCommunity.Visible = false;
            this.menuCommunity.Click += new System.EventHandler(this.menuCommunity_Click);
            // 
            // menuProfile
            // 
            this.menuProfile.Name = "menuProfile";
            this.menuProfile.Size = new System.Drawing.Size(73, 20);
            this.menuProfile.Text = "My Profile";
            this.menuProfile.Visible = false;
            this.menuProfile.Click += new System.EventHandler(this.menuProfile_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(57, 20);
            this.menuLogout.Text = "Logout";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lego Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseSets;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseParts;
        private System.Windows.Forms.ToolStripMenuItem menuInventory;
        private System.Windows.Forms.ToolStripMenuItem menuBA;
        private System.Windows.Forms.ToolStripMenuItem menuMOC;
        private System.Windows.Forms.ToolStripMenuItem menuWishlist;
        private System.Windows.Forms.ToolStripMenuItem menuProfile;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuMOCView;
        private System.Windows.Forms.ToolStripMenuItem menuMOCEdit;
        private System.Windows.Forms.ToolStripMenuItem menuCommunity;
    }
}