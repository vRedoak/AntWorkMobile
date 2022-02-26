using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainActivitiMaster : ContentPage
    {
        public ListView ListView;

        public MainActivitiMaster()
        {
            InitializeComponent();

            BindingContext = new MainActivitiMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainActivitiMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainActivitiMenuItem> MenuItems { get; set; }
            
            public MainActivitiMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainActivitiMenuItem>(new[]
                {
                    new MainActivitiMenuItem { Id = 0, Title = "Page 1" },
                    new MainActivitiMenuItem { Id = 1, Title = "Page 2" },
                    new MainActivitiMenuItem { Id = 2, Title = "Page 3" },
                    new MainActivitiMenuItem { Id = 3, Title = "Page 4" },
                    new MainActivitiMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void grafik_clicked(object sender, EventArgs e)
        {
            grafik.BackgroundColor = Color.FromHex( "#ffc3ab");
           Main.BackgroundColor = Color.Transparent;
            tasks.BackgroundColor= Color.Transparent;
        }

        private void main_clicked(object sender, EventArgs e)
        {
            Main.BackgroundColor = Color.FromHex("#ffc3ab");
            grafik.BackgroundColor = Color.Transparent;
            tasks.BackgroundColor = Color.Transparent;
        }

        private void tasks_clicked(object sender, EventArgs e)
        {
            tasks.BackgroundColor = Color.FromHex("#ffc3ab");
            grafik.BackgroundColor = Color.Transparent;
            Main.BackgroundColor = Color.Transparent;
          
          
        }
        private void chat_clicked(object sender, EventArgs e)
        {
            


        }
        private async void exit_clicked(object sender, EventArgs e)
        {
            var p = new Start();
            NavigationPage.SetHasNavigationBar(p, false);

            await Navigation.PushAsync(p);
        }
    }
}