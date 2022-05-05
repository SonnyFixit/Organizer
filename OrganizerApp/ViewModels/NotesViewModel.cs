using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizerApp.Models;
using System.Collections.ObjectModel;

namespace OrganizerApp.ViewModels
{
    public class NotesViewModel
    {
        public ObservableCollection<Notebook> Notebooks {get; set; }

    }
}
