using System;
using System.Collections.Generic;
using System.Text;


namespace OrganizerApp.Models
{
    class Note
    {
        public int Id { get; set; }
        public int NotebookID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FileLocation { get; set; }

    }
}
