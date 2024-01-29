using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simple_Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cross_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void WindowDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void FieldText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(FieldText.Text);
        }

        private void FieldText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SecondText.Content = "Copied!";
        }
    }
}