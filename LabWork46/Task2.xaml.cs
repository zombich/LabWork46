using System.Windows;

namespace LabWork46
{
    /// <summary>
    /// Логика взаимодействия для Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {        
        Database.IDatabase SqlDatabase { get; } = new Database.SqlDatabase();
        Database.IDatabase SqliteDatabase { get; } = new Database.SqliteDatabase();

        public Task2()
        {
            InitializeComponent();
        }
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
            catch
            {
                MessageBox.Show("Некорректная команда или не удалось установить подключение",
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
                MessageBox.Show($"Количество измененных строк: {result}",
                                    "Результат",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Некорректная команда или не удалось установить подключение",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}
