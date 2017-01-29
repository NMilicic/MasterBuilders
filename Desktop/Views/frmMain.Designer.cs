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
            this.menuInventorySets = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInventoryParts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWishlist = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMOC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMOCView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMOCAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfileView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfileEdit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuBA,
            this.menuMOC,
            this.menuProfile,
            this.menuLogout});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(634, 24);
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
            this.menuInventory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInventorySets,
            this.menuInventoryParts});
            this.menuInventory.Name = "menuInventory";
            this.menuInventory.Size = new System.Drawing.Size(69, 20);
            this.menuInventory.Text = "Inventory";
            // 
            // menuInventorySets
            // 
            this.menuInventorySets.Name = "menuInventorySets";
            this.menuInventorySets.Size = new System.Drawing.Size(100, 22);
            this.menuInventorySets.Text = "Sets";
            this.menuInventorySets.Click += new System.EventHandler(this.menuInventorySets_Click);
            // 
            // menuInventoryParts
            // 
            this.menuInventoryParts.Name = "menuInventoryParts";
            this.menuInventoryParts.Size = new System.Drawing.Size(100, 22);
            this.menuInventoryParts.Text = "Parts";
            this.menuInventoryParts.Click += new System.EventHandler(this.menuInventoryParts_Click);
            // 
            // menuWishlist
            // 
            this.menuWishlist.Name = "menuWishlist";
            this.menuWishlist.Size = new System.Drawing.Size(60, 20);
            this.menuWishlist.Text = "Wishlist";
            this.menuWishlist.Click += new System.EventHandler(this.wishlistToolStripMenuItem_Click);
            // 
            // menuBA
            // 
            this.menuBA.Name = "menuBA";
            this.menuBA.Size = new System.Drawing.Size(106, 20);
            this.menuBA.Text = "Builder Assistant";
            this.menuBA.Click += new System.EventHandler(this.menuBA_Click);
            // 
            // menuMOC
            // 
            this.menuMOC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMOCView,
            this.menuMOCAdd});
            this.menuMOC.Name = "menuMOC";
            this.menuMOC.Size = new System.Drawing.Size(47, 20);
            this.menuMOC.Text = "MOC";
            // 
            // menuMOCView
            // 
            this.menuMOCView.Name = "menuMOCView";
            this.menuMOCView.Size = new System.Drawing.Size(99, 22);
            this.menuMOCView.Text = "View";
            // 
            // menuMOCAdd
            // 
            this.menuMOCAdd.Name = "menuMOCAdd";
            this.menuMOCAdd.Size = new System.Drawing.Size(99, 22);
            this.menuMOCAdd.Text = "Add";
            // 
            // menuProfile
            // 
            this.menuProfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProfileView,
            this.menuProfileEdit});
            this.menuProfile.Name = "menuProfile";
            this.menuProfile.Size = new System.Drawing.Size(53, 20);
            this.menuProfile.Text = "Profile";
            // 
            // menuProfileView
            // 
            this.menuProfileView.Name = "menuProfileView";
            this.menuProfileView.Size = new System.Drawing.Size(99, 22);
            this.menuProfileView.Text = "View";
            // 
            // menuProfileEdit
            // 
            this.menuProfileEdit.Name = "menuProfileEdit";
            this.menuProfileEdit.Size = new System.Drawing.Size(99, 22);
            this.menuProfileEdit.Text = "Edit";
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
            this.ClientSize = new System.Drawing.Size(634, 441);
            this.Controls.Add(this.menu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lego Manager";
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
        private System.Windows.Forms.ToolStripMenuItem menuInventorySets;
        private System.Windows.Forms.ToolStripMenuItem menuInventoryParts;
        private System.Windows.Forms.ToolStripMenuItem menuBA;
        private System.Windows.Forms.ToolStripMenuItem menuMOC;
        private System.Windows.Forms.ToolStripMenuItem menuWishlist;
        private System.Windows.Forms.ToolStripMenuItem menuProfile;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuMOCView;
        private System.Windows.Forms.ToolStripMenuItem menuMOCAdd;
        private System.Windows.Forms.ToolStripMenuItem menuProfileView;
        private System.Windows.Forms.ToolStripMenuItem menuProfileEdit;
    }
}