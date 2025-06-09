using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
using System.Windows.Shapes;

namespace LabWork46
{
    /// <summary>
    /// Логика взаимодействия для Task1.xaml
    /// </summary>
    public partial class Task1 : Window
    {
        public Task1()
        {
            InitializeComponent();
        }
        Database.IDatabase _database { get; } = new Database.SqliteDatabase("db.sqlite");
        Database.IDatabase _database2 { get; } = new Database.SqlDatabase("sql","db","login","pass");
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
        }
    }
}
