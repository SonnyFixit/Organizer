using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace OrganizerApp.ViewModels.Helpers
{
    public class DatabaseHelper
    {
        //It can be const insted of static, but with static it will be easier to access it and modify without having an instance
        private static string databaseFile = Path.Combine(Environment.CurrentDirectory, "notes.db3");

        public static bool Insert<T> (T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                connection.Insert(item);
            }

                return result;
        }
    }
}
