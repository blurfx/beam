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
            Root.MouseLeave += delegate { Root.Background = null; };
            //Root.MouseUp    += delegate { Container. };
        }
        public enum MessageType { Success, Error, Warning };
        public void SetMessage(string Message, MessageType Type = MessageType.Success)
        {
            switch (Type)
            {
                default:
                case MessageType.Success:
                    this.Background = new SolidColorBrush(Colors.Green); 
                    tbMessage.Foreground = new SolidColorBrush(Colors.Black);
                    break;
                case MessageType.Error:
                    this.Background = new SolidColorBrush(Colors.Red);
                    break;
                case MessageType.Warning:
                    this.Background = new SolidColorBrush(Colors.Yellow);
                    tbMessage.Foreground = new SolidColorBrush(Colors.Black);
                    break;
                
            }
            tbMessage.Text = Message;
        }

    }
}
