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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        ТоварTableAdapter Товар = new ТоварTableAdapter();
        ЦенаTableAdapter Цена = new ЦенаTableAdapter();
        ПроизводительTableAdapter Производитель = new ПроизводительTableAdapter();
        ПользовательTableAdapter Пользователь = new ПользовательTableAdapter();
        Входные_данныеTableAdapter Входные_данные = new Входные_данныеTableAdapter();
        ПраваTableAdapter Права = new ПраваTableAdapter();
        ОплатаTableAdapter Оплата = new ОплатаTableAdapter();
        КомиссияTableAdapter Комиссия = new КомиссияTableAdapter();
        Способ_оплатыTableAdapter Способ_оплаты = new Способ_оплатыTableAdapter();
        БанкTableAdapter Банк = new БанкTableAdapter();
        public AdminWindow()
        {
            InitializeComponent();
            ТоварDataGrid.ItemsSource = Товар.GetData();
            ЦенаDataGrid.ItemsSource = Цена.GetData();
            ПроизводительDataGrid.ItemsSource = Производитель.GetData();
            ПользовательDataGrid.ItemsSource = Пользователь.GetData();
            Входные_данныеDataGrid.ItemsSource = Входные_данные.GetData();
            ПраваDataGrid.ItemsSource = Права.GetData();
            ОплатаDataGrid.ItemsSource = Оплата.GetData();
            КомиссияDataGrid.ItemsSource = Комиссия.GetData();
            Способ_оплатыDataGrid.ItemsSource = Способ_оплаты.GetData();
            БанкDataGrid.ItemsSource = Банк.GetData();
            ЦенаCbx.ItemsSource = Цена.GetData();
            ЦенаCbx.DisplayMemberPath = "Сумма";
            ЦенаCbx.SelectedValuePath = "ID";
            ПроизводительCbx.ItemsSource = Производитель.GetData();
            ПроизводительCbx.DisplayMemberPath = "Продавец";
            ПроизводительCbx.SelectedValuePath = "ID";
            Способ_оплатыCbx.ItemsSource = Способ_оплаты.GetData();
            Способ_оплатыCbx.DisplayMemberPath = "Название";
            Способ_оплатыCbx.SelectedValuePath = "ID";
            БанкCbx.ItemsSource = Банк.GetData();
            БанкCbx.DisplayMemberPath = "Название";
            БанкCbx.SelectedValuePath = "ID";
            КомиссияCbx.ItemsSource = Комиссия.GetData();
            КомиссияCbx.DisplayMemberPath = "Комиссия (%)";
            КомиссияCbx.SelectedValuePath = "ID";
            ЛогинCbx.ItemsSource = Входные_данные.GetData(); ;
            ЛогинCbx.DisplayMemberPath = "Логин";
            ЛогинCbx.SelectedValuePath = "ID";
            ПраваCbx.ItemsSource = Права.GetData();
            ПраваCbx.DisplayMemberPath = "Название";
            ПраваCbx.SelectedValuePath = "ID";
        }
        /*---------------------------------------------------------------------Товар---------------------------------------------------------------------*/
        private void ТоварDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ТоварDataGrid.SelectedItem != null)
            {
                object a = (ТоварDataGrid.SelectedItem as DataRowView).Row[1];
                object b = (ТоварDataGrid.SelectedItem as DataRowView).Row[2];
                object c = (ТоварDataGrid.SelectedItem as DataRowView).Row[3];
                ТоварTextBox.Text = a.ToString();
                ЦенаCbx.Text = b.ToString();
                ПроизводительCbx.Text = c.ToString();
            }
        }
        private void ТоварAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ТоварTextBox.Text != "" && ЦенаCbx.Text != "" && ПроизводительCbx.Text != "")
            {
                int Цена = Convert.ToInt32(ЦенаCbx.SelectedValue);
                int Производитель = Convert.ToInt32(ПроизводительCbx.SelectedValue);
                Товар.InsertQuery(ТоварTextBox.Text, Цена, Производитель);
                ТоварDataGrid.ItemsSource = Товар.GetData();
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void ТоварDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ТоварDataGrid.SelectedItem != null)
            {
                object id = (ТоварDataGrid.SelectedItem as DataRowView).Row[0];
                Товар.DeleteQuery(Convert.ToInt32(id));
                ТоварDataGrid.ItemsSource = Товар.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void ТоварEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ТоварDataGrid.SelectedItem != null)
            {
                if (ТоварTextBox.Text != "" && ЦенаCbx.Text != "" && ПроизводительCbx.Text != "")
                {
                    int Цена = Convert.ToInt32(ЦенаCbx.SelectedValue);
                    int Производитель = Convert.ToInt32(ПроизводительCbx.SelectedValue);
                    object id = (ТоварDataGrid.SelectedItem as DataRowView).Row[0];
                    Товар.UpdateQuery(ТоварTextBox.Text, Цена, Производитель, Convert.ToInt32(id));
                    ТоварDataGrid.ItemsSource = Товар.GetData();
                }
                else
                {
                    MessageBox.Show("Вы что-то не ввели!");
                }
            }
            else
            {
                MessageBox.Show("Выберите что изменить.");
            }
        }
        /*---------------------------------------------------------------------Цена---------------------------------------------------------------------*/
        private void ЦенаDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ЦенаDataGrid.SelectedItem != null)
            {
                object a = (ЦенаDataGrid.SelectedItem as DataRowView).Row[1];
                object b = (ЦенаDataGrid.SelectedItem as DataRowView).Row[2];
                СуммаTextBox.Text = a.ToString();
                НалогTextBox.Text = b.ToString();
            }
        }
        private void ЦенаAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (СуммаTextBox.Text != "" && НалогTextBox.Text != "")
            {
                    int Сумма = Convert.ToInt32(СуммаTextBox.Text);
                    int Налог = Convert.ToInt32(НалогTextBox.Text);
                Цена.InsertQuery(Сумма, Налог);
                ЦенаDataGrid.ItemsSource = Цена.GetData();
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void ЦенаDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ЦенаDataGrid.SelectedItem != null)
            {
                object id = (ЦенаDataGrid.SelectedItem as DataRowView).Row[0];
                Цена.DeleteQuery(Convert.ToInt32(id));
                ЦенаDataGrid.ItemsSource = Цена.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void ЦенаEditButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (ЦенаDataGrid.SelectedItem != null)
            {
                if (СуммаTextBox.Text != "" && НалогTextBox.Text != "")
                {
                    int Сумма = Convert.ToInt32(СуммаTextBox.Text);
                    int Налог = Convert.ToInt32(НалогTextBox.Text);
                    object id = (ЦенаDataGrid.SelectedItem as DataRowView).Row[0];
                    Цена.UpdateQuery(Сумма, Налог, Convert.ToInt32(id));
                    ЦенаDataGrid.ItemsSource = Цена.GetData();
                }
                else
                {
                    MessageBox.Show("Вы что-то не ввели!");
                }
            }
            else
            {
                MessageBox.Show("Выберите что изменить.");
            }
        }
        /*---------------------------------------------------------------------Производитель---------------------------------------------------------------------*/
        private void ПроизводительDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ПроизводительDataGrid.SelectedItem != null)
            {
                object a = (ПроизводительDataGrid.SelectedItem as DataRowView).Row[1];
                object b = (ПроизводительDataGrid.SelectedItem as DataRowView).Row[2];
                object c = (ПроизводительDataGrid.SelectedItem as DataRowView).Row[3];
                ПродавецTextBox.Text = a.ToString();
                СтранаTextBox.Text = b.ToString();
                РеквизитыTextBox.Text = c.ToString();
            }
        }
        private void ПроизводительAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ПродавецTextBox.Text != "" && СтранаTextBox.Text != "" && РеквизитыTextBox.Text != "")
            {
                Производитель.InsertQuery(ПродавецTextBox.Text, СтранаTextBox.Text, РеквизитыTextBox.Text);
                ПроизводительDataGrid.ItemsSource = Производитель.GetData();
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void ПроизводительDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ПроизводительDataGrid.SelectedItem != null)
            {
                object id = (ПроизводительDataGrid.SelectedItem as DataRowView).Row[0];
                Производитель.DeleteQuery(Convert.ToInt32(id));
                ПроизводительDataGrid.ItemsSource = Производитель.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void ПроизводительEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ПроизводительDataGrid.SelectedItem != null)
            {
                if (ПродавецTextBox.Text != "" && СтранаTextBox.Text != "" && РеквизитыTextBox.Text != "")
                {
                    object id = (ПроизводительDataGrid.SelectedItem as DataRowView).Row[0];
                    Производитель.UpdateQuery(ПродавецTextBox.Text, СтранаTextBox.Text, РеквизитыTextBox.Text, Convert.ToInt32(id));
                    ПроизводительDataGrid.ItemsSource = Производитель.GetData();
                }
                else
                {
                    MessageBox.Show("Вы что-то не ввели!");
                }
            }
            else
            {
                MessageBox.Show("Выберите что изменить.");
            }
        }
        /*---------------------------------------------------------------------Пользователь---------------------------------------------------------------------*/
        private void ПользовательDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ПользовательDataGrid.SelectedItem != null)
            {
                object a = (ПользовательDataGrid.SelectedItem as DataRowView).Row[1];
                object b = (ПользовательDataGrid.SelectedItem as DataRowView).Row[2];
                object c = (ПользовательDataGrid.SelectedItem as DataRowView).Row[3];
                object d = (ПользовательDataGrid.SelectedItem as DataRowView).Row[4];
                ИмяTextBox.Text = a.ToString();
                ФамилияTextBox.Text = b.ToString();
                ПраваCbx.Text = c.ToString();
                ЛогинCbx.Text = d.ToString();
            }
        }
        private void ПользовательAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ИмяTextBox.Text != "" && ФамилияTextBox.Text != "" && ПраваCbx.Text != "" && ЛогинCbx.Text != "")
            {
                int Права = Convert.ToInt32(ПраваCbx.SelectedValue);
                int Логин = Convert.ToInt32(ЛогинCbx.SelectedValue);
                Пользователь.InsertQuery(Права, Логин, ИмяTextBox.Text, ФамилияTextBox.Text);
                ПользовательDataGrid.ItemsSource = Пользователь.GetData();
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void ПользовательDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ПользовательDataGrid.SelectedItem != null)
            {
                object id = (ПользовательDataGrid.SelectedItem as DataRowView).Row[0];
                Пользователь.DeleteQuery(Convert.ToInt32(id));
                ПользовательDataGrid.ItemsSource = Пользователь.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void ПользовательEditButton_Click(object sender, RoutedEventArgs e)
        {

        }
        /*---------------------------------------------------------------------Входные_данные---------------------------------------------------------------------*/
        private void Входные_данныеDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Входные_данныеDataGrid.SelectedItem != null)
            {
                object a = (Входные_данныеDataGrid.SelectedItem as DataRowView).Row[1];
                object b = (Входные_данныеDataGrid.SelectedItem as DataRowView).Row[2];
                ЛогинTextBox.Text = a.ToString();
                ПарольTextBox.Password = b.ToString();
            }
        }
        private void Входные_данныеAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ЛогинTextBox.Text != "" && ПарольTextBox.Password != "")
            {
                Входные_данные.InsertQuery(ЛогинTextBox.Text, ПарольTextBox.Password);
                Входные_данныеDataGrid.ItemsSource = Входные_данные.GetData();
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void Входные_данныеDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (Входные_данныеDataGrid.SelectedItem != null)
            {
                object id = (Входные_данныеDataGrid.SelectedItem as DataRowView).Row[0];
                Входные_данные.DeleteQuery(Convert.ToInt32(id));
                Входные_данныеDataGrid.ItemsSource = Входные_данные.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void Входные_данныеEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Входные_данныеDataGrid.SelectedItem != null)
            {
                if (ЛогинTextBox.Text != "" && ПарольTextBox.Password != "")
                {
                    object id = (Входные_данныеDataGrid.SelectedItem as DataRowView).Row[0];
                    Входные_данные.UpdateQuery(ЛогинTextBox.Text, ПарольTextBox.Password, Convert.ToInt32(id));
                    Входные_данныеDataGrid.ItemsSource = Входные_данные.GetData();
                }
                else
                {
                    MessageBox.Show("Вы что-то не ввели!");
                }
            }
            else
            {
                MessageBox.Show("Выберите что изменить.");
            }
        }
        /*---------------------------------------------------------------------Права---------------------------------------------------------------------*/
        private void ПраваDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ПраваDataGrid.SelectedItem != null)
            {
                object a = (ПраваDataGrid.SelectedItem as DataRowView).Row[1];
                object b = (ПраваDataGrid.SelectedItem as DataRowView).Row[2];
                Уровень_доступаTextBox.Text = a.ToString();
                ПраваTextBox.Text = b.ToString();
            }
        }
        private void ПраваAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Уровень_доступаTextBox.Text != "" && ПраваTextBox.Text != "")
            {
                if (Уровень_доступаTextBox.Text == "1" || Уровень_доступаTextBox.Text == "2" || Уровень_доступаTextBox.Text == "3")
                {
                    Права.InsertQuery(Уровень_доступаTextBox.Text, ПраваTextBox.Text);
                    ПраваDataGrid.ItemsSource = Права.GetData();
                }
                else
                {
                    MessageBox.Show("Нет такого уровня доступа!");
                }
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void ПраваDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ПраваDataGrid.SelectedItem != null)
            {
                object id = (ПраваDataGrid.SelectedItem as DataRowView).Row[0];
                Права.DeleteQuery(Convert.ToInt32(id));
                ПраваDataGrid.ItemsSource = Права.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void ПраваEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ПраваDataGrid.SelectedItem != null)
            {
                if (ЛогинTextBox.Text != "" && ПарольTextBox.Password != "")
                {
                    object id = (ПраваDataGrid.SelectedItem as DataRowView).Row[0];
                    if (Уровень_доступаTextBox.Text == "1" || Уровень_доступаTextBox.Text == "2" || Уровень_доступаTextBox.Text == "3")
                    {
                        Права.UpdateQuery(Уровень_доступаTextBox.Text, ПраваTextBox.Text, Convert.ToInt32(id));
                        ПраваDataGrid.ItemsSource = Права.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Нет такого уровня доступа!");
                    }
                }
                else
                {
                    MessageBox.Show("Вы что-то не ввели!");
                }
            }
            else
            {
                MessageBox.Show("Выберите что изменить.");
            }
        }
        /*---------------------------------------------------------------------Оплата---------------------------------------------------------------------*/
        private void ОплатаDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object a = (ОплатаDataGrid.SelectedItem as DataRowView).Row[1];
            object b = (ОплатаDataGrid.SelectedItem as DataRowView).Row[2];
            БанкCbx.Text = a.ToString();
            КомиссияCbx.Text = b.ToString();
        }
        private void ОплатаAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (БанкCbx.Text != "" && КомиссияCbx.Text != "")
            {
                int Банк = Convert.ToInt32(БанкCbx.SelectedValue);
                int Комиссия = Convert.ToInt32(КомиссияCbx.SelectedValue);
                Оплата.InsertQuery(Банк, Комиссия);
                ОплатаDataGrid.ItemsSource = Оплата.GetData();
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void ОплатаDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ОплатаDataGrid.SelectedItem != null)
            {
                object id = (ОплатаDataGrid.SelectedItem as DataRowView).Row[0];
                Оплата.DeleteQuery(Convert.ToInt32(id));
                ОплатаDataGrid.ItemsSource = Оплата.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void ОплатаEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ОплатаDataGrid.SelectedItem != null)
            {
                if (БанкCbx.Text != "" && КомиссияCbx.Text != "")
                {
                    int Банк = Convert.ToInt32(БанкCbx.SelectedValue);
                    int Комиссия = Convert.ToInt32(КомиссияCbx.SelectedValue);
                    object id = (ОплатаDataGrid.SelectedItem as DataRowView).Row[0];
                    Оплата.UpdateQuery(Банк, Комиссия, Convert.ToInt32(id));
                    ОплатаDataGrid.ItemsSource = Оплата.GetData();
                }
                else
                {
                    MessageBox.Show("Вы что-то не ввели!");
                }
            }
            else
            {
                MessageBox.Show("Выберите что изменить.");
            }
        }
        /*---------------------------------------------------------------------Комиссия---------------------------------------------------------------------*/
        private void КомиссияDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (КомиссияDataGrid.SelectedItem != null)
            {
                object a = (КомиссияDataGrid.SelectedItem as DataRowView).Row[1];
                object b = (КомиссияDataGrid.SelectedItem as DataRowView).Row[2];
                КомиссияTextBox.Text = a.ToString();
                Способ_оплатыCbx.Text = b.ToString();
            }
        }
        private void КомиссияAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (КомиссияTextBox.Text != "" && Способ_оплатыCbx.Text != "")
            {
                int a = Convert.ToInt32(КомиссияTextBox.Text);
                int Способ_оплаты = Convert.ToInt32(Способ_оплатыCbx.SelectedValue);
                Комиссия.InsertQuery(a, Способ_оплаты);
                КомиссияDataGrid.ItemsSource = Комиссия.GetData();
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void КомиссияDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (КомиссияDataGrid.SelectedItem != null)
            {
                object id = (КомиссияDataGrid.SelectedItem as DataRowView).Row[0];
                Комиссия.DeleteQuery(Convert.ToInt32(id));
                КомиссияDataGrid.ItemsSource = Комиссия.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void КомиссияEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (КомиссияDataGrid.SelectedItem != null)
            {
                if (КомиссияTextBox.Text != "" && Способ_оплатыCbx.Text != "")
                {
                    int a = Convert.ToInt32(КомиссияTextBox.Text);
                    int Способ_оплаты = Convert.ToInt32(Способ_оплатыCbx.SelectedValue);
                    object id = (КомиссияDataGrid.SelectedItem as DataRowView).Row[0];
                    Комиссия.UpdateQuery(a, Способ_оплаты, Convert.ToInt32(id));
                    КомиссияDataGrid.ItemsSource = Комиссия.GetData();
                }
                else
                {
                    MessageBox.Show("Вы что-то не ввели!");
                }
            }
            else
            {
                MessageBox.Show("Выберите что изменить.");
            }
        }
        /*---------------------------------------------------------------------Способ_оплаты---------------------------------------------------------------------*/
        private void Способ_оплатыDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Способ_оплатыDataGrid.SelectedItem != null)
            {
                object a = (Способ_оплатыDataGrid.SelectedItem as DataRowView).Row[1];
                object b = (Способ_оплатыDataGrid.SelectedItem as DataRowView).Row[2];
                Способ_оплатыTextBox.Text = a.ToString();
                Реквизиты_Способ_оплатыTextBox.Text = b.ToString();
            }
        }
        private void Способ_оплатыAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Способ_оплатыTextBox.Text != "" && Реквизиты_Способ_оплатыTextBox.Text != "")
            {
                Способ_оплаты.InsertQuery(Способ_оплатыTextBox.Text, Реквизиты_Способ_оплатыTextBox.Text);
                Способ_оплатыDataGrid.ItemsSource = Способ_оплаты.GetData();
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void Способ_оплатыDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (Способ_оплатыDataGrid.SelectedItem != null)
            {
                object id = (Способ_оплатыDataGrid.SelectedItem as DataRowView).Row[0];
                Способ_оплаты.DeleteQuery(Convert.ToInt32(id));
                Способ_оплатыDataGrid.ItemsSource = Способ_оплаты.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void Способ_оплатыEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Способ_оплатыDataGrid.SelectedItem != null)
            {
                if (Способ_оплатыTextBox.Text != "" && Реквизиты_Способ_оплатыTextBox.Text != "")
                {
                    object id = (Способ_оплатыDataGrid.SelectedItem as DataRowView).Row[0];
                    Способ_оплаты.UpdateQuery(Способ_оплатыTextBox.Text, Реквизиты_Способ_оплатыTextBox.Text, Convert.ToInt32(id));
                    Способ_оплатыDataGrid.ItemsSource = Способ_оплаты.GetData();
                }
                else
                {
                    MessageBox.Show("Вы что-то не ввели!");
                }
            }
            else
            {
                MessageBox.Show("Выберите что изменить.");
            }
        }
        /*---------------------------------------------------------------------Банк---------------------------------------------------------------------*/
        private void БанкDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (БанкDataGrid.SelectedItem != null)
            {
                object a = (БанкDataGrid.SelectedItem as DataRowView).Row[1];
                object b = (БанкDataGrid.SelectedItem as DataRowView).Row[2];
                БанкTextBox.Text = a.ToString();
                Номер_счетаTextBox.Text = b.ToString();
            }
        }
        private void БанкAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (БанкTextBox.Text != "" && Номер_счетаTextBox.Text != "")
            {
                Банк.InsertQuery(БанкTextBox.Text, Номер_счетаTextBox.Text);
                БанкDataGrid.ItemsSource = Банк.GetData();
            }
            else
            {
                MessageBox.Show("Вы что-то не ввели!");
            }
        }
        private void БанкDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (БанкDataGrid.SelectedItem != null)
            {
                object id = (БанкDataGrid.SelectedItem as DataRowView).Row[0];
                Банк.DeleteQuery(Convert.ToInt32(id));
                БанкDataGrid.ItemsSource = Банк.GetData();
            }
            else
            {
                MessageBox.Show("Выберите что удалить.");
            }
        }
        private void БанкEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (БанкDataGrid.SelectedItem != null)
            {
                if (БанкTextBox.Text != "" && Реквизиты_Способ_оплатыTextBox.Text != "")
                {
                    object id = (БанкDataGrid.SelectedItem as DataRowView).Row[0];
                    Банк.UpdateQuery(БанкTextBox.Text, Номер_счетаTextBox.Text, Convert.ToInt32(id));
                    БанкDataGrid.ItemsSource = Банк.GetData();
                }
                else
                {
                    MessageBox.Show("Вы что-то не ввели!");
                }
            }
            else
            {
                MessageBox.Show("Выберите что изменить.");
            }
        }
        /*---------------------------------------------------------------------Мусор---------------------------------------------------------------------*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            authorization authorization = new authorization();
            authorization.Show();
            this.Close();
        }
    }
}
