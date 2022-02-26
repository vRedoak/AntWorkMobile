using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamForms.Controls;
using System.IO;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Glavnaya : ContentPage
	{
        
		public Glavnaya ()
		{
			InitializeComponent ();
           // if (!File.Exists(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "IfOnWork.xml")))
           // {
                Ser("IfOnWork.xml");
            //}
            
            AmazonUpload amaz = new AmazonUpload();
            amaz.DownloadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "graf.xml"), "graf.xml");


            Random r = new Random();
            int h = r.Next(0, 4);
            if (h == 1) Nadpis.Text = "Удачного рабочего дня!";
            if (h == 2) Nadpis.Text = "Если тебе нравиться твоя работа, ты никогда не работаешь";
            if (h ==3) Nadpis.Text = "Дело без старания - только рук марание";
            if (Flag.Work)
            {
                NoWork.IsVisible = true;
                Work.IsVisible = false;
            }
            else
            {
                Work.IsVisible = true;
                NoWork.IsVisible = false;
            }

            logo.Source = ImageSource.FromResource("App1.log.png");
            FIO.Text = App.Database.GetUser()[2];
            if (NoWork.IsVisible == true)
            {
                System.TimeSpan tim = DateTime.Now - Flag.StartWork;
                string vr = tim.Hours.ToString() +":"+ tim.Minutes.ToString();
                chas.Text = vr;
            }
            
            reit.Text = Flag.MyReit+"";
        }

        private async void Work_Clicked(object sender, EventArgs e)
        {
            var p = new EditKod();

            await Navigation.PushAsync(p);
        }
       
        public void Ser(string pyt)
        {

            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), pyt);
            List <IfOnWork> iow = new List<IfOnWork>();
            IfOnWork IOW = new IfOnWork(App.Database.GetUser()[0], 0,"00:00:00");
            iow.Add(IOW);
            XmlSerializer serializer = new XmlSerializer(typeof(List<IfOnWork>));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, iow);
            writer.Close();
            

        }
    }
}