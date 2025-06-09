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

namespace LabWork46
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
        private void Task1Button_Click(object sender, RoutedEventArgs e)
        {
            Task1 task = new();
            Hide();
            task.ShowDialog();
            Show();
        }

        private void Task2Button_Click(object sender, RoutedEventArgs e)
        {
            Task2 task = new();
            Hide();
            task.ShowDialog();
            Show();
        }

        private void Task3Button_Click(object sender, RoutedEventArgs e)
        {
            Task3 task = new();
            Hide();
            task.ShowDialog();
            Show();
        }

        private void Task4Button_Click(object sender, RoutedEventArgs e)
        {
            Task4 task = new();
            Hide();
            task.ShowDialog();
            Show();
        }
    }
}