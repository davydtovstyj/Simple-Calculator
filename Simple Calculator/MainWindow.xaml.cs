using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Simple_Calculator
{
    public partial class MainWindow : Window
    {
        decimal num1;
        string act = "";
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

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (FieldText.Text == "0")
                FieldText.Text = btn.Content.ToString();
            else if (FieldText.Text.Length < 14)
                FieldText.Text += btn.Content;
        }

        private void NegativeClick(object sender, RoutedEventArgs e)
        {
            FieldText.Text = Convert.ToString(Convert.ToDecimal(FieldText.Text) * -1);
        }

        private void CommaClick(object sender, RoutedEventArgs e)
        {
            if (!FieldText.Text.Contains(','))
                FieldText.Text += ",";
        }

        private void FactorialClick(object sender, RoutedEventArgs e)
        {
            if (FieldText.Text.Contains(','))
                return;
            if (Convert.ToInt32(FieldText.Text) <= 16 && Convert.ToInt32(FieldText.Text) >= 0)
                FieldText.Text = Factorial(Convert.ToInt32(FieldText.Text)).ToString();
        }

        private void RootClick(object sender, RoutedEventArgs e)
        {
            if(Convert.ToDecimal(FieldText.Text) >= 0)
                FieldText.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(FieldText.Text)));
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            if (FieldText.Text.Length > 1)
                FieldText.Text = FieldText.Text.Remove(FieldText.Text.Length - 1, 1);
            else
                FieldText.Text = "0";
        }

        private void CEClick(object sender, RoutedEventArgs e)
        {
            FieldText.Text = "0";
        }

        private void CClick(object sender, RoutedEventArgs e)
        {
            FieldText.Text = "0";
            SecondText.Content = string.Empty;
        }

        private void EqualsClick(object sender, RoutedEventArgs e)
        {
            switch (act)
            {
                case "+":
                    FieldText.Text = Convert.ToDecimal(num1 + Convert.ToDecimal(FieldText.Text)).ToString();
                    break;
                case "-":
                    FieldText.Text = Convert.ToDecimal(num1 - Convert.ToDecimal(FieldText.Text)).ToString();
                    break;
                case "×":
                    FieldText.Text = Convert.ToDecimal(num1 * Convert.ToDecimal(FieldText.Text)).ToString();
                    break;
                case "÷":
                    if (Convert.ToDecimal(FieldText.Text) != 0)
                        FieldText.Text = Convert.ToDecimal(num1 / Convert.ToDecimal(FieldText.Text)).ToString();
                    break;
                case "^":
                    FieldText.Text = Math.Pow((double)num1, Convert.ToDouble(FieldText.Text)).ToString();
                    break;
                case "%":
                    FieldText.Text = (Convert.ToDecimal(FieldText.Text) * (num1/100)).ToString();
                    break;
            }
            SecondText.Content = string.Empty;
            num1 = 0;
        }

        private void ActionButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            num1 = Convert.ToDecimal(FieldText.Text);
            act = btn.Content.ToString();
            SecondText.Content = num1 + " " + act;
            FieldText.Text = "0";
        }

        private long Factorial(long num)
        {
            if (num == 0)
                return 1;
            else
                return num * Factorial(num - 1);
        }
    }
}