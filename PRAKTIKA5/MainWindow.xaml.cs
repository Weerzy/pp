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
using PRAKTIKA5.praktikaDataSet1TableAdapters;

namespace PRAKTIKA5
{
    /// <summary>
    /// Логика взаимодействия для authorization.xaml
    /// </summary>
    public partial class authorization : Window
    {
        Входные_данныеTableAdapter входные_данные = new Входные_данныеTableAdapter();
        ПользовательTableAdapter пользователь = new ПользовательTableAdapter();
        public authorization()
        {
            InitializeComponent();
            /*tableDataGrid.ItemsSource = товар.GetData();*/
        }

        private void tableDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Boolean wrong = true;
            var logins = входные_данные.GetData().Rows;
            var users = пользователь.GetData().Rows;
            for(int i = 0; i < logins.Count; i++)
            {
                if (logins[i][1].ToString() == Login_TextBox.Text &&
                    logins[i][2].ToString() == Password_TextBox.Password)
                {
                    int id = (int)users[i][0];
                    object rights_id =   пользователь.GetDataByID(id).Rows[0][5];

                    switch (rights_id)
                    {
                        case 1:
                            AdminWindow AdminWindow = new AdminWindow();
                            AdminWindow.Show();
                            this.Close();
                            wrong = false;
                            MessageBox.Show("Это окно админа");
                            break;
                        case 2:
                            UserWindow UserWindow = new UserWindow();
                            UserWindow.Show();
                            this.Close();
                            wrong = false;
                            MessageBox.Show("Это окно пользователя");
                            break;
                    }
                }
            }
            if (wrong != false)
            {
                MessageBox.Show("Введен неправильный логин или пароль");
            }
        }
        private void Login_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Password_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Skip(object sender, RoutedEventArgs e)
        {
            AdminWindow AdminWindow = new AdminWindow();
            AdminWindow.Show();
            this.Close();
        }
    }
}
