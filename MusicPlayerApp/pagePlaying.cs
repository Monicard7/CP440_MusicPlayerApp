using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using CSCore.Streams;

namespace MusicPlayerApp
{
    public partial class pagePlaying : UserControl
    {
        //Playlist ListOfSongs = Current.Playlist; 
        // int SongIndex = Current.Index;
        float currentVol = 1;

        public pagePlaying()
        {
            InitializeComponent();
        }

        public void ChangeVolume(float volume)
        {
            if (SoundOut.initialized)
            {
                SoundOut.soundOut.Volume = volume;
            }
            //handle if the song isn't initializated and store it in a variable to run during InitializeSong    
            if (!SoundOut.initialized)
            {
                currentVol = volume;
            }
        }

        public void UpdatePlayingInfo()
        {
            if (SoundOut.initialized)
            {
                // Change page layout
                labelName.Location = new Point(334, 49);
                labelName.Size = new Size(215, 100);

                labelName.Text = Current.Playlist.songs[Current.Index].Title;
                labelMetadata.Text = "Artist(s): " + Current.Playlist.songs[Current.Index].Artist.FullName;

                // display album photo if exists, otherwise default image. 
                if (Current.Playlist.songs[Current.Index].ImagePath != null)
                {
                    picAlbum.ImageLocation = Current.Playlist.songs[Current.Index].ImagePath;
                }
                else
                {
                    picAlbum.Image = Properties.Resources.Player;
                }
                
            }
            else
            {
                labelName.Location = new Point(334, 120);

                labelName.Text = "Start listening";
                labelMetadata.Text = "";
                picAlbum.Image = Properties.Resources.Player;
            }
        }

        //method to stop song from other classes. Is a bool if the failure to close a song needs to be handled.
        public bool killSong()
        {
            try
            {
                SoundOut.soundOut.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void InitializeSong()
        {
            SoundOut.InitializeSong(Current.Playlist.songs[Current.Index]);
            SoundOut.soundOut.Volume = currentVol;
            SoundOut.initialized = true;
            SoundOut.soundOut.Play();

            UpdatePlayingInfo();

            buttonPlay.Text = "| |";
        }

        async private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (SoundOut.soundOut.PlaybackState == PlaybackState.Playing)
            {
                SoundOut.soundOut.Pause();
                buttonPlay.Text = "▷";
            }
            else if (SoundOut.soundOut.PlaybackState == PlaybackState.Paused)
            {
                SoundOut.soundOut.Resume();
                buttonPlay.Text = "| |";
            }
            else
            {
                try
                {
                    InitializeSong();
                    buttonPlay.Text = "| |";
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("No song was added to the playlist", "No songs added.");
                }
            }


        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            buttonPlay.Text = "| |";
            if (SoundOut.initialized)
            {
                if (Current.Index > 0)
                {
                    Current.Index -= 1;
                }

                SoundOut.soundOut.Stop();
                InitializeSong();
            }
            else
            {
                InitializeSong();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            buttonPlay.Text = "| |";

            if (SoundOut.initialized)
            {
                if (Current.Index < Current.Playlist.SongsCount - 1)
                {
                    Current.Index += 1;
                }

                SoundOut.soundOut.Stop();
                InitializeSong();

            }
            else
            {
                InitializeSong();
            }
        }

        private void pagePlaying_VisibleChanged(object sender, EventArgs e)
        {
            if (SoundOut.soundOut.PlaybackState == PlaybackState.Playing)
            {
                buttonPlay.Text = "| |";
            }
            else
            {
                buttonPlay.Text = "▷";
            }

            // Make labelName autoscroll: 

            /* 
            if (labelName.Location.X > panelName.Location.X) {
                 panelName.AutoScroll = true; 
                if (panelName.AutoScrollMargin.Width < 5) {
                    panelName.SetAutoScrollMargin(5, 5);
                }
            }
             */
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            SoundOut.initialized = false;
            buttonPlay.Text = "▷";

            killSong();
            SoundOut.soundOut = new WasapiOut();
        }

        private void UploadImage()
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPG files (*.jpg)|*.jpg| PNG Files (*.PNG)|*.png| All files (*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    //MessageBox.Show(dialog.FileName);

                    Current.Song.ImagePath = imageLocation;
                    SongSaver.SaveImage(imageLocation, Current.Song);
                    //MessageBox.Show(Current.Song.ImagePath);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error: " + ex.Message);
                MessageBox.Show("Image upload failed! ");
            }
        }
        private void ReplaceImage()
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPG files (*.jpg)|*.jpg| PNG Filea (*.PNG)|*.png| All files (*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    //MessageBox.Show(dialog.FileName);

                    Current.Song.ImagePath = imageLocation;
                    SongSaver.ReplaceImage(imageLocation, Current.Song);
                    //MessageBox.Show(Current.Song.ImagePath);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error: " + ex.Message);
                MessageBox.Show("Image replace failed! ");
            }
        }
        private void picAlbum_Click(object sender, EventArgs e) // Upload Album Image
        {
            //string imageLocation = "";
            if (SoundOut.initialized) // when song is initialized (playing or paused)
            {
                if (Current.Song.ImagePath == null && Current.Song.AlbumPhoto == null) // when no image exists 
                {
                    UploadImage();
                }
                else
                {
                    DialogResult action = MessageBox.Show("Do you want to change the album picture for this song?", "Confirmation", MessageBoxButtons.YesNo);
                    
                    if (action == DialogResult.Yes)
                    {
                        try
                        {
                            ReplaceImage();
                        }
                        catch
                        {
                            MessageBox.Show("Upload failed! ");
                        }
                    }
                }
            }
            else
            {
                // do nothing
            }
        }
    }
}
