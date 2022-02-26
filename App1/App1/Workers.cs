using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Xml.Serialization;

namespace App1
{
   public class Workers
    {
        [XmlIgnoreAttribute, AutoIncrement, PrimaryKey]
        public int ID { get; set; }

        public string Login
        {
            get; set;
        }
        public string Pass
        {
            get; set;
        }
        public string Fio
        {
            get; set;
        }
       
        public string Function
        {
            get; set;
        }
        public string Organization
        {
            get; set;
        }
        public string Tel
        {
            get; set;
        }
        public double Reiting
        {
            get; set;
        }
        public Workers (string Login, string Pass, string Fio, string Function, string Organization, string Tel, double Reiting)
        {
            this.Login = Login;
            this.Pass = Pass;
            this.Fio = Fio;
            this.Function = Function;
            this.Organization = Organization;
            this.Tel = Tel;
            this.Reiting = Reiting;
        }
        public Workers() { }
    }
}
