namespace MusicPlayerApp
{
    partial class CreatePlaylist
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
            txtName = new TextBox();
            labelName = new Label();
            listTracks = new ListBox();
            btnCreate = new Button();
            btnAdd = new Button();
            btnRemove = new Button();
            listBoxPlaylist = new ListBox();
            lblAll = new Label();
            lblPlaylist = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(106, 31);
            txtName.Margin = new Padding(2, 2, 2, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(369, 23);
            txtName.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(17, 34);
            labelName.Margin = new Padding(2, 0, 2, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(85, 15);
            labelName.TabIndex = 1;
            labelName.Text = "Playlist Name: ";
            // 
            // listTracks
            // 
            listTracks.FormattingEnabled = true;
            listTracks.ItemHeight = 15;
            listTracks.Location = new Point(19, 88);
            listTracks.Margin = new Padding(2, 2, 2, 2);
            listTracks.Name = "listTracks";
            listTracks.Size = new Size(148, 139);
            listTracks.TabIndex = 2;
            listTracks.SelectedIndexChanged += listTracks_SelectedIndexChanged;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(361, 205);
            btnCreate.Margin = new Padding(1, 1, 1, 1);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(114, 20);
            btnCreate.TabIndex = 8;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            btnCreate.DialogResult = DialogResult.OK;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(361, 88);
            btnAdd.Margin = new Padding(1, 1, 1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 20);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(361, 143);
            btnRemove.Margin = new Padding(1, 1, 1, 1);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(114, 20);
            btnRemove.TabIndex = 10;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // listBoxPlaylist
            // 
            listBoxPlaylist.FormattingEnabled = true;
            listBoxPlaylist.ItemHeight = 15;
            listBoxPlaylist.Location = new Point(171, 88);
            listBoxPlaylist.Margin = new Padding(2, 2, 2, 2);
            listBoxPlaylist.Name = "listBoxPlaylist";
            listBoxPlaylist.Size = new Size(160, 139);
            listBoxPlaylist.TabIndex = 11;
            listBoxPlaylist.SelectedIndexChanged += listBoxPlaylist_SelectedIndexChanged;
            // 
            // lblAll
            // 
            lblAll.AutoSize = true;
            lblAll.Location = new Point(19, 69);
            lblAll.Margin = new Padding(2, 0, 2, 0);
            lblAll.Name = "lblAll";
            lblAll.Size = new Size(61, 15);
            lblAll.TabIndex = 12;
            lblAll.Text = "All tracks: ";
            // 
            // lblPlaylist
            // 
            lblPlaylist.AutoSize = true;
            lblPlaylist.Location = new Point(171, 69);
            lblPlaylist.Margin = new Padding(2, 0, 2, 0);
            lblPlaylist.Name = "lblPlaylist";
            lblPlaylist.Size = new Size(83, 15);
            lblPlaylist.TabIndex = 13;
            lblPlaylist.Text = "In the Playlist: ";
            // 
            // CreatePlaylist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(502, 258);
            Controls.Add(lblPlaylist);
            Controls.Add(lblAll);
            Controls.Add(listBoxPlaylist);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(btnCreate);
            Controls.Add(listTracks);
            Controls.Add(labelName);
            Controls.Add(txtName);
            Name = "CreatePlaylist";
            Text = "Create New Playlist";
            FormClosed += playlistForm_FormClosed;
            Load += playlistForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label labelName;
        private ListBox listTracks;
        private Button btnCreate;
        private Button btnAdd;
        private Button btnRemove;
        private ListBox listBoxPlaylist;
        private Label lblAll;
        private Label lblPlaylist;
    }
}