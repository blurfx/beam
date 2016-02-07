using Beam.Model;
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

namespace Beam.View
{
    /// <summary>
    /// ConnectView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ConnectView : UserControl
    {
        public ConnectView()
        {
            InitializeComponent();
        }
        public TweetPanel InsertTweet(Tweet tweet)
        {
            if (tweet != null){
                TweetPanel panel = new TweetPanel(tweet);
                lConnect.Items.Insert(0, panel);
                return panel;
            }
            return null;
        }
    }
}
