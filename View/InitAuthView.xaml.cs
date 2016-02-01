using Beam.oAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
            BeamWindow beam = (BeamWindow)this.Parent;
            beam.t = new Twitter();
            Uri uri = new Uri(beam.t.AuthorizationLinkGet());
            System.Diagnostics.Process.Start(uri.ToString());
            beam.t.Token = HttpUtility.ParseQueryString(uri.Query)["oauth_token"];
            
        }

    }
}
