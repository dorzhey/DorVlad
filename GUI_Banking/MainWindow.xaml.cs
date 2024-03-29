﻿using GUI_Banking.View;
using GUI_Banking.ViewModel;
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
using Bank_End;

namespace GUI_Banking
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var _usermame = UserName.Text;
            var _password = Password.Text;
            var bm = new Bank_End.BankManager();
            var check = 0;
            foreach(var manager in bm.managers)
            {
                if(manager.ManagerID ==int.Parse(_usermame) && manager.Password == _password)
                {
                    check++;
                }
            }

            //НАПОМИНАНИЕ проверить такого менеджера
            if (check > 0)
            {
                var st = new StartPage();
                st.Show();
            }
            else
            {
                MessageBox.Show("Нет такого менеджера");
            }
           
        }
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    //public interface IMainWindowsCodeBehind
    //{
    //    void LoadView(ViewType typeView);
    //}


    //public enum ViewType
    //{
    //    Main,
    //    First,
    //    Second
    //}


    //public partial class MainWindow : Window, IMainWindowsCodeBehind
    //{
    //    public MainWindow()
    //    {
    //        InitializeComponent();
    //        this.Loaded += MainWindow_Loaded;
    //    }

    //    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    //    {
    //        //загрузка вьюмодел для кнопок меню
    //        MenuViewModel vm = new MenuViewModel();
    //        //даем доступ к этому кодбихайнд
    //        vm.CodeBehind = this;
    //        //делаем эту вьюмодел контекстом данных
    //        this.DataContext = vm;

    //        //загрузка стартовой View
    //        LoadView(ViewType.Main);
    //    }

    //    public void LoadView(ViewType typeView)
    //    {
    //        switch (typeView)
    //        {
    //            case ViewType.Main:
    //                //загружаем вьюшку, ее вьюмодель
    //                MainUC view = new MainUC();
    //                MainViewModel vm = new MainViewModel(this);
    //                //связываем их м/собой
    //                view.DataContext = vm;
    //                //отображаем
    //                this.OutputView.Content = view;
    //                break;
    //            case ViewType.First:
    //                FirstUC viewF = new FirstUC();
    //                FirstViewModel vmF = new FirstViewModel(this);
    //                viewF.DataContext = vmF;
    //                this.OutputView.Content = viewF;
    //                break;
    //            case ViewType.Second:
    //                SecondUC viewS = new SecondUC();
    //                SecondViewModel vmS = new SecondViewModel(this);
    //                viewS.DataContext = vmS;
    //                this.OutputView.Content = viewS;
    //                break;
    //        }


    //    }

}

