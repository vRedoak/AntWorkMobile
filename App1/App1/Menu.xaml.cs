using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.SqlTypes;
namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BgImage.Source = ImageSource.FromResource("App1.fonlog.png");
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            //      User one = new User()
            //      {
            //          FIO = FIO.Text;
            //      }
            //const string databaseName = @ C:
            //  SQLiteConnection.C
            //      using (SQLiteConnection conn = new SQLiteConnection(connPath))
            //      {
            //          conn.CreateTable<User>();
            //      }
        }
        //protected override void OnAppearing()
        //{
        //    userList.ItemsSource = App.Database.GetItems();
        //    user
        //    base.OnAppearing();
        //}
    }
    }