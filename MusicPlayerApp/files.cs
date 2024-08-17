using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.CompilerServices;
using CSCore.SoundOut;
using CSCore;

namespace MusicPlayerApp
{
    /// <summary>
    /// utility class to save songs
    /// </summary>
    public static class playlistSaver
    {
        /// <summary>
        /// Saves a song list to an xml file using filestreams and xmlserializer
        /// https://learn.microsoft.com/en-us/dotnet/api/system.io.filestream?view=net-8.0
        /// https://learn.microsoft.com/en-us/dotnet/standard/serialization/how-to-serialize-an-object
        /// 
        /// </summary>
        /// <param name="filename">Name of Playlist</param>
        /// <param name="songs">Playlist Object to Import</param>
        /// 

        // save new list, and save editted list if name unchanged. 
        public static void SaveList(string filename, List<Song> songs)
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MusicPA";

            //if the directory does not exist, create it.
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
            
            using (StreamWriter writer = new StreamWriter(filepath + "\\" + filename + ".xml")) 
            {
                serializer.Serialize(writer, songs);
            }
            
        }

        // save editted list if name changed.
        public static void EditList(string filename, string newfilename, List<Song> songs)
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MusicPA";

            XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));

            File.Delete(filepath + "\\" + filename + ".xml");

            using (StreamWriter writer = new StreamWriter(filepath + "\\" + newfilename + ".xml"))
            {
                serializer.Serialize(writer, songs);
            }
        }

        public static void DeleteList(string filename)
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MusicPA";

            File.Delete(filepath + "\\" + filename + ".xml");
        }
    }

    public static class SongSaver
    {
        public static void SaveSong(string filePath, Song newSong)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Imported_Songs";
            string songPath = folderPath + "\\" + newSong.Title;

            if (!File.Exists(songPath))
            {
                System.IO.File.Copy(filePath, songPath, true);
                newSong.Path = songPath;
            }
        }

        public static void DeleteSong(Song song)
        {
            try
            {
                //MessageBox.Show();
                System.IO.File.Delete(song.Path);

                if (song.ImagePath != null)
                {
                    System.IO.File.Delete(song.ImagePath);
                }
            }
            catch (Exception )
            {
                //MessageBox.Show("Error: Selected Song is currently playing! ");
            }
        }

        public static void SaveImage(string filePath, Song song)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Album_Images";
            song.ImagePath = folderPath + "\\" + song.Title + "_pic" + Path.GetExtension(filePath);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            System.IO.File.Copy(filePath, song.ImagePath, true);
            // MessageBox.Show("saved.");
            // song.ImagePath = imagePath;
        }

        public static void ReplaceImage(string newFile, Song song)
        {
            System.IO.File.Replace(newFile, song.ImagePath, null);
        }
    }

    /// <summary>
    /// utility class to read songs
    /// </summary>
    public class playlistReader : IDisposable
    {
        List<Song> _readSongs;
        /// <summary>
        /// Reads an xml file from the default directory.
        /// TODO: ADD TRY CATCH
        /// </summary>
        /// <param name="name">The name of the playlist</param>
        /// <returns>A List of songs</returns>
        public List<Song> ReadPlaylist(string name)
        {
            XmlSerializer deserializer = new XmlSerializer (typeof(List<Song>));
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MusicPA";

            using (FileStream fileStream = File.OpenRead(filepath + name + ".xml"))
            {
                _readSongs = (List<Song>)deserializer.Deserialize(fileStream);
                return _readSongs;
            }
        }
        /// <summary>
        /// Alternate method that allows you to provide a custom filepath.
        /// </summary>
        /// <param name="name">The name of the playlist</param>
        /// <param name="filepath">The folder containing the playlist xml</param>
        /// <returns></returns>
        public List<Song> ReadPlaylistFilepath(string filepath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Song>));


            using (FileStream fileStream = File.OpenRead(filepath))
            {
                _readSongs = (List<Song>)deserializer.Deserialize(fileStream);
                return _readSongs;
            }
            
        }

        public void Dispose()
        {
            _readSongs.Clear();
        }
    }
}
