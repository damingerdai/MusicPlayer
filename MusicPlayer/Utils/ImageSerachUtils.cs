using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MusicPlayer.Utils
{
    public static class ImageSerachUtils
    {
        /*
        public static List<BitmapImage> GetLogo(string str)
        {
            string strAPI = "http://image.so.com/i?q=" + EncodeUtils.UrlEncode(str) + "&src=srp";

            Uri url = new Uri(strAPI);
            HttpWebRequest MyWebClient = new HttpWebRequest();
            MyWebClient.Encoding = Encoding.UTF8;
            string Web = MyWebClient.DownloadString(url);
            MyWebClient.Dispose();mbox.kjl
            //网页源代码 包含所以的图片
            List<Image> img = new List<Image>();
            int id = 0;
            if (Web.Length >= 500)
            {
                var matches = Regex.Matches(Web, @"{""id"":[\s\S]*?}", RegexOptions.RightToLeft);
                foreach (Match mc in matches)
                {
                    try
                    {
                        string allText = mc.Groups[0].Value;


                        string[] allkey = allText.Split('"');
                        if (Convert.ToInt32(allkey[21]) > 100)//width
                        {
                            if (Convert.ToInt32(allkey[25]) > 100)
                            {
                                if (Convert.ToInt32(allkey[21]) >= Convert.ToInt32(allkey[25]) * 0.2)
                                {
                                    //下载图片
                                    string uu = allkey[51].Replace(@"\", "");
                                    Uri picurl = new Uri(uu);
                                    WebClient my = new WebClient();
                                    Stream io = my.OpenRead(picurl);
                                    Image im = Image.FromStream(io);
                                    my.Dispose();
                                    img.Add(im);
                                    if (id + 1 == 5)
                                    {
                                        return img;
                                    }
                                }
                            }
                        }

                    }
                    catch (Exception)
                    {



                    }

                }




            }



            //分析图片的大小







            return img;

        }
        */

    }
}
