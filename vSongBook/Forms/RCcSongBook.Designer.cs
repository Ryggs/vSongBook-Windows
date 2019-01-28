namespace vSongBook
{
    partial class RCcSongBook
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CcSongBook));
            this.btnNewTab = new System.Windows.Forms.Button();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.rtbFile = new System.Windows.Forms.RibbonTab();
            this.rplNewSong = new System.Windows.Forms.RibbonPanel();
            this.rplSongBooks = new System.Windows.Forms.RibbonPanel();
            this.rplEditSong = new System.Windows.Forms.RibbonPanel();
            this.rplSaveSong = new System.Windows.Forms.RibbonPanel();
            this.rplHistory = new System.Windows.Forms.RibbonPanel();
            this.rplExit = new System.Windows.Forms.RibbonPanel();
            this.rtbEdit = new System.Windows.Forms.RibbonTab();
            this.rtbView = new System.Windows.Forms.RibbonTab();
            this.rtbSearch = new System.Windows.Forms.RibbonTab();
            this.rtbLanguage = new System.Windows.Forms.RibbonTab();
            this.rtbSettings = new System.Windows.Forms.RibbonTab();
            this.rtbHelp = new System.Windows.Forms.RibbonTab();
            this.ribHome = new System.Windows.Forms.Ribbon();
            this.SuspendLayout();
            // 
            // btnNewTab
            // 
            this.btnNewTab.Location = new System.Drawing.Point(146, 142);
            this.btnNewTab.Name = "btnNewTab";
            this.btnNewTab.Size = new System.Drawing.Size(75, 23);
            this.btnNewTab.TabIndex = 2;
            this.btnNewTab.Text = "New Tab";
            this.btnNewTab.UseVisualStyleBackColor = true;
            this.btnNewTab.Click += new System.EventHandler(this.btnNewTab_Click);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusStrip1.Location = new System.Drawing.Point(0, 387);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(690, 22);
            this.StatusStrip1.TabIndex = 5;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "8.ico");
            this.ImageList1.Images.SetKeyName(1, "1.ico");
            this.ImageList1.Images.SetKeyName(2, "2.ico");
            this.ImageList1.Images.SetKeyName(3, "3.ico");
            this.ImageList1.Images.SetKeyName(4, "4.ico");
            this.ImageList1.Images.SetKeyName(5, "5.ico");
            this.ImageList1.Images.SetKeyName(6, "6.ico");
            this.ImageList1.Images.SetKeyName(7, "7.ico");
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // rtbFile
            // 
            this.rtbFile.Name = "rtbFile";
            this.rtbFile.Panels.Add(this.rplNewSong);
            this.rtbFile.Panels.Add(this.rplSongBooks);
            this.rtbFile.Panels.Add(this.rplEditSong);
            this.rtbFile.Panels.Add(this.rplSaveSong);
            this.rtbFile.Panels.Add(this.rplHistory);
            this.rtbFile.Panels.Add(this.rplExit);
            this.rtbFile.Text = "FILE";
            // 
            // rplNewSong
            // 
            this.rplNewSong.Name = "rplNewSong";
            this.rplNewSong.Text = "New Song";
            // 
            // rplSongBooks
            // 
            this.rplSongBooks.Name = "rplSongBooks";
            this.rplSongBooks.Text = "View Song Books";
            this.rplSongBooks.Visible = false;
            // 
            // rplEditSong
            // 
            this.rplEditSong.Name = "rplEditSong";
            this.rplEditSong.Text = "Edit Song";
            this.rplEditSong.Visible = false;
            // 
            // rplSaveSong
            // 
            this.rplSaveSong.Name = "rplSaveSong";
            this.rplSaveSong.Text = "Save Song";
            this.rplSaveSong.Visible = false;
            // 
            // rplHistory
            // 
            this.rplHistory.Name = "rplHistory";
            this.rplHistory.Text = "View History";
            this.rplHistory.Visible = false;
            // 
            // rplExit
            // 
            this.rplExit.Name = "rplExit";
            this.rplExit.Text = "Exit from vSongBook";
            this.rplExit.Visible = false;
            // 
            // rtbEdit
            // 
            this.rtbEdit.Name = "rtbEdit";
            this.rtbEdit.Text = "EDIT";
            this.rtbEdit.Visible = false;
            // 
            // rtbView
            // 
            this.rtbView.Name = "rtbView";
            this.rtbView.Text = "VIEW";
            this.rtbView.Visible = false;
            // 
            // rtbSearch
            // 
            this.rtbSearch.Name = "rtbSearch";
            this.rtbSearch.Text = "SEARCH";
            this.rtbSearch.Visible = false;
            // 
            // rtbLanguage
            // 
            this.rtbLanguage.Name = "rtbLanguage";
            this.rtbLanguage.Text = "&LANGUAGE";
            this.rtbLanguage.Visible = false;
            // 
            // rtbSettings
            // 
            this.rtbSettings.Name = "rtbSettings";
            this.rtbSettings.Text = "SETTINGS";
            this.rtbSettings.Visible = false;
            // 
            // rtbHelp
            // 
            this.rtbHelp.Name = "rtbHelp";
            this.rtbHelp.Text = "HELP";
            this.rtbHelp.Visible = false;
            // 
            // ribHome
            // 
            this.ribHome.BackColor = System.Drawing.Color.Black;
            this.ribHome.BorderMode = System.Windows.Forms.RibbonWindowMode.InsideWindow;
            this.ribHome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribHome.Location = new System.Drawing.Point(0, 0);
            this.ribHome.Minimized = false;
            this.ribHome.Name = "ribHome";
            // 
            // 
            // 
            this.ribHome.OrbDropDown.BorderRoundness = 8;
            this.ribHome.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribHome.OrbDropDown.Name = "";
            this.ribHome.OrbDropDown.Size = new System.Drawing.Size(0, 72);
            this.ribHome.OrbDropDown.TabIndex = 0;
            this.ribHome.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribHome.OrbText = "vSongBook4pc v2.3 © JacksiroCtrl 2018";
            // 
            // 
            // 
            this.ribHome.QuickAccessToolbar.Items.Add(this.ribbonButton1);
            this.ribHome.QuickAccessToolbar.Items.Add(this.ribbonButton2);
            this.ribHome.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribHome.Size = new System.Drawing.Size(690, 70);
            this.ribHome.TabIndex = 0;
            this.ribHome.Tabs.Add(this.rtbFile);
            this.ribHome.Tabs.Add(this.rtbEdit);
            this.ribHome.Tabs.Add(this.rtbView);
            this.ribHome.Tabs.Add(this.rtbSearch);
            this.ribHome.Tabs.Add(this.rtbLanguage);
            this.ribHome.Tabs.Add(this.rtbSettings);
            this.ribHome.Tabs.Add(this.rtbHelp);
            this.ribHome.TabsMargin = new System.Windows.Forms.Padding(5, 26, 20, 0);
            this.ribHome.TabSpacing = 4;
            this.ribHome.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            // 
            // CcSongBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 409);
            this.Controls.Add(this.ribHome);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.btnNewTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "CcSongBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "vSongBook";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CcSongBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewTab;
        private System.Windows.Forms.StatusStrip StatusStrip1;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.ImageList ImageList1;
        private System.Windows.Forms.RibbonTab rtbFile;
        private System.Windows.Forms.RibbonTab rtbEdit;
        private System.Windows.Forms.RibbonTab rtbView;
        private System.Windows.Forms.RibbonTab rtbSearch;
        private System.Windows.Forms.RibbonPanel rplNewSong;
        private System.Windows.Forms.RibbonTab rtbLanguage;
        private System.Windows.Forms.RibbonTab rtbSettings;
        private System.Windows.Forms.RibbonTab rtbHelp;
        private System.Windows.Forms.RibbonPanel rplSongBooks;
        private System.Windows.Forms.RibbonPanel rplEditSong;
        private System.Windows.Forms.RibbonPanel rplSaveSong;
        private System.Windows.Forms.RibbonPanel rplHistory;
        private System.Windows.Forms.RibbonPanel rplExit;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.Ribbon ribHome;
    }
}

