using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Beam.Helper
{
    public static class Extension
    {
        const string format = "ddd MMM dd HH:mm:ss zzzz yyyy";

        public enum TweetType { Init, Normal, Delete, Message }

        public static string ParseDatetime(this string date)
        {
            return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture).ToString("yyyy년 MM월 dd일 hh:mm:ss");
        }

        public static string ParseClientSource(this string source)
        {
            Regex r = new Regex("<a.*>(.*)</a>");
            Match m = r.Match(source);
            return m.Groups[1].ToString();
        }

        public static readonly DependencyProperty NormalImageProperty =
    DependencyProperty.RegisterAttached("NormalImage", typeof(string), typeof(Extension), new PropertyMetadata(default(string)));

        public static void SetNormalImage(UIElement element, string value)
        {
            element.SetValue(NormalImageProperty, value);
        }

        public static string GetNormalImage(UIElement element)
        {
            return (string)element.GetValue(NormalImageProperty);
        }

        public static readonly DependencyProperty HoverImageProperty =
DependencyProperty.RegisterAttached("HoverImage", typeof(string), typeof(Extension), new PropertyMetadata(default(string)));

        public static void SetHoverImage(UIElement element, string value)
        {
            element.SetValue(HoverImageProperty, value);
        }

        public static string GetHoverImage(UIElement element)
        {
            return (string)element.GetValue(HoverImageProperty);
        }

        public static TweetType checkTweetType(dynamic json)
        {
            List<Action> checkType = new List<Action>();
            TweetType type = TweetType.Init;

            checkType.Add(() =>
            {
                if (json["direct_message"]["id"] != null)
                {
                    type = TweetType.Message;

                }
            });
            /*
            checkType.Add(() => {
                if (tweet["delete"])
                {
                    
                }
            });
            */
            checkType.Add(() =>
            {
                if (json["text"] != null)
                {
                    type = TweetType.Normal;
                }
            });

            foreach (Action a in checkType)
            {
                try { a(); break; }
                catch { }
            }

            return type;
        }
    }
}
