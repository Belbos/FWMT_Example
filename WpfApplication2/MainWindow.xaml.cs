using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

namespace WpfApplication2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = DataSelect(textBox.Text);
        }

        public string DataSelect(string str)
        {
            String resual = "";

            SQLiteDataReader sqliteDataReader = null;

            try
            {

                SQLiteConnection sqliteConnection = DataAccess.SqlConnection();             

                string sql = "SELECT * FROM tmptable where id = @id";
                SQLiteCommand sqliteCommand = new SQLiteCommand(sql, sqliteConnection);

                sqliteCommand.CommandType = CommandType.Text;
                sqliteCommand.Parameters.AddWithValue("@id", str); 
                      
           
                sqliteDataReader = sqliteCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (sqliteDataReader.Read())
                {
                    resual = sqliteDataReader["test"].ToString();
                }
            }
            finally
            {
                sqliteDataReader.Close();
            }

            return resual;
        }
    }
}
