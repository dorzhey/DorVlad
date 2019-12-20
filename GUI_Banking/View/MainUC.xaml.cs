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

namespace GUI_Banking.View
{
    /// <summary>
    /// Логика взаимодействия для MainUC.xaml
    /// </summary>
    public partial class MainUC : UserControl
    {
        public MainUC()
        {
            InitializeComponent();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            var userdata = NameSurname.Text.Split(' ');
            var name = userdata[0];
            var secondname = userdata[1];
            var password = Password.Text;
            var bm = new Bank_End.BankManager();
            if(! bm.CheckUser(name, password))
            {
                var user = new Bank_End.Models.User
                {
                    Name = name,
                    SecondName = secondname,
                    Password = password
                };
                bm.users.Add(user);
            }
            else { MessageBox.Show("There is this Client already!"); }

        }
    }
}
