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
    /// Interaction logic for ErrorView.xaml
    /// </summary>
    public partial class AlertBox : UserControl
    {
        public AlertBox()
        {
            InitializeComponent();
            Root.MouseDown  += delegate { Root.Background = new SolidColorBrush(Color.FromArgb(128,0,0,0)); };
            Root.MouseEnter += delegate { Root.Background = new SolidColorBrush(Color.FromArgb(50,0,0,0)); };
            Root.MouseLeave += delegate { Root.Background = new SolidColorBrush(Colors.Red); };
            Root.MouseUp    += delegate { this.Visibility = Visibility.Hidden; };
        }

        public void SetMessage(string Message)
        {
            tbMessage.Text = Message;
        }
    }
}
