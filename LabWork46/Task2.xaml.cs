using System.Windows;

namespace LabWork46
{
    /// <summary>
    /// Логика взаимодействия для Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();
        }
        Database.IDatabase SqlDatabase { get; } = new Database.SqlDatabase();
        Database.IDatabase SqliteDatabase { get; } = new Database.SqliteDatabase();
        private void SendSQLiteCommandButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object result = SqliteDatabase.ExecuteQuery(SQLiteCommandTextBox.Text);
                if (result is null)
                    result = "NULL";
                MessageBox.Show($"Количество измененных строк: {result.ToString()}",
                                "Результат", MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректная команда",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void SendMSSQLCommandButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object result = SqlDatabase.ExecuteQuery(MSSQLCommandTextBox.Text);
                if (result is null)
                    result = "NULL";
                MessageBox.Show($"Количество измененных строк: {result.ToString()}",
                                    "Результат",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректная команда или не удалось установить подключение",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}
