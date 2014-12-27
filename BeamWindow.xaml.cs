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
        string token;
        public BeamWindow()
        {
            InitializeComponent();
            tbSlideBack.MouseDown += delegate { slideGrid(2); };
            tbSlideBack.TouchDown += delegate { slideGrid(2); };
        }

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            slideGrid(1);
            return;
            Uri uri = new Uri(t.AuthorizationLinkGet());
            System.Diagnostics.Process.Start(uri.ToString());
            token = HttpUtility.ParseQueryString(uri.Query)["oauth_token"];
            
            this.IsEnabled = false;
            
        }

        private void slideGrid(int direction)
        {
            ThicknessAnimation da;
            ThicknessAnimation da2;
            //1 Left, 2 Right
            switch (direction)
            {
                case 1:
                    da = new ThicknessAnimation(new Thickness(0),new Duration(TimeSpan.FromMilliseconds(200)));
                    da2 = new ThicknessAnimation(new Thickness(-295,0,0,0), new Duration(TimeSpan.FromMilliseconds(200)));
                    break;
                case 2:
                default:
                    da = new ThicknessAnimation(new Thickness(295,0,0,0), new Duration(TimeSpan.FromMilliseconds(200)));
                    da2 = new ThicknessAnimation(new Thickness(0), new Duration(TimeSpan.FromMilliseconds(200)));
                    break;
            }
         
            grdSignIn.BeginAnimation(MarginProperty, da2);
            grdPIN.BeginAnimation(MarginProperty, da);
        }
    }
}
