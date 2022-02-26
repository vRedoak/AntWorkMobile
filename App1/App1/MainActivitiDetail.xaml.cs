using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainActivitiDetail : ContentPage
    {
        public MainActivitiDetail()
        {
            InitializeComponent();
            // hours.Source = ImageSource.FromResource("App1.circle.png");
            logo.Source = ImageSource.FromResource("App1.log.png");
        }
        private async void Chat_clicked(object sender, EventArgs e)
        {
            var chat = new Page1();
            await Navigation.PushAsync(chat);
        }
    }
}