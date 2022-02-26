using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainActiviti : MasterDetailPage
    {
        public MainActiviti()
        {
            InitializeComponent();
            FIO.Text = App.Database.GetUser()[2];
            AmazonUpload amaz = new AmazonUpload();

            amaz.DownloadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml"), "mission69.xml");

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
        private void grafik_clicked(object sender, EventArgs e)
        {
            grafik.BackgroundColor = Color.FromHex("#ffc3ab");
            Main.BackgroundColor = Color.Transparent;
            tasks.BackgroundColor = Color.Transparent;
            akk.BackgroundColor = Color.Transparent;
            
            Detail = new NavigationPage(new Grafik());
        } 

        private void main_clicked(object sender, EventArgs e)
        {
            Main.BackgroundColor = Color.FromHex("#ffc3ab");
            grafik.BackgroundColor = Color.Transparent;
            tasks.BackgroundColor = Color.Transparent;
            akk.BackgroundColor = Color.Transparent;
            Detail = new NavigationPage(new Glavnaya());
        }

        private void tasks_clicked(object sender, EventArgs e)
        {
            tasks.BackgroundColor = Color.FromHex("#ffc3ab");
            grafik.BackgroundColor = Color.Transparent;
            Main.BackgroundColor = Color.Transparent;
            akk.BackgroundColor = Color.Transparent;
            
            Detail = new NavigationPage(new Tasks());
        }

        private async void exit_clicked(object sender, EventArgs e)
        {
            var p = new Start();
            NavigationPage.SetHasNavigationBar(p, false);

            await Navigation.PushAsync(p);
        }

        private void akk_clicked(object sender, EventArgs e)
        {
            akk.BackgroundColor = Color.FromHex("#ffc3ab");
            grafik.BackgroundColor = Color.Transparent;
            Main.BackgroundColor = Color.Transparent;
            tasks.BackgroundColor = Color.Transparent;
            Detail = new NavigationPage(new Akk());
        }
    }
}