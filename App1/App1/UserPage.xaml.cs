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
	public partial class UserPage : ContentPage
	{
		public UserPage ()
		{
			InitializeComponent ();
		}

        private void SaveUser(object sender, EventArgs e)
        {
            var user = (Workers)BindingContext;
            if (!String.IsNullOrEmpty(user.Fio))
            {
                App.Database.SaveItem(user);
            }
            this.Navigation.PopAsync();
        }

        //private void DeleteUser(object sender, EventArgs e)
        //{
        //    var user = (User)BindingContext;
        //    App.Database.DeleteItem(user.ID);
        //    this.Navigation.PopAsync();
        //}

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}