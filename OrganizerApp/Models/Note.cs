using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using System.ComponentModel;

namespace OrganizerApp.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        [Indexed]
        public int NotebookID { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string FileLocation { get; set; }


    }
}
