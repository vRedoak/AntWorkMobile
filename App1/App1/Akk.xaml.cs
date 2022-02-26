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
	public partial class Akk : ContentPage
	{
		public Akk ()
		{
			InitializeComponent ();
            My.Source = ImageSource.FromResource("App1.log.png");
            string[] a = App.Database.GetUser();
            FIO.Text = a[0];
            login.Text = a[1];
            Pass.Text = a[2];
            dolzhnost.Text = a[3];
            tel.Text = a[4];
            reit.Text = a[5];
        }
	}
}