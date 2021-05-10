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
    /// Логика взаимодействия для change.xaml
    /// </summary>
    public partial class Change : Window
    {
        private readonly string СonfigName;

        public Change(string СonfigName)
        {
            InitializeComponent();

            this.СonfigName = СonfigName;
            InitializeScrean();
        }

        private void InitializeScrean()
        {
            switch (СonfigName)
            {
                case "ChangeUser": Title += "пользователя"; break;
                case "ChangeStaff": Title += "персонал"; break;
                case "ChangePC": Title += "компьютер"; break;
                default: break;
            }
        }
    }
}
