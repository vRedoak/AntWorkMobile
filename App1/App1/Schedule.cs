using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class Schedule
    {
     public string Login { get; set; }
     public string Type { get; set; }
     public   string FirsWorkDay { get; set; }
        public  int TimeStart { get; set; }
        public   int TimeFinish { get; set; }

        

     public Schedule() { }
     public Schedule(
        string login,
        string Type,
        string FirstWorkDay,
        int TimeStart,
        int TimeFinish)
        {
            this.Login = login;
            this.Type = Type;
            this.FirsWorkDay = FirstWorkDay;
            this.TimeStart = TimeStart;
            this.TimeFinish = TimeFinish;
        }
    }
    

}
