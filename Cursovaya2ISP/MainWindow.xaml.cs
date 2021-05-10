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
using Cursovaya2ISP.db;
using Cursovaya2ISP.edit_win;

namespace Cursovaya2ISP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DBProcssing dbsqlite = new DBProcssing();
        private Dictionary<int, int> DictUser;
        private Dictionary<int, int> DictStaff;
        private Dictionary<int, int> DictPC;

        public MainWindow()
        {
            InitializeComponent();
            UpdataArea();
        }

        private void UpdataArea()
        {
            int a;

            ListBoxUser.Items.Clear();
            ComboBoxPC.Items.Clear();
            ComboBoxStaff.Items.Clear();

            DictUser = new Dictionary<int, int>();
            DictStaff = new Dictionary<int, int>();
            DictPC = new Dictionary<int, int>();

            a = 0;
            foreach (var item in dbsqlite.GetDictUser)
            {
                ListBoxUser.Items.Add(item.Value);
                DictUser.Add(a++, item.Key);
            }
            
            a = 0;
            foreach (var item in dbsqlite.GetDictPC)
            {
                ComboBoxPC.Items.Add(item.Value);
                DictPC.Add(a++, item.Key);
            }

            a = 0;
            foreach (var item in dbsqlite.GetDictStaff)
            {
                ComboBoxStaff.Items.Add(item.Value);
                DictStaff.Add(a++, item.Key);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var config = sender as MenuItem;
            Add add = new Add(config.Name);
            add.Owner = this;
            add.ShowDialog();
            UpdataArea();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            var config = sender as MenuItem;
            Change change = new Change(config.Name);
            change.Owner = this;
            change.ShowDialog();
            UpdataArea();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var config = sender as MenuItem;
            Delete delete = new Delete(config.Name);
            delete.Owner = this;
            delete.ShowDialog();
            UpdataArea();
        }

        private void CreateSession_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создание сессии");
        }

        private void ListBoxUser_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                DataGridUser.ItemsSource = dbsqlite.GetDataUser(DictUser[ListBoxUser.SelectedIndex]);
            }
            catch (KeyNotFoundException)
            {
                //pass
            }
        }
    }
}
