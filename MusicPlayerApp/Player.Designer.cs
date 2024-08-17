namespace MusicPlayerApp
{
    partial class Player
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelSide = new Panel();
            labelImport = new Label();
            labelAll = new Label();
            labelPlaylist = new Label();
            labelHome = new Label();
            btnViewAll = new PictureBox();
            btnImport = new PictureBox();
            btnPlaylist = new PictureBox();
            btnHome = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            btnClose = new PictureBox();
            panelFooter = new Panel();
            labelArtists = new Label();
            labelTrackName = new Label();
            picAlbum = new PictureBox();
            labelEnd = new Label();
            labelStart = new Label();
            progressBar = new ProgressBar();
            barVolumn = new TrackBar();
            panelMain = new Panel();
            pagePlaying1 = new pagePlaying();
            pagePlaylists1 = new pagePlaylists();
            pageSonglist1 = new pageSonglist();
            pageViewAll1 = new pageViewAll();
            timerPlayer = new System.Windows.Forms.Timer(components);
            panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnViewAll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnImport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnPlaylist).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnHome).BeginInit();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAlbum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barVolumn).BeginInit();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelSide
            // 
            panelSide.BackColor = Color.PowderBlue;
            panelSide.Controls.Add(labelImport);
            panelSide.Controls.Add(labelAll);
            panelSide.Controls.Add(labelPlaylist);
            panelSide.Controls.Add(labelHome);
            panelSide.Controls.Add(btnViewAll);
            panelSide.Controls.Add(btnImport);
            panelSide.Controls.Add(btnPlaylist);
            panelSide.Controls.Add(btnHome);
            panelSide.Dock = DockStyle.Left;
            panelSide.Location = new Point(0, 31);
            panelSide.Name = "panelSide";
            panelSide.Size = new Size(105, 325);
            panelSide.TabIndex = 8;
            panelSide.Click += StealFocus;
            // 
            // labelImport
            // 
            labelImport.AutoSize = true;
            labelImport.Cursor = Cursors.Hand;
            labelImport.Location = new Point(33, 304);
            labelImport.Name = "labelImport";
            labelImport.Size = new Size(43, 15);
            labelImport.TabIndex = 4;
            labelImport.Text = "Import";
            labelImport.Click += btnImport_Click;
            // 
            // labelAll
            // 
            labelAll.AutoSize = true;
            labelAll.Cursor = Cursors.Hand;
            labelAll.Location = new Point(30, 227);
            labelAll.Margin = new Padding(2, 0, 2, 0);
            labelAll.Name = "labelAll";
            labelAll.Size = new Size(49, 15);
            labelAll.TabIndex = 4;
            labelAll.Text = "View All";
            labelAll.Click += btnViewAll_Click;
            // 
            // labelPlaylist
            // 
            labelPlaylist.AutoSize = true;
            labelPlaylist.Cursor = Cursors.Hand;
            labelPlaylist.Location = new Point(30, 148);
            labelPlaylist.Name = "labelPlaylist";
            labelPlaylist.Size = new Size(49, 15);
            labelPlaylist.TabIndex = 4;
            labelPlaylist.Text = "Playlists";
            labelPlaylist.Click += btnPlaylist_Click;
            // 
            // labelHome
            // 
            labelHome.AutoSize = true;
            labelHome.BackColor = Color.Transparent;
            labelHome.Cursor = Cursors.Hand;
            labelHome.Location = new Point(34, 70);
            labelHome.Name = "labelHome";
            labelHome.Size = new Size(40, 15);
            labelHome.TabIndex = 31;
            labelHome.Text = "Home";
            labelHome.Click += btnHome_Click;
            // 
            // btnViewAll
            // 
            btnViewAll.BackColor = Color.Transparent;
            btnViewAll.BackgroundImageLayout = ImageLayout.None;
            btnViewAll.Cursor = Cursors.Hand;
            btnViewAll.Image = Properties.Resources.view_all;
            btnViewAll.InitialImage = null;
            btnViewAll.Location = new Point(21, 167);
            btnViewAll.Name = "btnViewAll";
            btnViewAll.Size = new Size(66, 66);
            btnViewAll.SizeMode = PictureBoxSizeMode.StretchImage;
            btnViewAll.TabIndex = 30;
            btnViewAll.TabStop = false;
            btnViewAll.Click += btnViewAll_Click;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.Transparent;
            btnImport.BackgroundImageLayout = ImageLayout.None;
            btnImport.Cursor = Cursors.Hand;
            btnImport.Image = Properties.Resources.import;
            btnImport.InitialImage = null;
            btnImport.Location = new Point(21, 245);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(66, 66);
            btnImport.SizeMode = PictureBoxSizeMode.StretchImage;
            btnImport.TabIndex = 29;
            btnImport.TabStop = false;
            btnImport.Click += btnImport_Click;
            // 
            // btnPlaylist
            // 
            btnPlaylist.BackColor = Color.Transparent;
            btnPlaylist.BackgroundImageLayout = ImageLayout.None;
            btnPlaylist.Cursor = Cursors.Hand;
            btnPlaylist.Image = Properties.Resources.playlist;
            btnPlaylist.InitialImage = null;
            btnPlaylist.Location = new Point(21, 90);
            btnPlaylist.Name = "btnPlaylist";
            btnPlaylist.Size = new Size(66, 66);
            btnPlaylist.SizeMode = PictureBoxSizeMode.StretchImage;
            btnPlaylist.TabIndex = 28;
            btnPlaylist.TabStop = false;
            btnPlaylist.Click += btnPlaylist_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Transparent;
            btnHome.BackgroundImageLayout = ImageLayout.None;
            btnHome.Cursor = Cursors.Hand;
            btnHome.Image = Properties.Resources.home;
            btnHome.InitialImage = null;
            btnHome.Location = new Point(21, 11);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(66, 66);
            btnHome.SizeMode = PictureBoxSizeMode.StretchImage;
            btnHome.TabIndex = 27;
            btnHome.TabStop = false;
            btnHome.Click += btnHome_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Azure;
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(749, 31);
            panelHeader.TabIndex = 9;
            panelHeader.Click += StealFocus;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelTitle.Location = new Point(266, 5);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(200, 25);
            labelTitle.TabIndex = 8;
            labelTitle.Text = "CP440 - Music Player";
            labelTitle.Click += StealFocus;
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(715, 0);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(36, 32);
            btnClose.SizeMode = PictureBoxSizeMode.StretchImage;
            btnClose.TabIndex = 9;
            btnClose.TabStop = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.Azure;
            panelFooter.Controls.Add(labelArtists);
            panelFooter.Controls.Add(labelTrackName);
            panelFooter.Controls.Add(picAlbum);
            panelFooter.Controls.Add(labelEnd);
            panelFooter.Controls.Add(labelStart);
            panelFooter.Controls.Add(progressBar);
            panelFooter.Controls.Add(barVolumn);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 356);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(749, 107);
            panelFooter.TabIndex = 10;
            panelFooter.Click += StealFocus;
            // 
            // labelArtists
            // 
            labelArtists.AutoSize = true;
            labelArtists.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelArtists.Location = new Point(141, 39);
            labelArtists.Name = "labelArtists";
            labelArtists.Size = new Size(36, 17);
            labelArtists.TabIndex = 25;
            labelArtists.Text = "Here";
            labelArtists.Click += StealFocus;
            // 
            // labelTrackName
            // 
            labelTrackName.AutoSize = true;
            labelTrackName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTrackName.Location = new Point(138, 15);
            labelTrackName.Name = "labelTrackName";
            labelTrackName.Size = new Size(197, 21);
            labelTrackName.TabIndex = 24;
            labelTrackName.Text = "Start your music journey";
            labelTrackName.Click += StealFocus;
            // 
            // picAlbum
            // 
            picAlbum.BackColor = Color.LightCyan;
            picAlbum.BackgroundImageLayout = ImageLayout.None;
            picAlbum.BorderStyle = BorderStyle.Fixed3D;
            picAlbum.Image = Properties.Resources.Player;
            picAlbum.InitialImage = null;
            picAlbum.Location = new Point(33, 15);
            picAlbum.Name = "picAlbum";
            picAlbum.Size = new Size(80, 80);
            picAlbum.SizeMode = PictureBoxSizeMode.StretchImage;
            picAlbum.TabIndex = 23;
            picAlbum.TabStop = false;
            picAlbum.Click += StealFocus;
            // 
            // labelEnd
            // 
            labelEnd.AutoSize = true;
            labelEnd.Location = new Point(623, 80);
            labelEnd.Name = "labelEnd";
            labelEnd.Size = new Size(34, 15);
            labelEnd.TabIndex = 17;
            labelEnd.Text = "00:00";
            labelEnd.Click += StealFocus;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.Location = new Point(138, 80);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(34, 15);
            labelStart.TabIndex = 16;
            labelStart.Text = "00:00";
            labelStart.Click += StealFocus;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(138, 67);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(519, 10);
            progressBar.TabIndex = 15;
            progressBar.Click += StealFocus;
            progressBar.MouseDown += progressBar_MouseDown;
            // 
            // barVolumn
            // 
            barVolumn.Cursor = Cursors.Hand;
            barVolumn.Location = new Point(692, 15);
            barVolumn.Name = "barVolumn";
            barVolumn.Orientation = Orientation.Vertical;
            barVolumn.RightToLeft = RightToLeft.No;
            barVolumn.Size = new Size(45, 80);
            barVolumn.TabIndex = 14;
            barVolumn.TickStyle = TickStyle.Both;
            barVolumn.Value = 10;
            barVolumn.Click += StealFocus;
            barVolumn.Scroll += barVolumn_Scroll;
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.Control;
            panelMain.BorderStyle = BorderStyle.Fixed3D;
            panelMain.Controls.Add(pagePlaying1);
            panelMain.Controls.Add(pagePlaylists1);
            panelMain.Controls.Add(pageSonglist1);
            panelMain.Controls.Add(pageViewAll1);
            panelMain.Dock = DockStyle.Right;
            panelMain.Location = new Point(103, 31);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(646, 325);
            panelMain.TabIndex = 13;
            panelMain.Click += StealFocus;
            // 
            // pagePlaying1
            // 
            pagePlaying1.BackColor = Color.AliceBlue;
            pagePlaying1.Location = new Point(-1, -2);
            pagePlaying1.Margin = new Padding(4, 5, 4, 5);
            pagePlaying1.Name = "pagePlaying1";
            pagePlaying1.Size = new Size(645, 326);
            pagePlaying1.TabIndex = 2;
            // 
            // pagePlaylists1
            // 
            pagePlaylists1.BackColor = Color.AliceBlue;
            pagePlaylists1.Location = new Point(0, 0);
            pagePlaylists1.Margin = new Padding(4, 5, 4, 5);
            pagePlaylists1.Name = "pagePlaylists1";
            pagePlaylists1.Size = new Size(643, 325);
            pagePlaylists1.TabIndex = 1;
            // 
            // pageSonglist1
            // 
            pageSonglist1.BackColor = Color.AliceBlue;
            pageSonglist1.Location = new Point(0, 0);
            pageSonglist1.Margin = new Padding(4, 5, 4, 5);
            pageSonglist1.Name = "pageSonglist1";
            pageSonglist1.Size = new Size(643, 325);
            pageSonglist1.TabIndex = 0;
            // 
            // pageViewAll1
            // 
            pageViewAll1.BackColor = Color.AliceBlue;
            pageViewAll1.Location = new Point(0, 0);
            pageViewAll1.Margin = new Padding(4, 5, 4, 5);
            pageViewAll1.Name = "pageViewAll1";
            pageViewAll1.Size = new Size(646, 325);
            pageViewAll1.TabIndex = 3;
            // 
            // timerPlayer
            // 
            timerPlayer.Enabled = true;
            timerPlayer.Tick += timerPlayer_Tick;
            // 
            // Player
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(749, 463);
            Controls.Add(panelMain);
            Controls.Add(panelSide);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Player";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Player";
            FormClosed += Player_FormClosed;
            Load += Player_Load;
            panelSide.ResumeLayout(false);
            panelSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnViewAll).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnImport).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnPlaylist).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnHome).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAlbum).EndInit();
            ((System.ComponentModel.ISupportInitialize)barVolumn).EndInit();
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelSide;
        private Panel panelHeader;
        private Panel panelFooter;
        private Panel panelMain;
        private Label labelTitle;
        private TrackBar barVolumn;
        private Label labelEnd;
        private Label labelStart;
        private ProgressBar progressBar;
        private PictureBox picAlbum;
        private Label labelArtists;
        private Label labelTrackName;
        private PictureBox btnHome;
        private PictureBox btnPlaylist;
        private PictureBox btnImport;
        private PictureBox btnClose;
        private PictureBox btnViewAll;
        private pagePlaying pagePlaying1;
        private pagePlaylists pagePlaylists1;
        private pageSonglist pageSonglist1;
        private pageViewAll pageViewAll1;
        private System.Windows.Forms.Timer timerPlayer;
        private Label labelHome;
        private Label labelAll;
        private Label labelPlaylist;
        private Label labelImport;
    }
}
