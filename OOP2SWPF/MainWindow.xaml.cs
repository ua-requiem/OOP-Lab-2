using System;
using System.Globalization;
using System.Windows;

namespace OOP2SWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtX.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double x))
            {
                MessageBox.Show("Некоректне значення параметра x", "Помилка вводу", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!double.TryParse(txtY.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double y))
            {
                MessageBox.Show("Некоректне значення параметра y", "Помилка вводу", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!double.TryParse(txtZ.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double z))
            {
                MessageBox.Show("Некоректне значення параметра z", "Помилка вводу", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (x <= 0 || x + z == 0 || (y + Math.Cbrt(x - 1)) < 0)
            {
                MessageBox.Show("Значення параметрів виходять за межі ОДЗ!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double s = Math.Log10(x) * (Math.Pow(y + Math.Cbrt(x - 1), 0.25) / (2 * Math.Abs(x + z)));
            txtResult.Text = $"s = {Math.Round(s, 3):F3}";
        }
    }
}