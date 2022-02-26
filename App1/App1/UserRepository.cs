using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace App1
{
   public class UserRepository
    {
        string[] a = new string[6];
       public  SQLiteConnection database;
        public UserRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Workers>();
        }

        public bool CheckPassword(String login, String password)
        {
            List<Workers> u = database.Query<Workers>("SELECT * FROM Workers WHERE Login=?",login);
            if (u.Count == 0) return false;
            
            a[0] = u[0].Login;
            a[1] = u[0].Pass;
            a[2] = u[0].Fio;
            a[3] = u[0].Function;
            a[4] = Convert.ToString(u[0].Tel);
            a[5] = Convert.ToString(u[0].Reiting);
            return u[0].Pass == password;
        }
        public string[] GetUser()
        {
            
           return a;
        }
        public IEnumerable<Workers> GetItems()
        {
           return database.Table<Workers>().ToList();
        }
        public   Workers GetItem(int id)
        {
            return database.Get<Workers>(id);
        }
        public Workers DeleteItem(int id)
        {
            return database.Get<Workers>(id);
        }
        public int SaveItem(Workers item)
        {
            if (item.ID != 0)
            {
                database.Update(item);
                return item.ID;
            } else
            {
                return database.Insert(item);
            }
        }
    }
}
