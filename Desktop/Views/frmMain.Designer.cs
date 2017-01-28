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
            this.builderAssisstantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mOCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wishlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDatabase,
            this.menuInventory,
            this.builderAssisstantToolStripMenuItem,
            this.mOCToolStripMenuItem,
            this.wishlistToolStripMenuItem,
            this.favoritesToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.menuLogout});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(689, 24);
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
            this.menuDatabaseSets.Size = new System.Drawing.Size(152, 22);
            this.menuDatabaseSets.Text = "Sets";
            this.menuDatabaseSets.Click += new System.EventHandler(this.menuDatabaseSets_Click);
            // 
            // menuDatabaseParts
            // 
            this.menuDatabaseParts.Name = "menuDatabaseParts";
            this.menuDatabaseParts.Size = new System.Drawing.Size(152, 22);
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
            this.menuInventorySets.Size = new System.Drawing.Size(152, 22);
            this.menuInventorySets.Text = "Sets";
            this.menuInventorySets.Click += new System.EventHandler(this.menuInventorySets_Click);
            // 
            // menuInventoryParts
            // 
            this.menuInventoryParts.Name = "menuInventoryParts";
            this.menuInventoryParts.Size = new System.Drawing.Size(152, 22);
            this.menuInventoryParts.Text = "Parts";
            this.menuInventoryParts.Click += new System.EventHandler(this.menuInventoryParts_Click);
            // 
            // builderAssisstantToolStripMenuItem
            // 
            this.builderAssisstantToolStripMenuItem.Name = "builderAssisstantToolStripMenuItem";
            this.builderAssisstantToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.builderAssisstantToolStripMenuItem.Text = "Builder Assistant";
            // 
            // mOCToolStripMenuItem
            // 
            this.mOCToolStripMenuItem.Name = "mOCToolStripMenuItem";
            this.mOCToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.mOCToolStripMenuItem.Text = "MOC";
            // 
            // wishlistToolStripMenuItem
            // 
            this.wishlistToolStripMenuItem.Name = "wishlistToolStripMenuItem";
            this.wishlistToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.wishlistToolStripMenuItem.Text = "Wishlist";
            // 
            // favoritesToolStripMenuItem
            // 
            this.favoritesToolStripMenuItem.Name = "favoritesToolStripMenuItem";
            this.favoritesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.favoritesToolStripMenuItem.Text = "Favorites";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileToolStripMenuItem.Text = "Profile";
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
            this.ClientSize = new System.Drawing.Size(689, 261);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "frmMain";
            this.Text = "Lego Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
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
        private System.Windows.Forms.ToolStripMenuItem builderAssisstantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mOCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wishlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
    }
}