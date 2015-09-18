using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Web;
using System.Windows.Media.Animation;
using System.Web.Script.Serialization;
using Beam.oAuth;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text;
using System.Collections.Generic;
using Beam.Helper;

namespace Beam
{
    /// <summary>
    /// Interaction logic for BeamWindow.xaml
    /// </summary>
    /// 
    public partial class BeamWindow : Window
    {
        enum JsonType { Init, Normal, Delete, Message }

        Twitter t = new Twitter();
        oAuth.oAuth oAuth = new oAuth.oAuth();
        public BeamWindow()
        {
            InitializeComponent();
        }

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(t.AuthorizationLinkGet());
            System.Diagnostics.Process.Start(uri.ToString());
            t.Token = HttpUtility.ParseQueryString(uri.Query)["oauth_token"];
            btSignIn.IsEnabled = false;
            grdSignIn.Visibility = Visibility.Collapsed;
            grdPIN.Visibility = Visibility.Visible;
        }


        private async void btPinAuth_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.token) || String.IsNullOrEmpty(Properties.Settings.Default.tokenSec))
            {
                try
                {
                    t.AccessTokenGet(t.Token, tbPIN.Text);

                }
                catch
                {
                    MessageBox.Show("Wrong PIN Number!");
                    tbPIN.Text = String.Empty;
                    btSignIn.IsEnabled = true;
                    grdSignIn.Visibility = Visibility.Visible;
                    grdPIN.Visibility = Visibility.Collapsed;
                    return;
                }
                Console.WriteLine(t.oAuthWebRequest(Twitter.Method.GET, "https://api.twitter.com/1.1/account/verify_credentials.json", String.Empty));
            }
            else
            {
                t.Token = Properties.Settings.Default.token;
                t.TokenSecret = Properties.Settings.Default.tokenSec;
            }
            loginSuccess();//Console.WriteLine(t.oAuthWebRequest(Twitter.Method.POST, "https://api.twitter.com/1.1/statuses/update.json", "status=" + oAuth.UrlEncode("뿅!")));
           await startStream();
        }

        private void loginSuccess()
        {
            grdSignIn.Visibility = Visibility.Hidden;
            grdPIN.Visibility = Visibility.Hidden;
            grdMother.Visibility = Visibility.Visible;
        }

        private void Window_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            Console.WriteLine(this.Width + "x" + this.Height);
        }

        protected async Task startStream()
        {
            await t.singleUserStream("https://userstream.twitter.com/1.1/user.json");
        }

        public async Task addTweet(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            dynamic tweet = jss.Deserialize<dynamic>(System.Net.WebUtility.HtmlDecode(json));
            JsonType type = checkTweetType(tweet);          
            TweetPanel panel = new TweetPanel();
            switch(type){

                case JsonType.Normal:
                    panel.ID = (long)tweet["id"];
                    panel.Username = String.Format("{0}/{1}", tweet["user"]["screen_name"], tweet["user"]["name"]);
                    panel.Text = tweet["text"];
                    panel.ProfileImage = tweet["user"]["profile_image_url_https"];
                    panel.TimestampWithClient = String.Format("{0} / via {1}",Extension.ParseDatetime(tweet["created_at"]),Extension.ParseClientSource(tweet["source"]));

                    listTweet.Items.Insert(0, panel);
                    break;
                case JsonType.Message:
                    panel.ID = (long)tweet["direct_message"]["id"];
                    panel.Username = String.Format("{0}/{1}", tweet["user"]["screen_name"], tweet["user"]["name"]);
                    panel.Text = tweet["direct_message"]["text"];
                    panel.ProfileImage = tweet["direct_message"]["sender"]["profile_image_url_https"];
                    panel.TimestampWithClient = String.Format("{0}", Extension.ParseDatetime(tweet["direct_message"]["created_at"]));
                    //listDM.Items.Insert(0, panel);
                    break;
            }
        }

        private JsonType checkTweetType(dynamic json)
        {
            List<Action> checkType = new List<Action>();
            JsonType type = JsonType.Init;

            checkType.Add(() =>
            {
                if (json["direct_message"]["id"] != null)
                {
                    type = JsonType.Message;

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
                    type = JsonType.Normal;
                }
            });

            foreach (Action a in checkType)
            {
                try { a(); break; }
                catch { }
            }

            return type;
        }

        private void beamTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                resetTabHeaderImage();

            }
        }

        private void resetTabHeaderImage()
        {
            //Image[] on_img = { twitter_on, mention_on, message_on };
            //Image[] off_img = { twitter_off, mention_off, message_off };
            //int i = 0;
            //for (; i < on_img.Length; i++)
            {
            //    on_img[i].Visibility = Visibility.Collapsed;
                //off_img[i].Visibility = Visibility.Visible;
            }
        }
        /*
        private void tbTweet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                int carIndex = tbTweet.CaretIndex+1;
                tbTweet.Text = tbTweet.Text.Insert(tbTweet.CaretIndex, "\n");
                tbTweet.Select(carIndex, 0);
                return;
            }
            if (e.Key == Key.Enter && !String.IsNullOrWhiteSpace(tbTweet.Text))
            {
                t.oAuthWebRequest(Twitter.Method.POST, "https://api.twitter.com/1.1/statuses/update.json", "status=" + oAuth.UrlEncode(tbTweet.Text));
                tbTweet.Text = null;
            }
        }
        */

    }
}
