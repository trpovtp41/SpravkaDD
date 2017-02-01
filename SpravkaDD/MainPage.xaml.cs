using SpravkaDD;
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
using System.Threading.Tasks;
using Windows.Storage;
using Windows.ApplicationModel;
using System.Xml.Linq;
using SQLitePCL;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace SpravkaDD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public class DbRepos
    {
        public SQLiteConnection con;
        static string dbname = "DB.mdf";
        public DbRepos()
        {
            this.con = new SQLiteConnection(dbname);
        }
        public static async Task CopyDatabase()
        {
            bool isDatabaseExisting = false;

            try
            {
                StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(dbname);
                isDatabaseExisting = true;
            }
            catch
            {
                isDatabaseExisting = false;
            }

            if (!isDatabaseExisting)
            {
                StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync("DB.mdf");
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
            }
        }
        public ObservableCollection<Person> GetPerson()
        {
            ObservableCollection<Person> coll = new ObservableCollection<Person>();
            using (var statement = con.Prepare("SELECT * FROM Person"))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    Person person = new Person();
                    person.Id = (long)statement[0];
                    person.log_in = (string)statement[1];
                    person.pass = (string)statement[2];
                    person.imya = (string)statement[3];
                    person.familia = (string)statement[4];

                    coll.Add(person);
                }
                
            }
            return coll;

        }
    }

    public class Person
    {
        public long Id { get; set; }
        public string log_in { get; set; }
        public string pass { get; set; }
        public string imya { get; set; }
        public string familia { get; set; }
    }
    public sealed partial class MainPage : Page
    {
        public static DbRepos q;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegForm));

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AvtorizForm));
        }
    }
    

}
