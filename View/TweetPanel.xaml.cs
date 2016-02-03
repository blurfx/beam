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
        Tweet _tweet;
        public TweetPanel(object tweet)
        {
            _tweet = (Tweet)tweet;
            DataContext = _tweet;
            InitializeComponent();
        }
        

        public string Username
        {
            get { return user.Text; }
            set { user.Text = value; }
        }

    }
}
