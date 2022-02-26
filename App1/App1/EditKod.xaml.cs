using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Xamarin.Forms;
using System.Xml.Linq;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditKod : ContentPage
	{
        
        public EditKod ()
		{
			InitializeComponent ();
            if (Flag.Work) { NeRabotat.IsVisible = true; Rabotat.IsVisible = false; }
            else { Rabotat.IsVisible = true; NeRabotat.IsVisible = false; }
            Deser("IfOnWork.xml");
            AmazonUpload amaz = new AmazonUpload();
            amaz.DownloadFile(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "code.xml"), "code.xml");

        }

        private void KodVvod_Clicke(object sender, EventArgs e)
        {
            if (Kod.Text == RKod())
            {
                Flag.Work = true;
                Flag.StartWork = DateTime.Now;
                IfOnWork wok = Tr.users2.Find((work) => work.Login == App.Database.GetUser()[0]);
                Tr.users2.Remove(wok);
                IfOnWork newwork = new IfOnWork(App.Database.GetUser()[0], 1, Convert.ToString(Flag.StartWork));
                Tr.users2.Add(newwork);
                Ser("IfOnWork.xml"); 
                AmazonUpload amaz = new AmazonUpload();
                amaz.UploadFile((Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "IfOnWork.xml")), "IfOnWork");
                DisplayAlert("", "Вы пришли на работу " + Flag.StartWork, "ОК");
                Vihod();
            } else DisplayAlert("", "Не верный ввод пароля ", "ОК");
        }

        public async void  Vihod()
        {
           // var p = new Glavnaya();
            
            await Navigation.PopAsync();
        }

        private void Zavershit_Clicke(object sender, EventArgs e)
        {
            Flag.Work = false;
            DisplayAlert("", "Вы завершили работу в" + DateTime.Now, "");
        }



        private void Deser(string pyt)
        {


            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), pyt);
            XmlSerializer serializer = new XmlSerializer(typeof(List<IfOnWork>));

            Tr.users2 = new List<IfOnWork>();
            StreamReader reader = new StreamReader(path);


            Tr.users2 = (List<IfOnWork>)serializer.Deserialize(reader);
            reader.Close();
            

        }
        public void Ser(string pyt)
        {

            var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), pyt);
           
            XmlSerializer serializer = new XmlSerializer(typeof(List<IfOnWork>));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, Tr.users2);
            writer.Close();


        }
        public string RKod()
        {
           
            XmlSerializer serializer = new XmlSerializer(typeof(CodeGen));

            //List<CodeGen> users3 = new List<CodeGen>();
            StreamReader reader = new StreamReader(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "code.xml"));
            CodeGen k = new CodeGen();

            k = (CodeGen)serializer.Deserialize(reader);
            reader.Close();
            return k.Code;

            //XDocument xdoc = XDocument.Load(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "code.xml"));

            //string poi = xdoc.Element("Code").Value;
            //return poi;

        }
    }
    public static class Tr
    {
        public static List<IfOnWork> users2;
    }
}