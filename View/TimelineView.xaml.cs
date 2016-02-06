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
                if (lTweet.Items.Count != 0)
                    lTweet.Items.Insert(0, new Separator());
                lTweet.Items.Insert(0, new TweetPanel(tweet));
                
            }
        }
    }
}
