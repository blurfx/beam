using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beam
{
    /// <summary>
    /// TweetPanel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TweetPanel : UserControl
    {
        public TweetPanel()
        {
            InitializeComponent();
        }

        public string Username
        {
            get { return user.Text; }
            set { user.Text = value; }
        }

        public string ProfileImage
        {
            set {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(value);
                img.EndInit();
                profile.Source = img;
            }
        }

        public string Text
        {
            get { return tweet.Text; }
            set { tweet.Text = value; }
        }

        public string TimestampWithClient
        {
            set { tc.Text = value; }
        }
    }
}
