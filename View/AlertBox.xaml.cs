using System.Windows.Controls;
using System.Windows.Media;

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
            //Root.MouseUp    += delegate { Container. };
        }

        public void SetMessage(string Message)
        {
            tbMessage.Text = Message;
        }
    }
}
