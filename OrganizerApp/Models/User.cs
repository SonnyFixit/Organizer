using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace OrganizerApp.Models
{
    class User
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}
