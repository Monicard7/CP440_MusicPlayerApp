namespace MusicPlayerApp
{
    partial class EditPlaylist
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
            lblPlaylist = new Label();
            lblAll = new Label();
            listBoxPlaylist = new ListBox();
            btnRemove = new Button();
            btnAdd = new Button();
            btnSubmit = new Button();
            listTracks = new ListBox();
            labelName = new Label();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // lblPlaylist
            // 
            lblPlaylist.AutoSize = true;
            lblPlaylist.Location = new Point(186, 79);
            lblPlaylist.Name = "lblPlaylist";
            lblPlaylist.Size = new Size(83, 15);
            lblPlaylist.TabIndex = 22;
            lblPlaylist.Text = "In the Playlist: ";
            // 
            // lblAll
            // 
            lblAll.AutoSize = true;
            lblAll.Location = new Point(20, 79);
            lblAll.Name = "lblAll";
            lblAll.Size = new Size(61, 15);
            lblAll.TabIndex = 21;
            lblAll.Text = "All tracks: ";
            // 
            // listBoxPlaylist
            // 
            listBoxPlaylist.FormattingEnabled = true;
            listBoxPlaylist.ItemHeight = 15;
            listBoxPlaylist.Location = new Point(186, 106);
            listBoxPlaylist.Name = "listBoxPlaylist";
            listBoxPlaylist.Size = new Size(160, 139);
            listBoxPlaylist.TabIndex = 20;
            listBoxPlaylist.SelectedIndexChanged += listBoxPlaylist_SelectedIndexChanged;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(374, 160);
            btnRemove.Margin = new Padding(2);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(114, 20);
            btnRemove.TabIndex = 19;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(374, 101);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 20);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(374, 220);
            btnSubmit.Margin = new Padding(2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(114, 20);
            btnSubmit.TabIndex = 17;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            btnSubmit.DialogResult = DialogResult.OK;
            // 
            // listTracks
            // 
            listTracks.FormattingEnabled = true;
            listTracks.ItemHeight = 15;
            listTracks.Location = new Point(20, 106);
            listTracks.Name = "listTracks";
            listTracks.Size = new Size(160, 139);
            listTracks.TabIndex = 16;
            listTracks.SelectedIndexChanged += listTracks_SelectedIndexChanged;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(22, 29);
            labelName.Name = "labelName";
            labelName.Size = new Size(85, 15);
            labelName.TabIndex = 15;
            labelName.Text = "Playlist Name: ";
            // 
            // txtName
            // 
            txtName.Location = new Point(113, 26);
            txtName.Name = "txtName";
            txtName.Size = new Size(335, 23);
            txtName.TabIndex = 14;
            // 
            // EditPlaylist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 285);
            Controls.Add(lblPlaylist);
            Controls.Add(lblAll);
            Controls.Add(listBoxPlaylist);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(btnSubmit);
            Controls.Add(listTracks);
            Controls.Add(labelName);
            Controls.Add(txtName);
            Name = "EditPlaylist";
            Text = "EditPlaylist";
            FormClosed += playlistForm_FormClosed;
            Load += EditPlaylist_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlaylist;
        private Label lblAll;
        private ListBox listBoxPlaylist;
        private Button btnRemove;
        private Button btnAdd;
        private Button btnSubmit;
        private ListBox listTracks;
        private Label labelName;
        private TextBox txtName;
    }
}