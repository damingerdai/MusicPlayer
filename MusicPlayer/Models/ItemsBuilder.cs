using MusicPlayer.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public static class ItemsBuilder
    {
        private static IList<NavItem> _navItems = null;
        private static IList<NavItem> _footItems = null;
        public static IList<NavItem> BuildNavItems()
        {
            if(_navItems == null)
            {
                _navItems = new List<NavItem>()
                {
                    new NavItem(){ Icon = "\xE8D6",Title="我的音乐",View = typeof(MyMusicPage)},
                    new NavItem(){ Icon = "\xE121",Title="最近播放",View = null },
                    new NavItem(){ Icon = "\xE142",Title="正在播放",View = null },
                };
            }
            return _navItems;
        }

        public static IList<NavItem> BuildFootItems()
        {
            if(_footItems == null)
            {
                _footItems = new List<NavItem>()
                {
                    new NavItem(){ Icon = "\xE76E",Title="反馈",View = null},
                    new NavItem(){ Icon = "\xE713",Title="设置",View = null},                 
                };
            }
            return _footItems;
        }
    }
}
