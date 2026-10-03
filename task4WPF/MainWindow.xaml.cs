using System;
using System.Globalization;
using System.Windows;

namespace task4WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            lblD.Visibility = Visibility.Collapsed;
            lblMessage.Visibility = Visibility.Collapsed;
            panelX1.Visibility = Visibility.Collapsed;
            panelX2.Visibility = Visibility.Collapsed;

            if (!double.TryParse(txtA.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double a) ||
                !double.TryParse(txtB.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double b) ||
                !double.TryParse(txtC.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double c))
            {
                MessageBox.Show("Помилка введення значень!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (a == 0)
            {
                MessageBox.Show("Коефіцієнт 'a' не може дорівнювати 0!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double d = b * b - 4 * a * c;
            lblD.Text = $"Дискримінант D = {Math.Round(d, 3)}";
            lblD.Visibility = Visibility.Visible;

            if (d < 0)
            {
                lblMessage.Text = "Дійсних розв'язків немає (D < 0)";
                lblMessage.Visibility = Visibility.Visible;
            }
            else if (d == 0)
            {
                double x = -b / (2 * a);
                txtX1.Text = Math.Round(x, 3).ToString();
                lblX1Name.Text = "x = ";
                panelX1.Visibility = Visibility.Visible;
            }
            else
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                txtX1.Text = Math.Round(x1, 3).ToString();
                txtX2.Text = Math.Round(x2, 3).ToString();
                lblX1Name.Text = "x1 = ";
                panelX1.Visibility = Visibility.Visible;
                panelX2.Visibility = Visibility.Visible;
            }
        }
    }
}