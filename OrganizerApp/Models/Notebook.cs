using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace OrganizerApp.Models
{
    public class Notebook
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Indexed]
        public int UserID { get; set; }

        public string Name { get; set; }

    }
}
