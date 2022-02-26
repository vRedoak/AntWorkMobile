using System;
using System.Text;

namespace App1
{
   public  class IfOnWork
    {
       public string Login { get; set; }
       public string Date { get; set; }
       public int Rab { get; set; }
        public IfOnWork (string Login, int Rab, string Date)
        {
            this.Login = Login;
            this.Date = Date;
            this.Rab = Rab;
        }
        public IfOnWork() { }
    }
}
