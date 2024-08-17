using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using System.CodeDom.Compiler;
using static System.Net.Mime.MediaTypeNames;
using CSCore.SoundOut;
using CSCore;
using TagLib.Ogg;

namespace MusicPlayerApp
{
    public partial class Player : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public Player()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            pagePlaylists1.RequestAction += pagePlaylists1_RequestAction;

        }
        /// <summary>
        /// Event handler method that allows pagePlaylists to "call" a method from pageSonglist by doing it through Player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pagePlaylists1_RequestAction(object sender, EventArgs e)
        {
            pageSonglist1.UpdatePage();
        }

        public void UpdatePlayingInfo()
        {
            if (SoundOut.initialized)
            {
                // Update Display 
                labelTrackName.Text = Current.Playlist.songs[Current.Index].Title;
                labelArtists.Text = "by " + Current.Playlist.songs[Current.Index].Artist.FullName;
                
                if (Current.Playlist.songs[Current.Index].ImagePath != null)
                {
                    picAlbum.ImageLocation = Current.Playlist.songs[Current.Index].ImagePath;
                }
                else
                {
                    picAlbum.Image = Properties.Resources.Player;
                }

                pagePlaying1.UpdatePlayingInfo();
            }
            else
            {
                labelTrackName.Text = "Start your music journey";
                labelArtists.Text = "Here";
                picAlbum.Image = Properties.Resources.Player;
                progressBar.Value = 0;

                pagePlaying1.UpdatePlayingInfo();
            }  
        }

        public void StealFocus(object sender, EventArgs e)
        {
            labelTitle.Focus();

            pagePlaylists1.searchPlaylist_outClick(sender, e);

            pageViewAll1.searchTracks_outClick(sender, e);
        }

        private void panelHeader_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void Player_Load(object sender, EventArgs e)
        {
            pagePlaying1.Visible = true;
            pagePlaylists1.Visible = false;
            pageSonglist1.Visible = false;
            pageViewAll1.Visible = false;
        }

        // Timer 
        private void timerPlayer_Tick(object sender, EventArgs e)
        {
            bool initialized = SoundOut.initialized;
            WasapiOut soundOut = SoundOut.soundOut;
            UpdatePlayingInfo();

            if (initialized)
            {
                TimeSpan duration = soundOut.WaveSource.GetLength();
                labelEnd.Text = $"{(int)duration.TotalMinutes}:{duration.Seconds:00}";

                TimeSpan currentPosition = soundOut.WaveSource.GetPosition();
                labelStart.Text = $"{(int)currentPosition.TotalMinutes}:{currentPosition.Seconds:00}";

                // Next song once done 
                if (currentPosition < duration)
                {
                    progressBar.Maximum = (int)soundOut.WaveSource.Length;
                    progressBar.Value = (int)soundOut.WaveSource.Position;
                }
                else// if (currentPosition == duration)
                {
                    if (SoundOut.initialized)
                    {
                        if (Current.Index < Current.Playlist.SongsCount - 1)
                        {
                            Current.Index += 1;
                        }

                        SoundOut.soundOut.Stop();
                        pagePlaying1.InitializeSong();

                    }
                    else
                    {
                        pagePlaying1.InitializeSong();
                    }
                }
            }

            if (!pageSonglist1.Visible & !pagePlaylists1.Visible & !pageViewAll1.Visible)
            {
                pagePlaying1.Visible = true;
            } 
        }

        // Buttons On-Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            timerPlayer.Stop();
            pagePlaying1.killSong();
            this.Close();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            pagePlaying1.Visible = true;
            pagePlaylists1.Visible = false;
            pageSonglist1.Visible = false;
            pageViewAll1.Visible = false;

            StealFocus(sender, e);

        }
        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            pagePlaying1.Visible = false;
            pagePlaylists1.Visible = true;
            pageSonglist1.Visible = true;
            pageViewAll1.Visible = false;

            pagePlaylists1.loadListBox();
            StealFocus(sender, e);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //the file itself
            string fileContent = string.Empty;
            //the path to the file
            string filePath = string.Empty;

            Song importedSong = new Song();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); ;
                openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            // MessageBox.Show(filePath); // debug show filepath
            try
            {
                FileInfo file = new FileInfo(filePath);
                var tagLibFile = TagLib.File.Create(filePath);
                //string title;
                var albumPhoto = tagLibFile.Tag.Pictures.FirstOrDefault();

                if (tagLibFile.Tag.Title != null)
                {
                    importedSong.Title = tagLibFile.Tag.Title + ".mp3";
                }
                else
                {
                    importedSong.Title = file.Name;
                }

                if (albumPhoto != null)
                {
                    byte[] photoData = albumPhoto.Data.Data;

                    //create image from stream data
                    using (var stream = new MemoryStream(photoData))
                    {
                        var albumImage = System.Drawing.Image.FromStream(stream);

                        //display in picAlbum
                        picAlbum.Image = albumImage;

                        // store in song object(?)
                        importedSong.AlbumPhoto = albumImage;
                    }
                }
                else
                {
                    //do nothing -- you could have a default (no image)
                }

                // add situation for "contributing artists" as well
                string[] albumArtists = tagLibFile.Tag.AlbumArtists;
                // string artistFull;
                TimeSpan duration = tagLibFile.Properties.Duration;
                importedSong.Length = duration;

                importedSong.Path = filePath;

                try
                {
                    importedSong.Artist.FullName = string.Join(",", albumArtists);
                    if (importedSong.Artist.FullName == "")
                    {
                        importedSong.Artist.FullName = "Unnamed Artist";
                    }

                }
                catch
                {
                    MessageBox.Show("No artist found");
                    importedSong.Artist.FullName = "null";
                }

                try
                {
                    importedSong.Length = duration;
                }
                catch
                {
                    WasapiOut getLength = new WasapiOut();
                    getLength.Volume = 0;
                    importedSong.Length = getLength.WaveSource.GetLength();
                    getLength.Dispose();
                }

                Tracklist.tracks.AddSong(importedSong);

                UpdatePlayingInfo();
                pageViewAll1.loadListBox();

                if (!SoundOut.initialized)
                {
                    pagePlaying1.InitializeSong();
                }
            }
            catch
            {
                MessageBox.Show("Import failed! ");
            }

            /*
            try
            {
                SongSaver.SaveSong(importedSong.Path, importedSong);
                MessageBox.Show(importedSong.Path);
            }
            catch
            {
                MessageBox.Show("Save failed! ");
            }*/

            StealFocus(sender, e);

        }
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            pagePlaying1.Visible = false;
            pagePlaylists1.Visible = false;
            pageSonglist1.Visible = false;
            pageViewAll1.Visible = true;

            pageViewAll1.loadListBox();

            StealFocus(sender, e);
        }

        private void barVolumn_Scroll(object sender, EventArgs e)
        {
            float volumeLevel;

            try
            {

                volumeLevel = barVolumn.Value;

                if (volumeLevel < 0 | volumeLevel > 10)
                {
                    throw new Exception("Volume out of range");
                }
                //implicit convert to float then divide the float

                volumeLevel = volumeLevel / 10;
                pagePlaying1.ChangeVolume(volumeLevel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void progressBar_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                SoundOut.soundOut.WaveSource.SetPosition(SoundOut.soundOut.WaveSource.GetLength() * e.X / progressBar.Width);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Player_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundOut.soundOut.Dispose();
            pageSonglist1.Dispose();
            pagePlaying1.Dispose();
            pagePlaylists1.Dispose();
            pageViewAll1.Dispose(); 
        }

        /* validation function to check that file is .mp3 .wav 
         * string[] validExt = { ".mp3", ".wav" };  <- add to song class?? {".xml"} for playlist class?? 
        public static bool IsValid(Song song, string[] validExt)
        {
            var ext = Path.GetExtension(song.Path);
            return validExt.Contains(ext);
        } */
    }
}
