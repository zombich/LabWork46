using System.Windows;

namespace LabWork46
{
    /// <summary>
    /// Логика взаимодействия для Task4.xaml
    /// </summary>
    public partial class Task4 : Window
    {
        public Task4()
        {
            InitializeComponent();
        }
        Database.IDatabase SqlDatabase { get; } = new Database.SqlDatabase();
        Database.IDatabase SqliteDatabase { get; } = new Database.SqliteDatabase();

        private void MSSQLInsertGameButton_Click(object sender, RoutedEventArgs e)
        {
            double price;
            if (!double.TryParse(PriceTextBox.Text, out price))
                return;
            int publicationYear;
            if (!int.TryParse(PublicationYearTextBox.Text, out publicationYear))
                return;

            try
            {
                SqlDatabase.InsertGame(TitleTextBox.Text, price, publicationYear);
            }
            catch
            {
                MessageBox.Show("Не удалось вставить данные",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void SQLiteInsertGameButton_Click(object sender, RoutedEventArgs e)
        {
            double price;
            if (!double.TryParse(PriceTextBox.Text, out price))
                return;
            int publicationYear;
            if (!int.TryParse(PublicationYearTextBox.Text, out publicationYear))
                return;

            try
            {
                SqliteDatabase.InsertGame(TitleTextBox.Text, price, publicationYear);
            }
            catch
            {
                MessageBox.Show("Не удалось вставить данные",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
