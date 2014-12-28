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
using System.Windows.Shapes;
using Beam.oAuth;
using System.Web;
using System.Windows.Media.Animation;

namespace Beam
{
    /// <summary>
    /// Interaction logic for BeamWindow.xaml
    /// </summary>
    public partial class BeamWindow : Window
    {
        Twitter t = new Twitter();
        oAuth.oAuth oAuth = new oAuth.oAuth();
        public BeamWindow()
        {
            InitializeComponent();
            tbSlideBack.MouseDown += delegate { slideGrid(2); btSignIn.IsEnabled = true; tbPIN.Text = String.Empty; };
            tbSlideBack.TouchDown += delegate { slideGrid(2); btSignIn.IsEnabled = true; tbPIN.Text = String.Empty; };
        }

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            slideGrid(1);
            Uri uri = new Uri(t.AuthorizationLinkGet());
            System.Diagnostics.Process.Start(uri.ToString());
            t.Token = HttpUtility.ParseQueryString(uri.Query)["oauth_token"];
            btSignIn.IsEnabled = false;
            
        }


        private void btPinAuth_Click(object sender, RoutedEventArgs e)
        {
            try{
                t.AccessTokenGet(t.Token, tbPIN.Text);
                
            }
            catch{
                MessageBox.Show("Wrong PIN Number!");
                tbPIN.Text = String.Empty;
                slideGrid(2);
                btSignIn.IsEnabled = true;
                return;
            }
            Console.WriteLine(t.oAuthWebRequest(Twitter.Method.GET, "https://api.twitter.com/1.1/account/verify_credentials.json", String.Empty));
            loginSuccess();
            //Console.WriteLine(t.oAuthWebRequest(Twitter.Method.POST, "https://api.twitter.com/1.1/statuses/update.json", "status=" + oAuth.UrlEncode("뿅!")));
        }

        private void slideGrid(int direction)
        {
            ThicknessAnimation da;
            ThicknessAnimation da2;
            //1 Left, 2 Right
            switch (direction)
            {
                case 1:
                    da = new ThicknessAnimation(new Thickness(0), new Duration(TimeSpan.FromMilliseconds(200)));
                    da2 = new ThicknessAnimation(new Thickness(-295, 0, 0, 0), new Duration(TimeSpan.FromMilliseconds(200)));
                    break;
                case 2:
                default:
                    da = new ThicknessAnimation(new Thickness(295, 0, 0, 0), new Duration(TimeSpan.FromMilliseconds(200)));
                    da2 = new ThicknessAnimation(new Thickness(0), new Duration(TimeSpan.FromMilliseconds(200)));
                    break;
            }

            grdSignIn.BeginAnimation(MarginProperty, da2);
            grdPIN.BeginAnimation(MarginProperty, da);
        }

        private void loginSuccess()
        {
            ResizeMode = ResizeMode.CanResize;
            Width = 500;
            Height = 700;

        }

        private void Window_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            Console.WriteLine(this.Width + "x" + this.Height);
        }

    }
}
