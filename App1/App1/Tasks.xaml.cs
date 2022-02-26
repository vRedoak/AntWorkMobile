using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using System.Xml.Serialization;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public static class All
    {
        public static int IDmis;
        public static bool flag;
        
    }
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tasks : ContentPage
	{
      public  Mission[] allmission;
        public Mission[] mission;
        public Tasks(int i, int d) { }
        public Tasks ()
		{
			InitializeComponent ();
            task1.Source = ImageSource.FromResource("App1.stars.png");
            task2.Source = ImageSource.FromResource("App1.stars.png");
            task3.Source = ImageSource.FromResource("App1.stars.png");
            task4.Source = ImageSource.FromResource("App1.stars.png");
            task5.Source = ImageSource.FromResource("App1.stars.png");
            task6.Source = ImageSource.FromResource("App1.stars.png");
           
          
            AmazonUpload amaz = new AmazonUpload();
           
            amaz.DownloadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml"), "mission69.xml");
           
            //amaz.UploadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml"), "mission69.xml");
            Deser("mission69.xml");

            int i = 0;
            int n = 0;
            int t = 0;
            int k = allmission.Length;
            string log = App.Database.GetUser()[0];
            for(i=0; i < k; i++)
            {
                if (allmission[i].Login == log && allmission[i].Done == 0)
                    n++;
                
            }
            if (n == 0)
            {
                t1.Text = "Нет активных задач";
                t2.IsVisible = false;
                t3.IsVisible = false;
                t4.IsVisible = false;
                t5.IsVisible = false;
                t6.IsVisible = false;
                task1.IsVisible = false;
                task2.IsVisible = false;
                task3.IsVisible = false;
                task4.IsVisible = false;
                task5.IsVisible = false;
                task6.IsVisible = false;
                return;
            }
            mission = new Mission[n];
            for  (i = 0; i < k; i++)
            {
                if (allmission[i].Login == log && allmission[i].Done==0)
                {
                    mission[t] = allmission[i];
                    t++;
                      }
            }
           // Ser("mission69.xml");
            //amaz.UploadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml"));

            switch (n)
            {
                case 0:
                    {
                        t1.Text = "Нет активных задач";
                        t2.IsVisible = false;
                        t3.IsVisible = false;
                        t4.IsVisible = false;
                        t5.IsVisible = false;
                        t6.IsVisible = false;
                        task1.IsVisible = false;
                        task2.IsVisible = false;
                        task3.IsVisible = false;
                        task4.IsVisible = false;
                        task5.IsVisible = false;
                        task6.IsVisible = false;
                        break;
                    }
                case 1:
                    {
                        t1.Text = "Тема: " + mission[0].Topic;
                        t2.IsVisible = false;
                        t3.IsVisible = false;
                        t4.IsVisible = false;
                        t5.IsVisible = false;
                        t6.IsVisible = false;
                        task2.IsVisible = false;
                        task3.IsVisible = false;
                        task4.IsVisible = false;
                        task5.IsVisible = false;
                        task6.IsVisible = false;
                        break;
                    }
                case 2:
                    {
                        t1.Text = "Тема: " + mission[0].Topic;
                        t2.Text = "Тема: " + mission[1].Topic;
                        t3.IsVisible = false;
                        t4.IsVisible = false;
                        t5.IsVisible = false;
                        t6.IsVisible = false;
                        task3.IsVisible = false;
                        task4.IsVisible = false;
                        task5.IsVisible = false;
                        task6.IsVisible = false;
                        break;
                    }
                case 3:
                    {
                        t1.Text = "Тема: " + mission[0].Topic;
                        t2.Text = "Тема: " + mission[1].Topic;
                        t3.Text = "Тема: " + mission[2].Topic;
                        t4.IsVisible = false;
                        t5.IsVisible = false;
                        t6.IsVisible = false;
                        task4.IsVisible = false;
                        task5.IsVisible = false;
                        task6.IsVisible = false;
                        break;
                    }
                case 4:
                    {
                        t1.Text = "Тема: " + mission[0].Topic;
                        t2.Text = "Тема: " + mission[1].Topic;
                        t3.Text = "Тема: " + mission[2].Topic;
                        t4.Text = "Тема: " + mission[3].Topic;
                        t5.IsVisible = false;
                        t6.IsVisible = false;
                        task5.IsVisible = false;
                        task6.IsVisible = false;
                        break;
                    }
                case 5:
                    {
                        t1.Text = "Тема: " + mission[0].Topic;
                        t2.Text = "Тема: " + mission[1].Topic;
                        t3.Text = "Тема: " + mission[2].Topic;
                        t4.Text = "Тема: " + mission[3].Topic;
                        t5.Text = "Тема: " + mission[4].Topic;
                        t6.IsVisible = false;
                        task6.IsVisible = false;
                        break;
                    }
                case 6:
                    {
                        t1.Text = "Тема: " + mission[0].Topic;
                        t2.Text = "Тема: " + mission[1].Topic;
                        t3.Text = "Тема: " + mission[2].Topic;
                        t4.Text = "Тема: " + mission[3].Topic;
                        t5.Text = "Тема: " + mission[4].Topic;
                        t6.Text = "Тема: " + mission[5].Topic;
                        break;
                    }
            }
        }
        private void Deser(string pyt)
        {
            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));
            List<Mission> missions = new List<Mission>();
            
            StreamReader reader = new StreamReader(path);
   
            missions = (List<Mission>)serializer.Deserialize(reader);
            allmission = new Mission[missions.Count];

            int i = 0;
          
            foreach (Mission m in missions)
            {
                allmission[i] = m;

                    i++;
            }

            
        }
        public void DelitMission(int i)
        {
            mission[i].Done = int.Parse("1");
            allmission[i] = mission[i];
        }

        private async void Task1_Clicked(object sender, EventArgs e)
        {
           // var p = new AboutTask(mission[0],0);
            
            //p.Title = "Задача №1";
            await Navigation.PushAsync(new AboutTask(mission[0], 0));
        }

        public void Ser(string pyt)
        {

            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml");
            List<Mission> missions = new List<Mission>();
           
            for (int i=0; i < allmission.Length; i++)
            {
                missions.Add(allmission[i]);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, missions);
            writer.Close();

        }
        private async void Task2_Clicked(object sender, EventArgs e)
        {
            var p = new AboutTask(mission[1],1);
            p.Title = "Задача №2";
            await Navigation.PushAsync(p);
        }

        private async void Task3_Clicked(object sender, EventArgs e)
        {
            var p = new AboutTask(mission[2],2);
            p.Title = "Задача №3";
            await Navigation.PushAsync(p);
        }

        private async void Task4_Clicked(object sender, EventArgs e)
        {
            var p = new AboutTask(mission[3],3);
            p.Title = "Задача №4";
            await Navigation.PushAsync(p);
        }

        private async void Task5_Clicked(object sender, EventArgs e)
        {
            var p = new AboutTask(mission[4],4);
            p.Title = "Задача №5";
            await Navigation.PushAsync(p);
        }

        private async void Task6_Clicked(object sender, EventArgs e)
        {
            var p = new AboutTask(mission[5],5);
            p.Title = "Задача №6";
            await Navigation.PushAsync(p);
        }
    }
}