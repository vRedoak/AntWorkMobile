using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Grafik : ContentPage
	{
		public Grafik ()
		{
			InitializeComponent ();

            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "graf.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Schedule>));
            List<Schedule> grafiki = new List<Schedule>();

            StreamReader reader = new StreamReader(path);

             grafiki= (List<Schedule>)serializer.Deserialize(reader);
            reader.Close();
            Schedule[] Grafi = new Schedule[grafiki.Count];
            int i = 0;
            foreach (var gr in grafiki)
            {
                Grafi[i] = grafiki[i];
                i++;
            }
            for (i=0; i< Grafi.Length; i++)
            {
                if (Grafi[i].Login == App.Database.GetUser()[0])
                {
                    type.Text = Grafi[i].Type;
                    timestart.Text = ""+Grafi[i].TimeStart;
                    timefinish.Text = "" + Grafi[i].TimeFinish;
                    date.Text = "" + Grafi[i].FirsWorkDay;
                }
            }

        }
	}
}