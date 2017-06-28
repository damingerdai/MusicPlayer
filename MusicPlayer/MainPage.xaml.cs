using MusicPlayer.Models;
using MusicPlayer.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace MusicPlayer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {         
            this.NavContorl.ItemsSource = ItemsBuilder.BuildNavItems();
            this.FootContorl.ItemsSource = ItemsBuilder.BuildFootItems();
            this.MasterFrame.Navigate(typeof(MyMusicPage));
            this.MusicPlayerFrame.Navigate(typeof(SongPlayPage));
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.MasterSplitView.IsPaneOpen = !this.MasterSplitView.IsPaneOpen;
        }

        private void NavContorl_ItemClick(object sender, ItemClickEventArgs e)
        {
            NavItem item = e.ClickedItem as NavItem;
            if(item.View != null)
            {
                this.MasterFrame.Navigate(item.View, item.Title);
            }  
        }

        private void FootContorl_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
