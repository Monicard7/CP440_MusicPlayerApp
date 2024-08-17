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
using System.Xml;
using System.Xml.Linq;

namespace MusicPlayerApp
{
    public partial class pagePlaylists : UserControl
    {
        List<string> streams = new List<string>();
        int _songsCount = 0;

        private Playlist playlist; // may want to move this to where it is needed

        public event EventHandler RequestAction;
        protected virtual void OnRequestAction()
        {
            RequestAction?.Invoke(this, EventArgs.Empty);
        }
        public void loadListBox()
        {
            listBoxPlaylists.Items.Clear();
            appendListBox();
        }

        public void appendListBox()
        {
            foreach (Playlist tempPlaylist in ListOfPlaylists.listOfPlaylists)
            {
                listBoxPlaylists.Items.Add(tempPlaylist.PlaylistName);
                // MessageBox.Show("added");
            }
        }
        public pagePlaylists()
        {
            InitializeComponent();
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MusicPA";
            ScanFiles(dir);
        }
        /// <summary>
        /// scan songs
        /// getfiles code taken from:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=net-8.0
        /// </summary>
        /// <param name="targetDirectory">path to directory</param>
        private void ScanFiles(string targetDirectory)
        {
            playlistReader reader = new playlistReader();
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            string fileName;
            foreach (string filePath in fileEntries)
            {
                if (filePath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        fileName = Path.GetFileNameWithoutExtension(filePath);
                        Playlist playlist = new Playlist(fileName);
                        XDocument xmlFile = XDocument.Load(filePath); // https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xdocument?view=net-8.0

                        foreach (XElement songXElement in xmlFile.Descendants("Song"))
                        {
                            //add more variables
                            string songPath = songXElement.Element("Path").Value;
                            string songTitle = songXElement.Element("Title").Value;
                            TimeSpan songLength = XmlConvert.ToTimeSpan(songXElement.Element("Length").Value);
                            Artist artist = new Artist();
                            artist.FullName = songXElement.Descendants("Artist").Elements("FullName").First().Value;
                            Song song = new Song(songPath, songTitle, songLength, artist);
                            playlist.AddSong(song);
                            
                        }
                        if (playlist != null)
                        {
                            ListOfPlaylists.CreatePlaylist(playlist);
                            loadListBox();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("malformed or invalid playlist file.");
                    }
                    //playlist.CalculateTotalTime();
                }

            }

        }
        private void searchPlaylist_KeyPress(object sender, EventArgs e)
        {
            if (searchPlaylist.Text != "")
            {
                // Clear listbox first when searching
                listBoxPlaylists.Items.Clear();

                foreach (Playlist playlist in ListOfPlaylists.listOfPlaylists)
                {
                    if (playlist.PlaylistName.Contains(searchPlaylist.Text))
                    {
                        // if Playlist title contains searchbox text, add its title to listbox. 
                        listBoxPlaylists.Items.Add((string)playlist.PlaylistName);
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

        private void searchPlaylist_MouseClick(object sender, EventArgs e)
        {
            searchPlaylist.Focus();

            if (searchPlaylist.Text == "Search for playlists...")
            {
                searchPlaylist.Text = "";

            } // else, do nothing. 
        }

        public void searchPlaylist_outClick(object sender, EventArgs e)
        {
            labelPlaylistTitle.Focus();

            if (searchPlaylist.Text == "")
            {
                searchPlaylist.Text = "Search for playlists...";
            } // else, do nothing. 
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreatePlaylist f = new CreatePlaylist();

            if (f.ShowDialog() == DialogResult.OK)
            {
                loadListBox();
            }
        }

        private void listBoxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            ListOfPlaylists.SelectedIndex = listBox.SelectedIndex;
            //MessageBox.Show(ListOfPlaylists.SelectedIndex.ToString());

            foreach (Playlist playlist in ListOfPlaylists.listOfPlaylists)
            {
                if (listBox.SelectedItem != null)
                {
                    if (playlist.PlaylistName.Contains(listBox.SelectedItem.ToString()))
                    {
                        OnRequestAction();
                        this.Visible = false;
                    }
                }
                    
            }
        }

        private void pagePlaylists_VisibleChanged(object sender, EventArgs e)
        {
            listBoxPlaylists.Items.Clear();

            if (ListOfPlaylists.listOfPlaylists != null)
            {
                foreach (Playlist p in ListOfPlaylists.listOfPlaylists)
                {
                    listBoxPlaylists.Items.Add((string)p.PlaylistName);
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Upload single playlist to the playlists list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            //playlistReader reader = new playlistReader();
            //Playlist playlist;
            string filePath = string.Empty;
            string fileName;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); ;
                openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName; // FileName is not to be confused with the string fileName
                        fileName = Path.GetFileNameWithoutExtension(openFileDialog.SafeFileName);
                        playlist = new Playlist(fileName);
                        XDocument xmlFile = XDocument.Load(filePath); // https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xdocument?view=net-8.0

                        foreach (XElement songXElement in xmlFile.Descendants("Song"))
                        {
                            //add more variables
                            string songPath = songXElement.Element("Path").Value;
                            string songTitle = songXElement.Element("Title").Value;
                            TimeSpan songLength = XmlConvert.ToTimeSpan(songXElement.Element("Length").Value);
                            Artist artist = new Artist();
                            artist.FullName = songXElement.Descendants("Artist").Elements("FullName").First().Value;
                            Song song = new Song(songPath, songTitle, songLength, artist);
                            playlist.AddSong(song);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("malformed or invalid playlist file.");
                    }
                    //playlist.CalculateTotalTime();
                }
            }
            //check to see if playlist is null(e.g. cancel filepicker
            if (playlist != null)
            {
                ListOfPlaylists.CreatePlaylist(playlist);
                loadListBox();
            }
            else
            {
                MessageBox.Show("Nothing has been uploaded.", "ERROR");
            }
            //dispose of reader/clear songs
            //reader.Dispose();
        }
    }
}
