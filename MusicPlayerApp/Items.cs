using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCore.SoundOut;
using CSCore;
using Microsoft.Win32.SafeHandles;
using CSCore.Codecs;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MusicPlayerApp
{
    internal class Items
    {
    }
    /// <summary>
    /// The Artist Class. This is a simple class that holds the name of the artists for now. In the future, this could hold more information after downloading artist information from the internet.
    /// </summary>
    public class Artist
    {
        string _name;

        // default constructor
        public Artist()
        {
            _name = "Artist";
        }
        // constructor to provide the artist name
        public Artist(string Name)
        {
            _name = Name;
        }



        // accessor variable to get the fullname of the artist
        public string FullName
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    /// <summary>
    /// This is the class for a Playlist. A playlist contains song objects, the name of itself, and the total length of the playlist.
    /// </summary>
    public class Playlist
    {

        string _playlistName;
        public List<Song> songs = new List<Song>();
        int _songsCount = 0; //keeps track of number of songs
        TimeSpan totalTime = TimeSpan.Zero; //total time of songs

        public Playlist(string playlistName)
        {
            _playlistName = playlistName;
        }

        public Playlist(string playlistName, List<Song> listOfSongs)
        {
            _playlistName = playlistName;
            songs = listOfSongs;
        }

        public string PlaylistName
        {
            get { return _playlistName; }
            set { _playlistName = value; }
        }

        public int SongsCount
        {
            get { return _songsCount; }
        }
        public void AddSong(Song newSong)
        {
            songs.Add(newSong);
            TotalTime += newSong.Length;
            _songsCount++;

            SongSaver.SaveSong(newSong.Path, newSong);
        }

        public void RemoveSong(Song newSong)
        {
            SongSaver.DeleteSong(newSong);

            songs.Remove(newSong);
            TotalTime -= newSong.Length;
            _songsCount--;
        }
        public TimeSpan TotalTime { 
            get { return totalTime; } 
            set { totalTime = value; }
        }
    }
    public static class ListOfPlaylists
    {
        public static List<Playlist> listOfPlaylists = new List<Playlist>() { Tracklist.tracks };

        public static int SelectedIndex = 0;

        public static int count = 0;
        public static void CreatePlaylist(Playlist newPlaylist)
        {
            listOfPlaylists.Add(newPlaylist);

            playlistSaver.SaveList(newPlaylist.PlaylistName, newPlaylist.songs);
        }

        public static void RemovePlaylist(Playlist playlist)
        {
            listOfPlaylists.Remove(playlist);

            playlistSaver.DeleteList(playlist.PlaylistName);
        }
    }
    public static class Tracklist
    {

        public static Playlist tracks = new Playlist("Tracklist");
        public static int _tracksCount = 0;
        public static TimeSpan totalTime { get; set; }

    }

    /// <summary>
    /// This is the primary song object. The song object holds the path to the audio file on disk, the title, an artist object,
    /// </summary>
    public class Song
    {
        Artist _artist = new Artist();
        string _title;
        string _albumName;
        string _path;
        Image _photo;
        string _imagePath;
        TimeSpan _length;

        

        // constructors

        //if NOTHING exists(should NOT happen);
        public Song()
        {
            // may be some issues with objects with the same name? but it should be fine?
            // anyways this may need to be rethought.
            Artist _artist = new Artist();
            Length = new TimeSpan(0);
            _title = "Default";
            _albumName = "Single";
            _path = "";

        }
        //if only path metadata is added
        public Song(string path) : this()
        {
            _path = path;
        }
        public Song(string path, string title) : this(path)
        {
            _title = title;
        }
        public Song(string path, string title, TimeSpan length) : this(path, title)
        {
            Length = length;
        }

        public Song(string path, string title, TimeSpan Length, Artist artist) : this(path, title, Length)
        {
            // we may need to change this. I think at the moment it accesses the artist but we may actually want to copy the artist instead.
            // the artist class is extremely simple(at the moment) so it shouldn't be difficult to do if needed.
            // we may also need to get the name of the artist. Ideally artists should be reused between songs.
            _artist = artist;
        }
        
        public Song (string path, string title, TimeSpan length, Artist artist, Image photo) : this(path, title, length)
        {
            _photo = photo;
        }


        // getters and setters}
        public TimeSpan Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string AlbumName
        {
            get { return _albumName; }
            set { _albumName = value; }
        }
        public Artist Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        [XmlIgnore]
        public Image AlbumPhoto
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }
    }

    public static class SoundOut
    {
        public static WasapiOut soundOut = new WasapiOut();
        public static bool initialized = false;

        public static void InitializeSong(Song song)
        {
            if (initialized == true)
            {
                soundOut.Stop();
                soundOut.Initialize(CodecFactory.Instance.GetCodec(song.Path));
                initialized = true;
            }
            else
            {
                soundOut.Initialize(CodecFactory.Instance.GetCodec(song.Path));
                initialized = true;
            }
        }
        public static void InitializeSong()
        {
            if (initialized == true)
            {
                soundOut.Stop();
                soundOut.Initialize(CodecFactory.Instance.GetCodec(Current.Playlist.songs[Current.Index].Path));
                initialized = true;
            }
            else
            {
                soundOut.Initialize(CodecFactory.Instance.GetCodec(Current.Playlist.songs[Current.Index].Path));
                initialized = true;
            }
        }

    }

    public static class Current
    {
        public static Playlist Playlist = Tracklist.tracks;
        public static int Index = 0;
        public static Song Song = Playlist.songs[Index];

        public static int GetIndex()
        {
            int index = 0;

            for (int i = 0; i < Playlist.SongsCount; i++)
            {
                if (Song.Title.Contains(Playlist.songs[i].Title) )
                {
                    index = i;
                }
            }

            return index;
        }

        public static void SetIndex(int i)
        {
            Index = i;
        }
    }
}

