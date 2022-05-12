using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using OrganizerApp.Models;
using OrganizerApp.ViewModels.Commands;
using OrganizerApp.ViewModels.Helpers;

namespace OrganizerApp.ViewModels
{
    public class NotesViewModel
    {
        public ObservableCollection<Notebook> Notebooks {get; set; }

        private Notebook selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }

        public NotesViewModel()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
        }


        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New notebook"
            };

            DatabaseHelper.Insert(newNotebook);
        }


        //Recieve int from Note id
        public void CreateNote (int notebookID)
        {
            Note newNote = new Note()
            {
                NotebookID = notebookID,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = "New note"


            };

            DatabaseHelper.Insert(newNote);
        }

        

    }
}
