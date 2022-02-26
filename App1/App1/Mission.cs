using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace App1
{
    [Serializable]
    public class Mission
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Topic { get; set; }
        public string About { get; set; }
        public double Rate { get; set; }
        public DateTime Date_Miss { get; set; }
        public int Done { get; set; } 

        public Mission(int number ,string fio, string topic, string about, double rate, DateTime date_miss,int done)
        {
            Id = number;
            Login = fio;
            Topic = topic;
            About = about;
            Rate = rate;
            Date_Miss = date_miss;
            Done = done;
        }

        public Mission() {}
    }
}
