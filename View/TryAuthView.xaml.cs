using Beam.Helper;
using Beam.Model;
using Beam.oAuth;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Beam.View
{
    /// <summary>
    /// Interaction logic for TryAuthView.xaml
    /// </summary>
    public partial class TryAuthView : UserControl
    {
        public TryAuthView()
        {
            InitializeComponent();
        }

        private async void btPinAuth_Click(object sender, RoutedEventArgs e)
        {
            BeamWindow beam = (BeamWindow)Application.Current.MainWindow;

            if (String.IsNullOrEmpty(Properties.Settings.Default.token) || String.IsNullOrEmpty(Properties.Settings.Default.tokenSec))
            {
                try
                {
                    beam.t.AccessTokenGet(beam.t.Token, tbPIN.Text);

                }
                catch
                {
                    MessageBox.Show("Wrong PIN Number!");
                    tbPIN.Text = String.Empty;
                    return;
                }
            }
            else
            {
                beam.t.Token = Properties.Settings.Default.token;
                beam.t.TokenSecret = Properties.Settings.Default.tokenSec;
            }
            beam.me = Json.Deserialize<User>(beam.t.oAuthWebRequest(Twitter.Method.GET, "https://api.twitter.com/1.1/account/verify_credentials.json", String.Empty));
            beam.rdMenu.Height = new GridLength(32);
            beam.ChangeView("timeline");
            await beam.startStream();
        }
    }
}
