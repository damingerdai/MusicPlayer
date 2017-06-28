using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MusicPlayer.Models
{
    /// <summary>
    /// mp3歌曲
    /// </summary>
    public class Song
    {
        /// <summary>
        /// 歌曲名
        /// </summary>
        private string _name;

        /// <summary>
        /// 标题
        /// </summary>
        private string _title;

        /// <summary>
        /// 参与创作的艺术家
        /// </summary>
        private string _artists;

        /// <summary>
        /// 唱片集
        /// </summary>
        private string _ablum;

        /// <summary>
        /// 封面
        /// </summary>
        private BitmapImage _thumbnail;

        /// <summary>
        /// 路径
        /// </summary>
        private string _path;

        private const string _thumbnailPath = "ms-appx:///MusicCollections/Thumbnails/NoThumbnail.PNG";

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_title))
                {
                    if (string.IsNullOrEmpty(_name))
                    {
                        return "无名音乐";
                    }
                    else
                    {
                        return _name;
                    }
                }
                else
                {
                    return _title;
                }              
            }
            set
            {
                _title = value;
            }
        }
        public string Artists
        {
            get
            {
                return _artists;
            }
            set
            {
                _artists = value;
            }
        }
        public string Ablum
        {
            get
            {
                return _ablum;
            }
            set
            {
                _ablum = value;
            }
        }
        public BitmapImage Thumbnail
        {
            get
            {
                if (_thumbnail == null)
                {
                    return new BitmapImage(new Uri(_thumbnailPath));
                }
                else
                {
                    return _thumbnail;
                }
            }
            set
            {
                _thumbnail = value;
            }
        }
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is Song)
            {
                Song song = obj as Song;
                return this._name.Equals(song._name) && this._title.Equals(song._title);
            }
            else
            {
                return false;
            }          
        }
    }
}
