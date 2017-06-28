using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MusicPlayer.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SongPlayPage : Page
    {
        public static SongPlayPage Current;

        public Song currentSong;

        public SongPlayPage()
        {
            this.InitializeComponent();
            Current = this;
            this.SizeChanged += SongPlayPage_SizeChanged;
        }

        private void SongPlayPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.PlayerPostion.Width = e.NewSize.Width - 12;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.BttnPlay.Visibility = Visibility.Collapsed;
            this.MediaPlayer.PosterSource = await SongManager.GetDefaultThumbnailAsync();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if(element != null)
            {
                FlyoutBase.ShowAttachedFlyout(element);
            }
        }

        public void PlaySong(Song song = null)
        {
            if(song != null)
            {
                currentSong = song;
                PlaySongInternal(currentSong);
            }
            else
            {
                return;
            }
        }

        private void PlaySongInternal(Song song)
        {
            this.MediaPlayer.Source = new Uri(song.Path,UriKind.Absolute);
            if (song.Thumbnail == null)
            {
                this.MediaPlayer.PosterSource = new BitmapImage(new Uri("ms-appx:///MusicCollections/Thumbnails/NoThumbnail.PNG"));
            }
            else
            {
                this.MediaPlayer.PosterSource = song.Thumbnail;
            }
            this.BttnPlay.Visibility = Visibility.Visible;
            this.BttnStop.Visibility = Visibility.Collapsed;
            this.MediaPlayer.Play();
        }

        private void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            double songTimes = this.MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            this.PlayerPostion.Maximum = songTimes;
        }

        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (this.SwtchMediaRepeat.IsOn)
            {
                IList<Song> songs = MyMusicPage.Current.Songs;
                int index = songs.IndexOf(currentSong) + 1;
                if(index == songs.Count)
                {
                    index = 0;
                }
                currentSong = songs[index];
            }         
            PlaySongInternal(currentSong);            
        }

        private void BttnPlay_Click(object sender, RoutedEventArgs e)
        {

        }

     
    }
}
