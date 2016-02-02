using Beam.Helper;
using Beam.Model;
using System.Windows.Controls;

namespace Beam.View
{
    /// <summary>
    /// Interaction logic for TimelineView.xaml
    /// </summary>
    public partial class TimelineView : UserControl
    {
        public TimelineView()
        {
            InitializeComponent();
        }

        public void InsertTweet(Tweet tweet)
        {
            if (tweet != null)
            {
                TweetPanel container = new TweetPanel(tweet);
            }
        }
    }
}
