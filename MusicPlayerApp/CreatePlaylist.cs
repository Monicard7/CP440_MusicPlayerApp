using CSCore;
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
    public partial class CreatePlaylist : Form
    {
        Playlist newPlaylist = new Playlist("default");

        public CreatePlaylist()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Song track in Tracklist.tracks.songs)
                {
                    if (track.Title.Contains(listTracks.SelectedItem.ToString()))
                    {
                        newPlaylist.AddSong(track);
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }
            catch
            {
                // do nothing
            }

            listBoxPlaylist.Items.Clear();

            foreach (Song track in newPlaylist.songs)
            {
                listBoxPlaylist.Items.Add(track.Title);
                // MessageBox.Show("added");
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Song track in newPlaylist.songs)
                {
                    if (track.Title.Contains(listBoxPlaylist.SelectedItem.ToString()))
                    {
                        newPlaylist.RemoveSong(track);
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }
            catch
            {
                // do nothing 
            }

            listBoxPlaylist.Items.Clear();

            foreach (Song track in newPlaylist.songs)
            {
                listBoxPlaylist.Items.Add(track.Title);
                // MessageBox.Show("added");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtName != null)
            {
                newPlaylist.PlaylistName = txtName.Text;
            }
            else
            {
                newPlaylist.PlaylistName += ListOfPlaylists.count;
            }

            ListOfPlaylists.CreatePlaylist(newPlaylist);
            playlistSaver.SaveList(newPlaylist.PlaylistName, newPlaylist.songs);

            // navigate back to main player 
            this.Hide();
            this.Close();
        }

        private void playlistForm_Load(object sender, EventArgs e)
        {
            listTracks.Items.Clear();

            foreach (Song track in Tracklist.tracks.songs)
            {
                listTracks.Items.Add(track.Title);
                // MessageBox.Show("added");
            }

        }

        private void listTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            listTracks.Focus();
            listBoxPlaylist.ClearSelected();
        }

        private void listBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPlaylist.Focus();
            listTracks.ClearSelected();
        }

        private void playlistForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
