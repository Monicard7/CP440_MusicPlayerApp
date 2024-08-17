namespace MusicPlayerApp
{
    partial class pagePlaylists
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
            labelPlaylistTitle = new Label();
            searchPlaylist = new TextBox();
            btnCreate = new Button();
            listBoxPlaylists = new ListBox();
            btnUpload = new Button();
            SuspendLayout();
            // 
            // labelPlaylistTitle
            // 
            labelPlaylistTitle.AutoSize = true;
            labelPlaylistTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelPlaylistTitle.Location = new Point(36, 42);
            labelPlaylistTitle.Name = "labelPlaylistTitle";
            labelPlaylistTitle.Size = new Size(132, 40);
            labelPlaylistTitle.TabIndex = 1;
            labelPlaylistTitle.Text = "Playlists";
            labelPlaylistTitle.Click += searchPlaylist_outClick;
            // 
            // searchPlaylist
            // 
            searchPlaylist.BorderStyle = BorderStyle.FixedSingle;
            searchPlaylist.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            searchPlaylist.ForeColor = SystemColors.WindowFrame;
            searchPlaylist.Location = new Point(36, 109);
            searchPlaylist.Name = "searchPlaylist";
            searchPlaylist.Size = new Size(307, 25);
            searchPlaylist.TabIndex = 3;
            searchPlaylist.Text = "Search for playlists...";
            searchPlaylist.MouseClick += searchPlaylist_MouseClick;
            searchPlaylist.KeyPress += searchPlaylist_KeyPress;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(361, 109);
            btnCreate.Margin = new Padding(2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(65, 25);
            btnCreate.TabIndex = 7;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // listBoxPlaylists
            // 
            listBoxPlaylists.BackColor = Color.AliceBlue;
            listBoxPlaylists.BorderStyle = BorderStyle.None;
            listBoxPlaylists.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxPlaylists.FormattingEnabled = true;
            listBoxPlaylists.ItemHeight = 15;
            listBoxPlaylists.Location = new Point(36, 137);
            listBoxPlaylists.Margin = new Padding(2);
            listBoxPlaylists.Name = "listBoxPlaylists";
            listBoxPlaylists.Size = new Size(542, 120);
            listBoxPlaylists.TabIndex = 8;
            listBoxPlaylists.SelectedIndexChanged += listBoxPlaylists_SelectedIndexChanged;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(431, 109);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(112, 25);
            btnUpload.TabIndex = 11;
            btnUpload.Text = "Upload Playlist";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // pagePlaylists
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnUpload);
            Controls.Add(listBoxPlaylists);
            Controls.Add(btnCreate);
            Controls.Add(searchPlaylist);
            Controls.Add(labelPlaylistTitle);
            Name = "pagePlaylists";
            Size = new Size(646, 325);
            VisibleChanged += pagePlaylists_VisibleChanged;
            Click += searchPlaylist_outClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelPlaylistTitle;
        private TextBox searchPlaylist;
        private Button btnCreate;
        private ListBox listBoxPlaylists;
        private Button btnUpload;
    }
}
