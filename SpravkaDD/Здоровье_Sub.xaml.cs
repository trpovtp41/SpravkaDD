using System;
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
    public sealed partial class Здоровье_Sub : Page
    {
        AdminTrue b;
        public Здоровье_Sub()
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
            {
                if (e.Parameter != null)
                {

                    b = (AdminTrue)e.Parameter;
                }

                if (b.at == false)
                {
                    textBox_AddCategory.Visibility = Visibility.Collapsed;
                    button_AddCategory.Visibility = Visibility.Collapsed;
                    listBox.Height = 615;
                }
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int IndItem = listBox.SelectedIndex;
            if (IndItem == 0)
            {
                this.Frame.Navigate(typeof(Location.Больницы), b);
            }
            if (IndItem == 1)
            {
                this.Frame.Navigate(typeof(Location.Аптеки), b);
            }
        }
    }
}
