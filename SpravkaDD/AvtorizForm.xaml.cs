﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace SpravkaDD
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AvtorizForm : Page
    {
        private string user_login = "name";
        private string user_pass = "qwerty";
        private string admin_login = "admin";
        private string admin_pass = "root";
        public AvtorizForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if ((user_login == Login.Text) && (user_pass == Parol.Text))
            {
                AdminTrue at = new AdminTrue { at = false };
                this.Frame.Navigate(typeof(UserForm), at);
            }

            if ((admin_login == Login.Text) && (admin_pass == Parol.Text))
            {
                AdminTrue at = new AdminTrue { at = true };
                this.Frame.Navigate(typeof(UserForm),at);
            }
        }
    }
}
