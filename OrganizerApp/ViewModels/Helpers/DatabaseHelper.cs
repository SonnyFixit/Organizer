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
                int rows = connection.Insert(item);

                if (rows > 0)
                {
                    result = true;

                }
            }

                return result;
        }


        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Update(item);

                if (rows > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Delete(item);

                if (rows > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        //T will have a parametles constructor
        public static List <T> Read<T>(T item) where T: new()
        {
            List<T> items;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                items = connection.Table<T>().ToList();

            }

            return items;
        }
    }
}
