namespace MusicPlayerApp
{
    partial class pageSonglist
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
            labelPlaylistName = new Label();
            listBoxTracks = new ListBox();
            searchTracks = new TextBox();
            labelDuration = new Label();
            labelCount = new Label();
            btnDelete = new Button();
            btnPlay = new Button();
            btnEdit = new Button();
            SuspendLayout();
            // 
            // labelPlaylistName
            // 
            labelPlaylistName.AutoSize = true;
            labelPlaylistName.BackColor = Color.AliceBlue;
            labelPlaylistName.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelPlaylistName.Location = new Point(366, 61);
            labelPlaylistName.Name = "labelPlaylistName";
            labelPlaylistName.Size = new Size(208, 40);
            labelPlaylistName.TabIndex = 0;
            labelPlaylistName.Text = "Playlist Name";
            // 
            // listBoxTracks
            // 
            listBoxTracks.BackColor = Color.AliceBlue;
            listBoxTracks.BorderStyle = BorderStyle.None;
            listBoxTracks.FormattingEnabled = true;
            listBoxTracks.ItemHeight = 15;
            listBoxTracks.Location = new Point(64, 101);
            listBoxTracks.Name = "listBoxTracks";
            listBoxTracks.Size = new Size(201, 165);
            listBoxTracks.TabIndex = 1;
            listBoxTracks.SelectedIndexChanged += listBoxTracks_SelectedIndexChanged;
            listBoxTracks.DoubleClick += listBoxTracks_DoubleClick;
            // 
            // searchTracks
            // 
            searchTracks.BorderStyle = BorderStyle.FixedSingle;
            searchTracks.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            searchTracks.ForeColor = SystemColors.WindowFrame;
            searchTracks.Location = new Point(65, 65);
            searchTracks.Name = "searchTracks";
            searchTracks.Size = new Size(200, 25);
            searchTracks.TabIndex = 4;
            searchTracks.Text = "Search for tracks...";
            searchTracks.Click += searchTracks_Click;
            searchTracks.TextChanged += searchTracks_TextChanged;
            searchTracks.KeyPress += searchTracks_KeyPress;
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Location = new Point(377, 167);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(59, 15);
            labelDuration.TabIndex = 5;
            labelDuration.Text = "Duration: ";
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(377, 129);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(81, 15);
            labelCount.TabIndex = 6;
            labelCount.Text = "Song Counts: ";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(552, 283);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(70, 28);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnPlay
            // 
            btnPlay.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPlay.Location = new Point(317, 66);
            btnPlay.Margin = new Padding(2);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(44, 36);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "▷";
            btnPlay.Click += btnPlay_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(463, 283);
            btnEdit.Margin = new Padding(2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(70, 28);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // pageSonglist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnEdit);
            Controls.Add(btnPlay);
            Controls.Add(btnDelete);
            Controls.Add(labelCount);
            Controls.Add(labelDuration);
            Controls.Add(searchTracks);
            Controls.Add(listBoxTracks);
            Controls.Add(labelPlaylistName);
            Name = "pageSonglist";
            Size = new Size(646, 325);
            VisibleChanged += pageSonglist_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPlaylistName;
        private ListBox listBoxTracks;
        private TextBox searchTracks;
        private Label labelDuration;
        private Label labelCount;
        private Button btnDelete;
        private Button btnPlay;
        private Button btnEdit;
    }
}
