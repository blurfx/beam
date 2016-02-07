using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Web;
using System.Web.Script.Serialization;
using Beam.oAuth;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text;
using System.Collections.Generic;
using Beam.Helper;
using Beam.View;
using System.Windows.Threading;
using Beam.Model;
using System.Runtime.Serialization.Json;
namespace Beam
{
    /// <summary>
    /// Interaction logic for BeamWindow.xaml
    /// </summary>
    /// 
    public partial class BeamWindow : Window
    {

        public Twitter t = new Twitter();
        public User me = new User();
        string _currentView = null;


        Dictionary<String, UserControl> viewDict = new Dictionary<string, UserControl>();

        public BeamWindow()
        {
            InitializeComponent();

            viewDict.Add("init", new InitAuthView());
            viewDict.Add("auth", new TryAuthView());
            viewDict.Add("timeline", new TimelineView());
            viewDict.Add("connect", new ConnectView());
            viewDict.Add("message", new MessageView());

            ChangeView("init");
            
            if (!String.IsNullOrEmpty(Properties.Settings.Default.token) || !String.IsNullOrEmpty(Properties.Settings.Default.tokenSec))
            {
                t.Token = Properties.Settings.Default.token;
                t.TokenSecret = Properties.Settings.Default.tokenSec;

                ChangeView("timeline");
                try
                {
                    me = Json.Deserialize<User>(t.oAuthWebRequest(Twitter.Method.GET, "https://api.twitter.com/1.1/account/verify_credentials.json", String.Empty));
                } catch {
                    showAlert("Unable to connect to Twitter",AlertBox.MessageType.Error);
                }


                rdMenu.Height = new GridLength(32);
                Task.Run(async () => await startStream());
            }
            
            btTimeline.Click += delegate { ChangeView("timeline"); };
            btConnect.Click += delegate { ChangeView("connect"); };
            btMessage.Click += delegate { ChangeView("message"); };
        }

        public async Task startStream()
        {
            await t.singleUserStream(delegate (){
                CurrentDispatcher.BeginInvoke((Action)(() =>
                {
                    showAlert("Connected to userstream");
                }));
            },
            delegate (string json){
                CurrentDispatcher.BeginInvoke((Action)(() => {
                    json = System.Net.WebUtility.HtmlDecode(json);
                    Extension.TweetType type = Extension.checkTweetType(json);
                    if (type != Extension.TweetType.Init)
                    {
                        switch (type)
                        {
                            case Extension.TweetType.Normal:
                                Tweet tweet = Json.Deserialize<Tweet>(json);
                                ((TimelineView)viewDict["timeline"]).InsertTweet(tweet);

                                if(tweet.Entities.Mentions.Count != 0)
                                {
                                    bool _Mentioned = false;
                                    foreach (Mention m in tweet.Entities.Mentions)
                                        if (m.Id == me.Id) _Mentioned = true;
                                    if (tweet.Text.ToLower().Contains("@" + me.ScreenName.ToLower())) _Mentioned = true;
                                    if(_Mentioned) ((ConnectView)viewDict["connect"]).InsertTweet(tweet);
                                }
                                
                                break;

                            case Extension.TweetType.Message:
                                Message message = Json.Deserialize<MessageWrapper>(json).Message;
                                break;

                            case Extension.TweetType.Delete:
                                DeletedStatus status = Json.Deserialize<DeleteWrapper>(json).Delete.Status;
                                ((TimelineView)viewDict["timeline"]).RemoveTweet(status.Id);
                                break;
                        }
                        
                    }
                }));
            }, delegate (){
                CurrentDispatcher.BeginInvoke((Action)(() =>
                {
                    showAlert("Unable to connect to userstream",AlertBox.MessageType.Error);
                }));
            });
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

        public void ChangeView(string viewKey)
        {
            if (viewKey != _currentView && viewDict.ContainsKey(viewKey))
            {
                ContentWrapper.Content = viewDict[viewKey];
                pTimeline.Fill = pConnect.Fill = pMessage.Fill = new SolidColorBrush(Color.FromRgb(204, 214, 221));
                switch (viewKey)
                {
                    case "init":
                    case "auth":
                        rdMenu.Height = new GridLength(0);
                        return;
                    case "timeline":
                        pTimeline.Fill = new SolidColorBrush(Color.FromRgb(85, 172, 238));
                        return;
                    case "connect":
                        pConnect.Fill = new SolidColorBrush(Color.FromRgb(85, 172, 238));
                        return;
                    case "message":
                        pMessage.Fill = new SolidColorBrush(Color.FromRgb(85, 172, 238));
                        return;
                }
                
            }

        }

        Dispatcher CurrentDispatcher
        {
            get
            {
                if (Application.Current != null)
                    return Application.Current.Dispatcher;
                else
                    return Dispatcher.CurrentDispatcher;
            }
        }

        public void showAlert(string message, AlertBox.MessageType type = AlertBox.MessageType.Success)
        {
            AlertBox alertBox = new AlertBox();
            DispatcherTimer alertTimeout = new DispatcherTimer();
            alertBox.SetMessage(message,type);
            alertTimeout.Interval = TimeSpan.FromSeconds(5);
            alertTimeout.Tick += delegate { alertTimeout.Stop(); AlertStack.Children.Remove(alertBox); alertBox = null; alertTimeout = null; };
            alertBox.MouseUp += delegate { alertTimeout.Stop(); AlertStack.Children.Remove(alertBox); alertBox = null; alertTimeout = null; };
            AlertStack.Children.Add(alertBox);
            alertTimeout.Start();

        }
    }
}
