using Beam.Helper;
using Beam.Model;
using System.Collections.Generic;
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

        Dictionary<long, TweetPanel> dict = new Dictionary<long, TweetPanel>();

        public TweetPanel InsertTweet(Tweet tweet)
        {
            if (tweet != null)
            {
                TweetPanel panel = new TweetPanel(tweet);
                lTweet.Items.Insert(0, panel);
                dict.Add(tweet.Id, panel);
                return panel;
            }
            return null;
        }

        public void RemoveTweet(long Id){
            if(dict.ContainsKey(Id))
                lTweet.Items.Remove(dict[Id]);
        }
    }
}
