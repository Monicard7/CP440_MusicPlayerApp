namespace MusicPlayerApp
{
    partial class pageViewAll
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelAllTracks = new Label();
            listBoxTracks = new ListBox();
            searchTracks = new TextBox();
            labelArtist = new Label();
            labelDuration = new Label();
            btnSave = new Button();
            selectPlaylist = new ComboBox();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // labelAllTracks
            // 
            labelAllTracks.AutoSize = true;
            labelAllTracks.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelAllTracks.Location = new Point(43, 45);
            labelAllTracks.Name = "labelAllTracks";
            labelAllTracks.Size = new Size(151, 40);
            labelAllTracks.TabIndex = 25;
            labelAllTracks.Text = "All Tracks";
            labelAllTracks.Click += searchTracks_outClick;
            // 
            // listBoxTracks
            // 
            listBoxTracks.BackColor = Color.AliceBlue;
            listBoxTracks.BorderStyle = BorderStyle.None;
            listBoxTracks.FormattingEnabled = true;
            listBoxTracks.ItemHeight = 15;
            listBoxTracks.Location = new Point(43, 132);
            listBoxTracks.Name = "listBoxTracks";
            listBoxTracks.Size = new Size(254, 165);
            listBoxTracks.TabIndex = 26;
            listBoxTracks.Click += searchTracks_outClick;
            listBoxTracks.SelectedIndexChanged += listBoxTracks_SelectedIndexChanged;
            listBoxTracks.DoubleClick += listBoxTracks_DoubleClick;
            // 
            // searchTracks
            // 
            searchTracks.BorderStyle = BorderStyle.FixedSingle;
            searchTracks.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            searchTracks.ForeColor = SystemColors.WindowFrame;
            searchTracks.Location = new Point(43, 106);
            searchTracks.Name = "searchTracks";
            searchTracks.Size = new Size(254, 25);
            searchTracks.TabIndex = 27;
            searchTracks.Text = "Search for tracks...";
            searchTracks.MouseClick += searchTracks_MouseClick;
            searchTracks.KeyPress += searchTracks_KeyPress;
            // 
            // labelArtist
            // 
            labelArtist.AutoSize = true;
            labelArtist.Location = new Point(363, 142);
            labelArtist.Margin = new Padding(2, 0, 2, 0);
            labelArtist.Name = "labelArtist";
            labelArtist.Size = new Size(0, 15);
            labelArtist.TabIndex = 28;
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Location = new Point(363, 177);
            labelDuration.Margin = new Padding(2, 0, 2, 0);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(0, 15);
            labelDuration.TabIndex = 29;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(408, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 25);
            btnSave.TabIndex = 30;
            btnSave.Text = "Save to";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // selectPlaylist
            // 
            selectPlaylist.FormattingEnabled = true;
            selectPlaylist.Location = new Point(489, 274);
            selectPlaylist.Name = "selectPlaylist";
            selectPlaylist.Size = new Size(121, 23);
            selectPlaylist.TabIndex = 33;
            selectPlaylist.SelectionChangeCommitted += selectPlaylist_SelectionChangeCommitted;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(333, 274);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(69, 25);
            btnDelete.TabIndex = 34;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // pageViewAll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnDelete);
            Controls.Add(selectPlaylist);
            Controls.Add(btnSave);
            Controls.Add(labelDuration);
            Controls.Add(labelArtist);
            Controls.Add(searchTracks);
            Controls.Add(listBoxTracks);
            Controls.Add(labelAllTracks);
            Name = "pageViewAll";
            Size = new Size(646, 325);
            Load += pageViewAll_Load;
            Click += searchTracks_outClick;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label labelAllTracks;
        private ListBox listBoxTracks;
        private TextBox searchTracks;
        private Label labelArtist;
        private Label labelDuration;
        private Button btnSave;
        private ComboBox selectPlaylist;
        private Button btnDelete;
    }
}
