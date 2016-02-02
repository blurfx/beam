using Beam.oAuth;
using System;
using System.Web;
using System.Windows;
using System.Windows.Controls;

namespace Beam.View
{
    /// <summary>
    /// Interaction logic for InitAuthView.xaml
    /// </summary>
    public partial class InitAuthView : UserControl
    {
        public InitAuthView()
        {
            InitializeComponent();
        }

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            BeamWindow beam = (BeamWindow)Application.Current.MainWindow;
            beam.t = new Twitter();
            Uri uri = new Uri(beam.t.AuthorizationLinkGet());
            System.Diagnostics.Process.Start(uri.ToString());
            beam.t.Token = HttpUtility.ParseQueryString(uri.Query)["oauth_token"];
            
        }

    }
}
