using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;
using System.Configuration;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;




[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace App1
{
    public partial class App : Application
    {
        public const string database_name = "user.db";
        public static UserRepository database;
      
        public static UserRepository Database
        {
           
        get{

                if (database == null)
                {
                    // database = new UserRepository(@"D:/Хакатон/user.db");

                    //string applicationFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "CanFindLocation");
                    //Directory.CreateDirectory(applicationFolderPath);
                    //string databaseFileName = Path.Combine(applicationFolderPath, "CanFindLocation.db");
                    //SQLite.SQLite3.Con
                    var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    path = Path.Combine(path, "user.db");
                    database = new UserRepository(path);
                   
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            

            var page = new NavigationPage( new Start ());
            NavigationPage.SetHasNavigationBar(page, false);
            
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
