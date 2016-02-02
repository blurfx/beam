using Beam.Model;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Beam.View
{
    /// <summary>
    /// TweetPanel.xaml에 대한 상호 작용 논리
    /// </summary>
    
    public partial class TweetPanel : UserControl
    {
        object _tweet;
        public TweetPanel(object tweet)
        {
            _tweet = tweet;
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
                profile.ImageSource = img;
            }
        }
    }
}
