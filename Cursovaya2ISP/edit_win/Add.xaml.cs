using Cursovaya2ISP.db;
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
using System.Windows.Shapes;

namespace Cursovaya2ISP.edit_win
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private readonly string СonfigName;
        private readonly DBProcssing dbsqlite = new DBProcssing();

        public Add(string СonfigName)
        {
            InitializeComponent();

            this.СonfigName = СonfigName;
            InitializeScrean();
        }

        private void InitializeScrean()
        {
            switch (СonfigName)
            {
                case "AddUser":
                    Title += "пользователя";
                    position.Visibility = Visibility.Hidden;
                    break;
                case "AddStaff":
                    Title += "персонал";
                    break;
                case "AddPC":
                    Title += "компьютер";
                    surname.Visibility = Visibility.Hidden;
                    position.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (СonfigName)
            {
                case "AddUser":
                    if (TextBoxName.Text != string.Empty && TextBoxSurname.Text != string.Empty)
                    {
                        dbsqlite.AddDataUser(TextBoxName.Text, TextBoxSurname.Text);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case "AddStaff":
                    if (TextBoxPosition.Text != string.Empty && TextBoxName.Text != string.Empty && TextBoxSurname.Text != string.Empty)
                    {
                        dbsqlite.AddDataStaff(TextBoxName.Text, TextBoxSurname.Text, TextBoxPosition.Text);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case "AddPC":
                    if (TextBoxName.Text != string.Empty)
                    {
                        dbsqlite.AddDataPC(TextBoxName.Text);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }
    }
}
