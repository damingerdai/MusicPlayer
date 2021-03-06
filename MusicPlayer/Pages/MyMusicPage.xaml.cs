﻿using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MusicPlayer.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MyMusicPage : Page
    {
        private IList<Song> songs;

        public static MyMusicPage Current;

        public MyMusicPage()
        {
            this.InitializeComponent();
            Current = this;
        }

        public void UpdateMusicSelectedStatus(int index)
        {
            
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Loading.IsActive = true;
            songs = await SongManager.BuildSongsAsync();
            LstViewPlayList.ItemsSource = songs;
            this.Loading.IsActive = false;
        }

        private void LstViewPlayList_ItemClick(object sender, ItemClickEventArgs e)
        {
            SongPlayPage.Current.PlaySong(e.ClickedItem as Song);
        }

        public IList<Song> Songs
        {
            get
            {
                return songs;
            }
        }
    }
}
