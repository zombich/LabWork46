using System.Windows;

namespace LabWork46
{
    /// <summary>
    /// Логика взаимодействия для Task3.xaml
    /// </summary>
    public partial class Task3 : Window
    {
        public Task3()
        {
            InitializeComponent();
        }
        Database.IDatabase SqlDatabase { get; } = new Database.SqlDatabase();
        Database.IDatabase SqliteDatabase { get; } = new Database.SqliteDatabase();

        private void UpdateGameMSSQLButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateGameSQLButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(IdTextBox.Text, out id))
                return;
            double price;
            if (!double.TryParse(PriceTextBox.Text, out price))
                return;
            var result = SqliteDatabase.UpdateGame(id, TitleTextBox.Text, price);

            if (result)
                MessageBox.Show("Изменено",
                                "Успех",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            else
                MessageBox.Show("Не удалось изменить",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
        }
    }
}
