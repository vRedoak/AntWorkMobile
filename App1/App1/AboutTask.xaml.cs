using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutTask : ContentPage
	{
        int ID;
        public int done = 0;
        public Mission[] allmission;
        public Mission[] mission;
        int kol;
        double r;
        public AboutTask (Mission pmission, int id)
		{
			InitializeComponent ();
            Topik.Text = pmission.Topic;
            About.Text = pmission.About;
            Time.Text = Convert.ToString( pmission.Date_Miss);
            Rate.Text = Convert.ToString(pmission.Rate);
            r = pmission.Rate;
            ID = id;

          //  AmazonUpload amaz = new AmazonUpload();
         
          //  amaz.DownloadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml"));
            Deser("mission69.xml");
            int i = 0;
            int n = 0;
            int t = 0;
            int k = allmission.Length;
            string log = App.Database.GetUser()[0];
            for (i = 0; i < k; i++)
            {
                if (allmission[i].Login == log && allmission[i].Done == 0) n++;

            }
            mission = new Mission[n];
            for (i = 0; i < k; i++)
            {
                if (allmission[i].Login == log && allmission[i].Done == 0)
                {
                    mission[t] = allmission[i];
                    t++;
                }
            }


        }

        private async void Ready_Clicked(object sender, EventArgs e)
        {

             AmazonUpload amaz = new AmazonUpload();
            ////amaz.UploadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "missions.xml"));
            //p.DelitMission(ID);
            //p.Ser("mission69.xml");

            //await DisplayAlert("", "Задача не выполнена", "ОК");
            //AmazonUpload amaz = new AmazonUpload();
            //amaz.UploadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml"));

            DelitMission(ID);
            Ser("mission69.xml");
            amaz.UploadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml"), "mission69.xml");
            Flag.MyReit = Flag.MyReit + r;
            await DisplayAlert("", "Задача выполнена", "ОК");
            var p = new Tasks();
            await Navigation.PushAsync(p);
        }

        private void Deser(string pyt)
        {
            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));
            List<Mission> missions = new List<Mission>();

            StreamReader reader = new StreamReader(path);

            missions = (List<Mission>)serializer.Deserialize(reader);
            allmission = new Mission[missions.Count];
            reader.Close();
            int i = 0;
            kol = 0;
            foreach (Mission m in missions)
            {
                allmission[i] = m;
                kol++;
                i++;
            }


        }
        public void DelitMission(int i)
        {
            mission[i].Done = int.Parse("1");
        }

        public void Ser(string pyt)
        {

            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml");
            List<Mission> missions = new List<Mission>();
            string log = App.Database.GetUser()[0];
            for (int i = 0; i < mission.Length; i++)
            {
                    missions.Add(mission[i]);
            }
            for (int i = 0; i <kol; i++)
            {
                if (allmission[i].Login == log && allmission[i].Done == 0)
                {
                    missions.Add(allmission[i]);
                }
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, missions);
            writer.Close();

        }

    }
}