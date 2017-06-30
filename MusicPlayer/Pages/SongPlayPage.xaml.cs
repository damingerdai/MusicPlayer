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
using Windows.UI.Popups;

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
            this.MediaPlayer.Width = e.NewSize.Width - 12;
            this.MediaPlayer.Height = this.MediaGrid.ActualHeight;
            System.Diagnostics.Debug.WriteLine("this.MediaGrid.ActualHeight : {0}", this.MediaGrid.ActualHeight);
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
                this.BttnPlay.Visibility = Visibility.Visible;
                this.BttnStop.Visibility = Visibility.Collapsed;
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
            this.MediaPlayer.Play();
        }

        private void PlaySongInternal()
        {
            if (IsSongSelected())
            {
                PlaySongInternal(currentSong);
            }
        }

        private void StopSongInternal()
        {
            this.MediaPlayer.Pause();
        }


        private void BttnPlay_Click(object sender, RoutedEventArgs e)
        {
            StopSongInternal();
            this.BttnPlay.Visibility = Visibility.Collapsed;
            this.BttnStop.Visibility = Visibility.Visible;

        }

        private void BttnStop_Click(object sender, RoutedEventArgs e)
        {
            if(IsSongSelected())
            {
                PlaySongInternal(currentSong);
                this.BttnPlay.Visibility = Visibility.Visible;
                this.BttnStop.Visibility = Visibility.Collapsed;
            }
            else
            {
                ShowErorAsync("请选择歌曲");
            }
        }

        private void BttnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (IsSongSelected())
            {
                GetPreviousSong();
                PlaySongInternal();
            }
        }

        private void BttnNext_Click(object sender, RoutedEventArgs e)
        {
            if (IsSongSelected())
            {
                GetNextSong();
                PlaySongInternal();
            }
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
                GetNextSong();
            }         
            PlaySongInternal(currentSong);            
        }

        private void GetNextSong()
        {
            IList<Song> songs = MyMusicPage.Current.Songs;
            int index = songs.IndexOf(currentSong) + 1;
            if (index == songs.Count)
            {
                index = 0;
            }
            currentSong = songs[index];
        }

        private void GetPreviousSong()
        {
            IList<Song> songs = MyMusicPage.Current.Songs;
            int index = songs.IndexOf(currentSong) - 1;
            if (index == -1)
            {
                index = songs.Count -1;
            }
            currentSong = songs[index];
        }


        private void SldrVolume_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            this.MediaPlayer.Volume = this.SldrVolume.Value / 100.0;
        }

        private async void ShowErorAsync(string message)
        {
            MessageDialog md = new MessageDialog(message);
            await md.ShowAsync();
        } 

        private bool IsSongSelected()
        {
            if(currentSong == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

     
    }
}
