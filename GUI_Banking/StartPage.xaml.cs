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
namespace GUI_Banking
{
    public interface IMainWindowsCodeBehind
    {
        void LoadView(ViewType typeView);
    }


    public enum ViewType
    {
        Main,
        First,
        Second
    }


    public partial class StartPage : Window, IMainWindowsCodeBehind
    {
        public StartPage()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню
            MenuViewModel vm = new MenuViewModel();
            //даем доступ к этому кодбихайнд
            vm.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;

            //загрузка стартовой View
            LoadView(ViewType.Main);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Main:
                    //загружаем вьюшку, ее вьюмодель
                    MainUC view = new MainUC();
                    MainViewModel vm = new MainViewModel(this);
                    //связываем их м/собой
                    view.DataContext = vm;
                    //отображаем
                    this.OutputView.Content = view;
                    break;
                case ViewType.First:
                    FirstUC viewF = new FirstUC();
                    FirstViewModel vmF = new FirstViewModel(this);
                    viewF.DataContext = vmF;
                    this.OutputView.Content = viewF;
                    break;
                case ViewType.Second:
                    SecondUC viewS = new SecondUC();
                    SecondViewModel vmS = new SecondViewModel(this);
                    viewS.DataContext = vmS;
                    this.OutputView.Content = viewS;
                    break;
            }


        }
        /// <summary>
        /// Логика взаимодействия для StartPage.xaml
        /// </summary>
        //public partial class StartPage : Window
        //{
        //    public StartPage()
        //    {
        //        InitializeComponent();
        //    }

        //    private void Button_Click(object sender, RoutedEventArgs e)
        //    {

        //    }
        //}
    }
}
