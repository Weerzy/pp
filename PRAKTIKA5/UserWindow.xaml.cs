using PRAKTIKA5.praktikaDataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace PRAKTIKA5
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        ТоварTableAdapter Товар = new ТоварTableAdapter();
        ЧекTableAdapter Чек = new ЧекTableAdapter();
        public UserWindow()
        {
            InitializeComponent();
            ТоварDataGrid.ItemsSource = Товар.GetData();
            ЧекDataGrid.ItemsSource = Чек.GetData();
        }

        private void ТоварDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            authorization authorization = new authorization();
            authorization.Show();
            this.Close();
        }

        private void Plus_Button(object sender, RoutedEventArgs e)
        {
            object id = (ТоварDataGrid.SelectedItem as DataRowView).Row[0];
            object a = (ТоварDataGrid.SelectedItem as DataRowView).Row[1];
            object b = (ТоварDataGrid.SelectedItem as DataRowView).Row[2];
            object c = (ТоварDataGrid.SelectedItem as DataRowView).Row[3];
            
        }

        private void Minus_Button(object sender, RoutedEventArgs e)
        {
            if (ЧекDataGrid.SelectedItem != null)
            {
                object id = (ЧекDataGrid.SelectedItem as DataRowView).Row[0];
                Чек.DeleteQuery(Convert.ToInt32(id));
                ЧекDataGrid.ItemsSource = Чек.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
    }
}
