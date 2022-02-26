using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using System.Data.SqlTypes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.Internal;
using Amazon.MissingTypes;
using Amazon.Util;
using Amazon.Auth;
using Amazon.Runtime;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using System.Xml.Serialization;


namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public static class Flag
    {
        public static bool Work = false;
        public static DateTime StartWork;
        public static double MyReit = double.Parse(App.Database.GetUser()[5]);
        
    }
	public partial class Start : ContentPage
	{
        Workers[] user;
		public Start ()
		{
			InitializeComponent ();
            Amazon.AWSConfigsS3.UseSignatureVersion4 = true;
            var loggingConfig = Amazon.AWSConfigs.LoggingConfig;
            loggingConfig.LogResponses = Amazon.ResponseLoggingOption.Always;
            loggingConfig.LogMetricsFormat = Amazon.LogMetricsFormatOption.JSON;
            loggingConfig.LogTo = Amazon.LoggingOptions.SystemDiagnostics;
            //////////////////////////////////////////////////////
            //XmlDocument UserInfoXml = new XmlDocument();
            //XmlElement rootElementTeam = (XmlElement)UserInfoXml.AppendChild(UserInfoXml.CreateElement("d"));
            //var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml");
            //UserInfoXml.Save(path);
            //UserInfoXml.RemoveAll();
            //AmazonUpload amaz = new AmazonUpload();
            //amaz.DownloadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml"), "mission69.xml");
            //amaz.UploadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mission69.xml"), "mission69.xml");
            ////////////////////////////////////////////////////////////////////////
            AmazonUpload amaz = new AmazonUpload();
            XmlDocument UserInfoXml1 = new XmlDocument();
            XmlElement rootElementTeam1 = (XmlElement)UserInfoXml1.AppendChild(UserInfoXml1.CreateElement("dura"));
            var path1 = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "workers.xml");
            UserInfoXml1.Save(path1);
            UserInfoXml1.RemoveAll();
            amaz.DownloadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "workers.xml"), "workers.xml");
           
            // amaz.UploadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "workers.xml"), "workers.xml");
         //   Deser(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "workers.xml"));
            
            


            ///////////////////////////////////////////////////////////
            BgImage.Source = ImageSource.FromResource("App1.fonlog.png");
            logo.Source = ImageSource.FromResource("App1.log.png");
             }

        private async void Vhod_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            Deser("workers.xml");
           var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");
            App.database = new UserRepository(path);
            for (int i=0; i<user.Length; i++)
            App.Database.SaveItem(user[i]);
            //var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //path = Path.Combine(path, "user.db");
            //var c = new SQLiteConnection(path, true);
            //var zapros = c.Query<User>("SELECT * FROM User WHERE Pass=1111");



            if (!App.Database.CheckPassword(loginvvod.Text, Pass.Text)) await DisplayAlert("", "Не верный ввод пароля или логина", "OK");
            if (App.Database.CheckPassword(loginvvod.Text, Pass.Text))
            {
                MainActiviti main = new MainActiviti();
                NavigationPage.SetHasNavigationBar(main, false);
                await Navigation.PushAsync(main);
            }
        }

        private void Deser(string pyt)
        {

            
            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),pyt);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Workers>));
            List<Workers> users = new List<Workers>();

            StreamReader reader = new StreamReader(path);


            users = (List<Workers>)serializer.Deserialize(reader);
            user = new Workers[users.Count];

            int i = 0;

            foreach (Workers m in users)
            {
                user[i] = m;

                i++;
            }
            reader.Close();

        }

       
        public void Ser()
        {

            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "testuser.xml");
            List<Workers> tu = new List<Workers>();
            Workers W1 = new Workers("login", "pass", "fio", "function", "krivo", "+375463748323",double.Parse( "0"));
            tu.Add(W1);
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Workers>));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, tu);
            writer.Close();

        }
    }
}