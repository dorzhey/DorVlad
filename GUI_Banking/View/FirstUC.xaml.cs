﻿using System;
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
    /// Логика взаимодействия для FirstUC.xaml
    /// </summary>
    public partial class FirstUC : UserControl
    {
        public FirstUC()
        {
            InitializeComponent();
        }

        private void ShowUsersButton_Click(object sender, RoutedEventArgs e)
        {
            var bm = new Bank_End.BankManager();

            UsersListBox.ItemsSource = bm.users;
        }
    }
}
