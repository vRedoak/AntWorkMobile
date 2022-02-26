using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;


namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
       // this.BackgroundImage = "App1.fon.png";
            //ContentPage = new ContentPage { BackgroundImage = "App1.fon.png" };
            BgImage.Source = ImageSource.FromResource("App1.fonlog.png");
          //  vhod.Source = ImageSource.FromResource("App1.knopka.png");
            //Fon.Source = ImageSource.FromResource("App1.fon.png");

        }
        

        private async void vhod_Clicked(object sender, EventArgs e)
        {
            var p = new Menu();
            NavigationPage.SetHasNavigationBar(p, false);
            
            await Navigation.PushAsync(p);
        }
        private async void AddButton_clicked(object sender, EventArgs e)
        {
          
            Workers user = new Workers();
            UserPage userPage = new UserPage();
            userPage.BindingContext = user;
            NavigationPage.SetHasNavigationBar(userPage, false);
            await Navigation.PushAsync(userPage);
        }
        protected override void OnAppearing()
        {
            userList.ItemsSource = App.Database.GetItems();
            
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Workers selectedUser = (Workers)e.SelectedItem;
            UserPage userPage = new UserPage();
            userPage.BindingContext = selectedUser;
            await Navigation.PushAsync(userPage);
        }
      
        // private void button1_Clicked (object sender, EventArgs e)
        //{
        //label1.Text = "Ваш логин:"+ editor1.Text;
        //}
    }
}
