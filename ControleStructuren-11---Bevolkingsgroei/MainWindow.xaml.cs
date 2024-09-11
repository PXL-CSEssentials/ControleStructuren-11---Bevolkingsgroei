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

namespace ControleStructuren_11___Bevolkingsgroei
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double population = double.Parse(currentPopulationTextBox.Text);
            double doublePopulation = 2.0 * population;
            int numberOfYears = 0;

            // 1,1% => groeiPercentage 1.1/100 = 0.011 + 1.0
            // 101,1% => 1.0 + (0.011 / 100.0)
            double growPercentage = double.Parse(growPercentageTextBox.Text);
            double growFactor = (1.0 + (growPercentage / 100.0));

            do
            {
                population *= growFactor;
                numberOfYears++;
            } while (population < doublePopulation);

            resultTextBox.Text = $"Verdubbeling bevolking in {countryTextBox.Text} na {numberOfYears} jaar\r\n\r\n" +
                $"Nieuw bevolkingsaantal op dat moment: {population:F3}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            countryTextBox.Clear();
            currentPopulationTextBox.Clear();
            growPercentageTextBox.Clear();
            resultTextBox.Clear();

            countryTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
