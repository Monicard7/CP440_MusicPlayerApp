namespace MusicPlayerApp
{
    partial class pagePlaying
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
            labelName = new Label();
            labelMetadata = new Label();
            picAlbum = new PictureBox();
            buttonNext = new Button();
            buttonPrevious = new Button();
            buttonPlay = new Button();
            btnKill = new Button();
            ((System.ComponentModel.ISupportInitialize)picAlbum).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelName.Location = new Point(334, 120);
            labelName.MaximumSize = new Size(250, 50);
            labelName.Name = "labelName";
            labelName.Size = new Size(215, 40);
            labelName.TabIndex = 24;
            labelName.Text = "Start Listening";
            // 
            // labelMetadata
            // 
            labelMetadata.AutoSize = true;
            labelMetadata.Font = new Font("Segoe UI Historic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelMetadata.Location = new Point(334, 138);
            labelMetadata.Name = "labelMetadata";
            labelMetadata.Size = new Size(0, 17);
            labelMetadata.TabIndex = 23;
            // 
            // picAlbum
            // 
            picAlbum.BackColor = Color.LightCyan;
            picAlbum.BackgroundImageLayout = ImageLayout.None;
            picAlbum.BorderStyle = BorderStyle.Fixed3D;
            picAlbum.Image = Properties.Resources.Player;
            picAlbum.InitialImage = null;
            picAlbum.Location = new Point(81, 49);
            picAlbum.Name = "picAlbum";
            picAlbum.Size = new Size(194, 177);
            picAlbum.SizeMode = PictureBoxSizeMode.StretchImage;
            picAlbum.TabIndex = 22;
            picAlbum.TabStop = false;
            picAlbum.Click += picAlbum_Click;
            // 
            // buttonNext
            // 
            buttonNext.Cursor = Cursors.Hand;
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNext.Location = new Point(182, 244);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(49, 46);
            buttonNext.TabIndex = 21;
            buttonNext.Text = "▸▷";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonPrevious
            // 
            buttonPrevious.BackColor = Color.AliceBlue;
            buttonPrevious.Cursor = Cursors.Hand;
            buttonPrevious.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            buttonPrevious.FlatAppearance.BorderSize = 0;
            buttonPrevious.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption;
            buttonPrevious.FlatStyle = FlatStyle.Flat;
            buttonPrevious.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPrevious.Location = new Point(68, 244);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new Size(50, 46);
            buttonPrevious.TabIndex = 20;
            buttonPrevious.Text = "◁◂";
            buttonPrevious.UseVisualStyleBackColor = false;
            buttonPrevious.Click += buttonPrevious_Click;
            // 
            // buttonPlay
            // 
            buttonPlay.Cursor = Cursors.Hand;
            buttonPlay.FlatAppearance.BorderSize = 0;
            buttonPlay.FlatStyle = FlatStyle.Flat;
            buttonPlay.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPlay.Location = new Point(124, 244);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(52, 46);
            buttonPlay.TabIndex = 19;
            buttonPlay.Text = "▷";
            buttonPlay.UseVisualStyleBackColor = true;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // btnKill
            // 
            btnKill.Cursor = Cursors.Hand;
            btnKill.FlatAppearance.BorderSize = 0;
            btnKill.FlatStyle = FlatStyle.Flat;
            btnKill.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnKill.Location = new Point(237, 244);
            btnKill.Name = "btnKill";
            btnKill.Size = new Size(50, 46);
            btnKill.TabIndex = 25;
            btnKill.Text = "■";
            btnKill.UseVisualStyleBackColor = true;
            btnKill.Click += btnKill_Click;
            // 
            // pagePlaying
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnKill);
            Controls.Add(labelName);
            Controls.Add(labelMetadata);
            Controls.Add(picAlbum);
            Controls.Add(buttonNext);
            Controls.Add(buttonPrevious);
            Controls.Add(buttonPlay);
            Name = "pagePlaying";
            Size = new Size(646, 325);
            VisibleChanged += pagePlaying_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)picAlbum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelMetadata;
        private PictureBox picAlbum;
        private Button buttonNext;
        private Button buttonPrevious;
        private Button buttonPlay;
        private Button btnKill;
    }
}
