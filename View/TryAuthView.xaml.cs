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
            BeamWindow beam = (BeamWindow)this.Parent;

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
                //Console.WriteLine(t.oAuthWebRequest(Twitter.Method.GET, "https://api.twitter.com/1.1/account/verify_credentials.json", String.Empty));
            }
            else
            {
                beam.t.Token = Properties.Settings.Default.token;
                beam.t.TokenSecret = Properties.Settings.Default.tokenSec;
            }

            beam.ChangeView("timeline");
            await beam.startStream();
        }
    }
}
