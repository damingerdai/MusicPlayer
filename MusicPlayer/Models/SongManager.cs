using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MusicPlayer.Models
{
    public static class SongManager
    {
        private static IList<Song> _songs;
        private static BitmapImage _thumbnail;

        public static async Task<IList<Song>> BuildSongsAsync()
        {
            if(_songs == null || _songs.Count <= 0)
            {
                _songs = new List<Song>();
                StorageFolder localFolder = Package.Current.InstalledLocation;
                StorageFolder musicFolder = await localFolder.GetFolderAsync("MusicCollections");
                foreach(StorageFile file in await musicFolder.GetFilesAsync())
                {
                    _songs.Add(await InitSongAsync(file));
                }
            }          
            return _songs;
        }

        public static async Task<BitmapImage> GetDefaultThumbnailAsync()
        {
            if(_thumbnail == null)
            {
                _thumbnail = new BitmapImage();
                StorageFolder localFolder = Package.Current.InstalledLocation;
                StorageFolder musicFolder = await localFolder.GetFolderAsync("MusicCollections");
                StorageFolder thumbnailFolder = await musicFolder.GetFolderAsync("Thumbnails");
                StorageFile thumbnailFile = await thumbnailFolder.GetFileAsync("NoThumbnail.PNG");
                _thumbnail.UriSource = new Uri(thumbnailFile.Path, UriKind.Absolute);
            }
            return _thumbnail;
        }

        private static async Task<Song> InitSongAsync(StorageFile songFile)
        {
            Song song = new Song();
            song.Name = songFile.DisplayName;
            song.Path = songFile.Path;
            MusicProperties musicProperties = await songFile.Properties.GetMusicPropertiesAsync();
            song.Title = musicProperties.Title;
            song.Ablum = musicProperties.Album;
            song.Artists = musicProperties.Artist;          
            return song;
        }
    }
}
