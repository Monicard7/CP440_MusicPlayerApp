using CSCore;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MusicPlayerApp
{
    public partial class pageSonglist : UserControl
    {
        Playlist current;
        Song selectedSong;
        public pageSonglist()
        {
            InitializeComponent();
        }

        public void loadListBox()
        {
            listBoxTracks.Items.Clear();
            appendListBox();
        }

        public void appendListBox()
        {
            try
            {
                foreach (Song track in current.songs)
                {
                    listBoxTracks.Items.Add((string)track.Title);
                    // MessageBox.Show("added");
                }
            }
            catch { }
        }
        private void searchTracks_KeyPress(object sender, EventArgs e)
        {
            if (searchTracks.Text != "")
            {
                // Clear listbox first when searching
                listBoxTracks.Items.Clear();

                foreach (Song track in current.songs)
                {
                    if (track.Title.Contains(searchTracks.Text))
                    {
                        // if Track title contains searchbox text, add its title to listbox. 
                        listBoxTracks.Items.Add((string)track.Title);
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }
            else
            {
                // do nothing
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListOfPlaylists.RemovePlaylist(ListOfPlaylists.listOfPlaylists[ListOfPlaylists.SelectedIndex]);
            ListOfPlaylists.SelectedIndex = 0;

            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPlaylist f = new EditPlaylist();

            if (f.ShowDialog() == DialogResult.OK)
            {
                loadListBox();
            }
        }

        public void UpdatePage()
        {
            current = ListOfPlaylists.listOfPlaylists[ListOfPlaylists.SelectedIndex];

            TimeSpan duration = current.TotalTime;
            labelPlaylistName.Text = current.PlaylistName;
            labelCount.Text = "Song Count: " + current.SongsCount.ToString();
            labelDuration.Text = "Duration: " + $"{(int)duration.TotalMinutes}:{duration.Seconds:00}";

            if (ListOfPlaylists.SelectedIndex == 0)
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }

            loadListBox();
        }

        private void searchTracks_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchTracks_Click(object sender, EventArgs e)
        {
            searchTracks.Focus();

            if (searchTracks.Text == "Search for tracks...")
            {
                searchTracks.Text = "";

            } // else, do nothing. 
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (SoundOut.initialized)
            {
                SoundOut.soundOut.Stop();
                SoundOut.InitializeSong();
                SoundOut.soundOut.Play();
            }
            else
            {
                SoundOut.InitializeSong();
                SoundOut.soundOut.Play();
            }
        }

        private void listBoxTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            try
            {
                foreach (Song track in current.songs)
                {
                    if (track.Title.Contains(listBox.SelectedItem.ToString()))
                    {
                        selectedSong = track;

                        /*
                        Current.Playlist = current;
                        Current.Song = track;
                        Current.Index = Current.GetIndex();

                        SoundOut.InitializeSong();
                        // track.SetLength(SoundOut.soundOut.WaveSource.GetLength());
                        SoundOut.soundOut.Play();*/
                    }
                }
            }
            catch
            {
                MessageBox.Show("Song not found! ");
            }

        }

        private void pageSonglist_VisibleChanged(object sender, EventArgs e)
        {
            UpdatePage();
            loadListBox();
        }

        private void listBoxTracks_DoubleClick(object sender, EventArgs e)
        {
            Current.Playlist = Tracklist.tracks;
            Current.Song = selectedSong;
            Current.Index = Current.GetIndex();

            SoundOut.soundOut.Stop();
            SoundOut.InitializeSong();
            SoundOut.soundOut.Play();
        }
    }
}

