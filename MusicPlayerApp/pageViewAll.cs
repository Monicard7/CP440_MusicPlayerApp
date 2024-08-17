using CSCore;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
namespace MusicPlayerApp
{
    public partial class pageViewAll : UserControl
    {
        Playlist selected;
        Song selectedSong;
        public pageViewAll()
        {
            InitializeComponent();
            ScanFiles();
        }

        public void loadListBox()
        {
            listBoxTracks.Items.Clear();
            selectPlaylist.Items.Clear();
            appendListBox();
        }

        public void appendListBox()
        {
            foreach (Song track in Tracklist.tracks.songs)
            {
                listBoxTracks.Items.Add(track.Title);
                // MessageBox.Show("added");
            }

            foreach (Playlist playlist in ListOfPlaylists.listOfPlaylists)
            {
                selectPlaylist.Items.Add(playlist.PlaylistName);
            }
            // do not allow adding songs to default tracklist. 
            selectPlaylist.Items.Remove(Tracklist.tracks.PlaylistName);
        }

        private void searchTracks_KeyPress(object sender, EventArgs e)
        {
            if (searchTracks.Text != "")
            {

                // Clear listbox first when searching
                listBoxTracks.Items.Clear();

                foreach (Song track in Tracklist.tracks.songs)
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

        private void searchTracks_MouseClick(object sender, EventArgs e)
        {
            searchTracks.Focus();

            if (searchTracks.Text == "Search for tracks...")
            {
                searchTracks.Text = "";
            } // else, do nothing. 
        }
        public void searchTracks_outClick(object sender, EventArgs e)
        {
            labelAllTracks.Focus();

            if (searchTracks.Text == "")
            {
                searchTracks.Text = "Search for tracks...";
            } // else, do nothing. 
        }

        private void listBoxTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            // make btnDelete visible
            btnDelete.Visible = true;

            foreach (Song track in Tracklist.tracks.songs)
            {
                if (listBox.SelectedItem != null)
                {
                    if (track.Title.Contains(listBox.SelectedItem.ToString()))
                    {
                        selectedSong = track;
                        /*
                        // if Track title contains searchbox text, add its title to listbox. 
                        Current.Playlist = Tracklist.tracks;
                        Current.Song = track;
                        Current.Index = Current.GetIndex();

                        SoundOut.soundOut.Stop();
                        SoundOut.InitializeSong();
                        SoundOut.soundOut.Play();
                        */

                        // Calculate length
                        //track.SetLength(SoundOut.soundOut.WaveSource.GetLength());

                        // display metadata
                        labelAllTracks.Text = track.Title;
                        labelArtist.Text = "Artist(s): " + track.Artist.FullName;
                        labelDuration.Text = "Duration: " + $"{(int)track.Length.TotalMinutes}:{track.Length.Seconds:00}";
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // playlistSaver currentPlaylist = new playlistSaver();
            if (selected != null)
            {
                if (listBoxTracks.SelectedIndex != -1)
                {
                    selected.AddSong(Tracklist.tracks.songs[listBoxTracks.SelectedIndex]);
                }
                else
                {
                    MessageBox.Show("No song selected", "Error");
                }
            }
            else
            {
                CreatePlaylist f = new CreatePlaylist();

                if (f.ShowDialog() == DialogResult.OK)
                {
                    loadListBox();
                }
            }

            //ListOfPlaylists.CreatePlaylist(new Playlist(txtPlaylistName.Text, new List<Song> { Tracklist.tracks.songs[listBoxTracks.SelectedIndex] }));

        }

        private void pageViewAll_Load(object sender, EventArgs e)
        {

        }

        private void selectPlaylist_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (Playlist playlist in ListOfPlaylists.listOfPlaylists)
            {
                if (selectPlaylist.SelectedItem != null)
                {
                    if (playlist.PlaylistName.Contains(selectPlaylist.SelectedItem.ToString()))
                    {
                        selected = playlist;
                    }
                    else
                    {
                        // do nothing
                    }
                }
                else
                {
                    // do nothing
                }
            }
        }

        private void ScanFiles()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Imported_Songs";
            string imageFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Album_Images";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            // Scan Songs
            string[] fileEntries = Directory.GetFiles(folder);
            string fileContent;

            foreach (string filePath in fileEntries)
            {
                if (filePath.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
                {
                    Song newSong = new Song();

                    //Read the contents of the file into a stream
                    var fileStream = File.Open(filePath, FileMode.Open);

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    try
                    {
                        FileInfo file = new FileInfo(filePath);
                        var tagLibFile = TagLib.File.Create(filePath);
                        //string title;
                        //var albumPhoto = tagLibFile.Tag.Pictures.FirstOrDefault();

                        if (tagLibFile.Tag.Title != null)
                        {
                            newSong.Title = tagLibFile.Tag.Title;
                        }
                        else
                        {
                            newSong.Title = file.Name;
                        }
                        /*
                        if (albumPhoto != null)
                        {
                            byte[] photoData = albumPhoto.Data.Data;

                            //create image from stream data
                            using (var stream = new MemoryStream(photoData))
                            {
                                var albumImage = System.Drawing.Image.FromStream(stream);

                                // store in song object(?)
                                newSong.AlbumPhoto = albumImage;
                            }
                        }
                        else
                        {
                            //do nothing -- you could have a default (no image)
                        }*/

                        // add situation for "contributing artists" as well
                        string[] albumArtists = tagLibFile.Tag.AlbumArtists;
                        // string artistFull;
                        TimeSpan duration = tagLibFile.Properties.Duration;
                        newSong.Length = duration;

                        newSong.Path = filePath;

                        try
                        {
                            newSong.Artist.FullName = string.Join(",", albumArtists);
                            if (newSong.Artist.FullName == "")
                            {
                                newSong.Artist.FullName = "Unnamed Artist";
                            }

                        }
                        catch
                        {
                            MessageBox.Show("No artist found");
                            newSong.Artist.FullName = "null";
                        }

                        try
                        {
                            newSong.Length = duration;
                        }
                        catch
                        {
                            WasapiOut getLength = new WasapiOut();
                            getLength.Volume = 0;
                            newSong.Length = getLength.WaveSource.GetLength();
                            getLength.Dispose();
                        }

                        Tracklist.tracks.AddSong(newSong);

                        loadListBox();
                    }
                    catch
                    {
                        MessageBox.Show("Load songs failed! ");
                    }
                }
                else
                {
                    //File.Delete(filePath);
                }
            }

            // Scan Images
            string[] imageEntries = Directory.GetFiles(imageFolder);

            foreach (string imageEntry in imageEntries)
            {
                foreach (Song s in Tracklist.tracks.songs)
                {
                    if (imageEntry.Contains(s.Title))
                    {
                        s.ImagePath = imageEntry;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTracks.SelectedIndex != null)
            {
                if (listBoxTracks.SelectedIndex < Current.Index)
                {
                    Current.Index -= 1;

                    Tracklist.tracks.RemoveSong(Tracklist.tracks.songs[listBoxTracks.SelectedIndex]);
                    Current.Playlist = Tracklist.tracks;
                    loadListBox();
                    btnDelete.Visible = false;

                    labelAllTracks.Text = "All Tracks";
                }
                else if (listBoxTracks.SelectedIndex > Current.Index)
                {
                    Tracklist.tracks.RemoveSong(Tracklist.tracks.songs[listBoxTracks.SelectedIndex]);
                    Current.Playlist = Tracklist.tracks;
                    loadListBox();
                    btnDelete.Visible = false;

                    labelAllTracks.Text = "All Tracks";
                }
                else if (SoundOut.soundOut.PlaybackState == PlaybackState.Stopped && Current.Index == 0)
                {
                    Tracklist.tracks.RemoveSong(Tracklist.tracks.songs[listBoxTracks.SelectedIndex]);
                    loadListBox();
                    btnDelete.Visible = false;

                    labelAllTracks.Text = "All Tracks";
                }
                else
                {
                    MessageBox.Show("Deletion failed: Selected Song is currently playing! ");
                }

                
            }
            else
            {
                // nothing
            }
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
